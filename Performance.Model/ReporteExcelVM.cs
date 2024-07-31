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
        public string filePath { get; set; }
        public string fileName { get; set; }
        public string nombreColaborador { get; set; }
        public int? idSolicitud { get; set; }
        public bool? activo { get; set; }       
    }   
    public class ReporteExcelPDIVM
    {
        public int idUsuario { get; set; }
        public string colaborador { get; set; }
        public int idJefe { get; set; }
        public string lider { get; set; }       
        public int idMeta { get; set; }
        public Nullable<int> idPDI { get; set; }
        public Nullable<int> tipoAccion { get; set; }
        public Nullable<int> habilidad { get; set; }
        public string metaTitulo { get; set; }
        public string metaDescripcion { get; set; }
        public Nullable<System.DateTime> fechaDesde { get; set; }
        public Nullable<System.DateTime> fechaHasta { get; set; }
        public Nullable<int> status { get; set; }
        public string accionesRealizadas { get; set; }
    }
}
