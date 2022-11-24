using oee.Captura;
using oee.Catalogos.DescripcionFallas;
using oee.Catalogos.Turnos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace oee.Oee_Porcentaje
{
  public class OeeAppService : ApplicationService, IOeeAppService
  {
    public OeeAppService(IRepository<Oee, int> repositoryOee, IRepository<DescripcionFalla, int> repositoryDescripcion, IRepository<Turno, int> repositoryTurno)
    {
      RepositoryOee = repositoryOee;
      RepositoryDescripcion = repositoryDescripcion;
      RepositoryTurno = repositoryTurno;
    }

    public IRepository<Oee, int> RepositoryOee { get; }
    public IRepository<DescripcionFalla, int> RepositoryDescripcion { get; }
    public IRepository<Turno, int> RepositoryTurno { get; }

    public async Task<OeeDto> CreateAsync(OeeDto oeeDto)
    {
      oeeDto.NetoTime = oeeDto.NetoTime == null ? 0 : oeeDto.NetoTime;
      oeeDto.NetoTimeNP = oeeDto.NetoTimeNP == null ? 0 : oeeDto.NetoTimeNP;
      oeeDto.Ftq = oeeDto.Ftq == null ? 0 : oeeDto.Ftq;
      //netotimeNP
      var netoTimeNP = oeeDto.NetoTime - oeeDto.NetoTimeNP;
      var netoTime = oeeDto.NetoTime;
      //Availability_Porcentaje
      var totalNetoTime = netoTime == 0 ? 0 : (decimal)netoTimeNP / (decimal)netoTime;
      var Availability_Porcentaje = (decimal)totalNetoTime * 100;

      //Quality_Porcentaje
      var Quality_Porcentaje = ((decimal)oeeDto.TotalReales /((decimal)oeeDto.TotalReales + (decimal)oeeDto.Ftq)) * 100 ;
      //Performance_Porcentaje
      //(FN19-SUMAR.SI($M$2:$DH$2,"PRF",$M19:$DH19))/FN19,"")
      var performance1 = oeeDto.NetoTimeNP_Performance != null ? (decimal)oeeDto.NetoTime - (decimal)oeeDto.NetoTimeNP_Performance : 0;//FN19 -> NetoTime -- SUMAR.SI($M$2:$DH$2,"PRF",$M19:$DH19)) ->oeeDto.NetoTimeNP_Performance
      var performance2 = oeeDto.NetoTime == 0 ? 0 : (decimal)performance1 / (decimal)oeeDto.NetoTime; // performance1 ->  (FN19-SUMAR.SI($M$2:$DH$2,"PRF",$M19:$DH19))
      var Performance_Porcentaje = (decimal)performance2 * 100; //performance2 -> performance1 / FN19
      //Oee_Porcentaje
      var Oee_Porcentaje = ((decimal)Availability_Porcentaje * (decimal)Quality_Porcentaje * (decimal)Performance_Porcentaje)/10000;

      var oee = await RepositoryOee.InsertAsync(
              new Oee
              {
                DescripcionId = oeeDto.DescripcionId,
                Fecha = oeeDto.Fecha,
                GAP_Mins = oeeDto.TiempoMuerto,
                GAP_Pzas = oeeDto.GAP_Pzas,
                HoraFinal = oeeDto.HoraFinal.AddHours(-6),
                HoraInicio = oeeDto.HoraInicio.AddHours(-6),
                NumeroParte = oeeDto.NumeroParte,
                OE_Porcentaje = oeeDto.OE_Porcentaje,
                Programado = oeeDto.Programado,
                TiempoMuerto = oeeDto.TiempoMuerto,
                TotalReales = oeeDto.TotalReales,
                TurnoId = oeeDto.TurnoId,
                TotalPlaneadas = oeeDto.TotalPlaneadas,
                Area = oeeDto.Area,
                DescripcionFTQ = oeeDto.DescripcionFTQ,
                Ftq = oeeDto.Ftq,
                DescripcionTM = oeeDto.DescripcionTM,
                NetoTime = oeeDto.NetoTime,
                NetoTimeNP = netoTimeNP,
                Availability_Porcentaje = (double)Availability_Porcentaje,
                Quality_Porcentaje = (double)Quality_Porcentaje,
                Performance_Porcentaje = (double)Performance_Porcentaje,
                Oee_Porcentaje = (double)Oee_Porcentaje,
                NetoTimeNP_Performance = oeeDto.NetoTimeNP_Performance,
                Asociados = oeeDto.Asociados,
                TiempoCiclo = oeeDto.TiempoCiclo
              }); ;
      return new OeeDto
      {
        Id = oee.Id,
      };
    }

    public async Task<List<OeeDto>> GetListAsync()
    {
      var items = await RepositoryOee.GetListAsync();
      var descripciones = await RepositoryDescripcion.GetListAsync();
      var turnos = await RepositoryTurno.GetListAsync();
      return items
          .Select(item => new OeeDto
          {
            Id = item.Id,
            TiempoCiclo =item.TiempoCiclo,
            Asociados=item.Asociados,
            TurnoId = item.TurnoId,
            TotalReales = item.TotalReales,
            TiempoMuerto = item.TiempoMuerto,
            Programado = item.Programado,
            OE_Porcentaje = item.OE_Porcentaje,
            NumeroParte = item.NumeroParte,
            HoraInicioFormato = item.HoraInicio.ToShortTimeString(),
            HoraFinalFormato = item.HoraFinal.ToShortTimeString(),
            DescripcionId = item.DescripcionId,
            FechaFormato = item.Fecha.ToShortDateString(),
            GAP_Mins = item.GAP_Mins,
            GAP_Pzas = item.GAP_Pzas,
            TotalPlaneadas = item.TotalPlaneadas, 
            Descripcion = descripciones.Where(x => x.Id == item.DescripcionId).FirstOrDefault() == null ? "" : descripciones.Where(x => x.Id == item.DescripcionId).FirstOrDefault().Modo,
            Turno = turnos.Where(x => x.Id == item.TurnoId).FirstOrDefault() == null ? "" : turnos.Where(x => x.Id == item.TurnoId).FirstOrDefault().Nombre
          }).ToList();
    }

    public async Task<List<OeeDto>> GetListByAreaAsync(string Area)
    {
      var items = await RepositoryOee.GetListAsync();
      var descripciones = await RepositoryDescripcion.GetListAsync();
      var turnos = await RepositoryTurno.GetListAsync();
      return items.Where(x => x.Area.ToLower() == Area.ToLower())
          .Select(item => new OeeDto
          {
            Id = item.Id,
            TiempoCiclo = item.TiempoCiclo,
            Asociados = item.Asociados,
            TurnoId = item.TurnoId,
            TotalReales = item.TotalReales,
            TiempoMuerto = item.TiempoMuerto,
            Programado = item.Programado,
            OE_Porcentaje = item.OE_Porcentaje,
            NumeroParte = item.NumeroParte,
            HoraInicioFormato = item.HoraInicio.ToShortTimeString(),
            HoraFinalFormato = item.HoraFinal.ToShortTimeString(),
            DescripcionId = item.DescripcionId,
            FechaFormato = item.Fecha.ToShortDateString(),
            GAP_Mins = item.GAP_Mins,
            GAP_Pzas = item.GAP_Pzas,
            TotalPlaneadas = item.TotalPlaneadas,
            Descripcion =item.DescripcionTM,// descripciones.Where(x => x.Id == item.DescripcionId).FirstOrDefault() == null ? "" : descripciones.Where(x => x.Id == item.DescripcionId).FirstOrDefault().Modo,
            Turno = turnos.Where(x => x.Id == item.TurnoId).FirstOrDefault() == null ? "" : turnos.Where(x => x.Id == item.TurnoId).FirstOrDefault().Nombre,
            DescripcionFTQ = item.DescripcionFTQ,
            Quality_Porcentaje = item.Quality_Porcentaje,
            Performance_Porcentaje = item.Performance_Porcentaje,
            Oee_Porcentaje = item.Oee_Porcentaje,
            Availability_Porcentaje = item.Availability_Porcentaje,
            NetoTime = item.NetoTime,
            NetoTimeNP = item.NetoTimeNP,
            NetoTimeNP_Performance = item.NetoTimeNP_Performance,
            Ftq = item.Ftq
          }).ToList();
    }

    public async Task<double> GetGraficaAsync(string Area,int TurnoId,DateTime Fecha, string Categoria)
    {
      var semana = GetIso8601WeekOfYear(Fecha);
      var items = await RepositoryOee.GetListAsync();
      var totalPromedio = 0d;
      if (Categoria.ToUpper() == "AVAILABILITY")
      {
        var promedio = items.Where(x => x.Area == Area
        && x.Fecha.ToShortDateString() == Fecha.ToShortDateString()
        && x.TurnoId == TurnoId)
          .Average(x => x.Availability_Porcentaje);

        totalPromedio = (double)promedio.Value;
      }
      if (Categoria.ToUpper() == "PERFORMANCE")
      {
        var promedio = items.Where(x => x.Area == Area
        && x.Fecha.ToShortDateString() == Fecha.ToShortDateString()
        && x.TurnoId == TurnoId)
          .Average(x => x.Performance_Porcentaje);

        totalPromedio = (double)promedio.Value;
      }
      if (Categoria.ToUpper() == "QUALITY")
      {
        var promedio = items.Where(x => x.Area == Area
        && x.Fecha.ToShortDateString() == Fecha.ToShortDateString()
        && x.TurnoId == TurnoId)
          .Average(x => x.Quality_Porcentaje);

        totalPromedio = (double)promedio.Value;
      }
      if (Categoria.ToUpper() == "OEE")
      {
        var promedio = items.Where(x => x.Area == Area
        && x.Fecha.ToShortDateString() == Fecha.ToShortDateString()
        && x.TurnoId == TurnoId)
          .Average(x => x.Oee_Porcentaje);

        totalPromedio = (double)promedio.Value;
      }
      return Math.Round(totalPromedio,2);
      
    }

    public async Task<List<object>> GetGraficaCompletaAsync(string Area, int TurnoId, DateTime Fecha, string Categoria)
    {
      var items = await RepositoryOee.GetListAsync();
      var totalPromedio = 0d;

      var listaPromedios =new List<object>();
      var semana = GetIso8601WeekOfYear(Fecha);
      DateTime firstDayOfWeek = FirstDateOfWeek(Fecha.Year, semana, CultureInfo.CurrentCulture);
      //var index = ;
      for (var i=0; i < 5; i++) {
        if (Categoria.ToUpper() == "AVAILABILITY")
        {
          var promedio = items.Where(x => x.Area == Area
          && x.Fecha.ToShortDateString() == firstDayOfWeek.ToShortDateString()
          && x.TurnoId == TurnoId)
            .Average(x => x.Availability_Porcentaje);

          totalPromedio = promedio.HasValue ? (double)promedio.Value : 0;
        }
        if (Categoria.ToUpper() == "PERFORMANCE")
        {
          var promedio = items.Where(x => x.Area == Area
          && x.Fecha.ToShortDateString() == firstDayOfWeek.ToShortDateString()
          && x.TurnoId == TurnoId)
            .Average(x => x.Performance_Porcentaje);

          totalPromedio = promedio.HasValue ? (double)promedio.Value : 0;
        }
        if (Categoria.ToUpper() == "QUALITY")
        {
          var promedio = items.Where(x => x.Area == Area
          && x.Fecha.ToShortDateString() == firstDayOfWeek.ToShortDateString()
          && x.TurnoId == TurnoId)
            .Average(x => x.Quality_Porcentaje);

          totalPromedio = promedio.HasValue ? (double)promedio.Value : 0;
        }
        if (Categoria.ToUpper() == "OEE")
        {
          var promedio = items.Where(x => x.Area == Area
          && x.Fecha.ToShortDateString() == firstDayOfWeek.ToShortDateString()
          && x.TurnoId == TurnoId)
            .Average(x => x.Oee_Porcentaje);


          totalPromedio = promedio.HasValue ? (double)promedio.Value : 0;
        }
        var fechaPromedio = firstDayOfWeek.ToShortDateString();
        firstDayOfWeek = firstDayOfWeek.AddDays(1);
        var item = new  { fecha = fechaPromedio, promedio = totalPromedio,turno=TurnoId, area= Area,categoria=Categoria };
        listaPromedios.Add(item);

      }


      return listaPromedios;
      //return Math.Round(totalPromedio, 2);

    }

    public async Task<List<object>> GetGraficaCompletaTurnosAsync(string Area,  DateTime Fecha, string Categoria)
    {
      var items = await RepositoryOee.GetListAsync();
      var totalPromedio = 0d;

      var listaPromedios = new List<object>();
      var semana = GetIso8601WeekOfYear(Fecha);
      DateTime primerDiaSemana = FirstDateOfWeek(Fecha.Year, semana, CultureInfo.CurrentCulture);
      DateTime firstDayOfWeek = FirstDateOfWeek(Fecha.Year, semana, CultureInfo.CurrentCulture);
      var numeroTurno = 1 ;
      for (var j = 0; j < 4; j++) {
        firstDayOfWeek = primerDiaSemana;
        for (var i = 0; i < 5; i++)
        {

          if (Categoria.ToUpper() == "AVAILABILITY")
          {
            var promedio = items.Where(x => x.Area == Area
            && x.Fecha.ToShortDateString() == firstDayOfWeek.ToShortDateString()
            && x.TurnoId == numeroTurno)
              .Average(x => x.Availability_Porcentaje);

            totalPromedio = promedio.HasValue ? (double)promedio.Value : 0;
          }
          if (Categoria.ToUpper() == "PERFORMANCE")
          {
            var promedio = items.Where(x => x.Area == Area
            && x.Fecha.ToShortDateString() == firstDayOfWeek.ToShortDateString()
            && x.TurnoId == numeroTurno)
              .Average(x => x.Performance_Porcentaje);

            totalPromedio = promedio.HasValue ? (double)promedio.Value : 0;
          }
          if (Categoria.ToUpper() == "QUALITY")
          {
            var promedio = items.Where(x => x.Area == Area
            && x.Fecha.ToShortDateString() == firstDayOfWeek.ToShortDateString()
            && x.TurnoId == numeroTurno)
              .Average(x => x.Quality_Porcentaje);

            totalPromedio = promedio.HasValue ? (double)promedio.Value : 0;
          }
          if (Categoria.ToUpper() == "OEE")
          {
            var promedio = items.Where(x => x.Area == Area
            && x.Fecha.ToShortDateString() == firstDayOfWeek.ToShortDateString()
            && x.TurnoId == numeroTurno)
              .Average(x => x.Oee_Porcentaje);


            totalPromedio = promedio.HasValue ? (double)promedio.Value : 0;
          }
          var fechaPromedio = firstDayOfWeek.ToShortDateString();
          firstDayOfWeek = firstDayOfWeek.AddDays(1);
          var item = new { fecha = fechaPromedio, promedio = totalPromedio, turno = numeroTurno, area = Area, categoria = Categoria };
          listaPromedios.Add(item);

        }
        numeroTurno = numeroTurno + 1;

      }



      return listaPromedios;
      //return Math.Round(totalPromedio, 2);

    }


    public static int GetIso8601WeekOfYear(DateTime time)
    {
      // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
      // be the same week# as whatever Thursday, Friday or Saturday are,
      // and we always get those right
      DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
      if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
      {
        time = time.AddDays(3);
      }

      // Return the week of our adjusted day
      return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
    }

    public static DateTime FirstDateOfWeek(int year, int weekOfYear, System.Globalization.CultureInfo ci)
    {
      DateTime jan1 = new DateTime(year, 1, 1);
      int daysOffset = (int)ci.DateTimeFormat.FirstDayOfWeek - (int)jan1.DayOfWeek;
      DateTime firstWeekDay = jan1.AddDays(daysOffset);
      int firstWeek = ci.Calendar.GetWeekOfYear(jan1, ci.DateTimeFormat.CalendarWeekRule, ci.DateTimeFormat.FirstDayOfWeek);
      if ((firstWeek <= 1 || firstWeek >= 52) && daysOffset >= -3)
      {
        weekOfYear -= 1;
      }
      return firstWeekDay.AddDays(weekOfYear * 7);
    }
  }
}
