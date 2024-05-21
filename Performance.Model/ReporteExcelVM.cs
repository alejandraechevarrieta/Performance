using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performance.Model
{
    public class ReporteExcelVM
    {
        public List<string> encabezado { get; set; }
        public List<DetalleExcelVM> filas { get; set; }
        public List<DetalleRepVM> detalle { get; set; }
        public string filePath { get; set; }
        public string fileName { get; set; }
        public string nombreColaborador { get; set; }
        public int? idSolicitud { get; set; }
        public bool? activo { get; set; }
    }

    public class DetalleExcelVM
    {
        public string nombre { get; set; }
        public string observacion { get; set; }
        public string coordinador { get; set; }
        public decimal? HorasRRHH { get; set; }
        public decimal? HorasING { get; set; }
        public decimal? HorasCTR { get; set; }
        public decimal? HorasSca { get; set; }
        public decimal? HorasGDE { get; set; }
        public decimal? HorasOtros { get; set; }
        public decimal? totalHoras { get; set; }
        public List<string> horasImpu { get; set; }
        public List<string> horas100 { get; set; }
        public List<string> horas50 { get; set; }
        public List<string> desarraigoNR { get; set; }
        public List<string> desarraigoR { get; set; }
        public List<string> detalleImputacion { get; set; }
        public string desde { get; set; }
        public string hasta { get; set; }
        public List<string> bono { get; set; }
        public List<string> diasLic { get; set; }
        public List<string> motivoLic { get; set; }

    }
    public class DetalleRepVM
    {
        public string tarea { get; set; }
        public string fecha { get; set; }
        public string proyecto { get; set; }
        public string detalleTarea { get; set; }
        public decimal? horas { get; set; }
        public string estado { get; set; }
        public string tipoSis { get; set; }

    }
}
