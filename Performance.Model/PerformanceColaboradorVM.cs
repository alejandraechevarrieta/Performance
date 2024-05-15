using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performance.Model
{
    public class PerformanceColaboradorVM
    {
        public int idPerformance { get; set; }
        public int idUsuario { get; set; }
        public string nombre { get; set; }
        public int ano { get; set; }
        public int antiguedad { get; set; }
        public int idJefe { get; set; }
    }
    public class PerformanceAutoevaluacionVM
    {
        public int idUsuario { get; set; }
        public int idAutoevaluacion { get; set; }
        public int idPerformance { get; set; }
        public int? idHabilidad { get; set; }
        public int? idCalificacion { get; set; }
        public DateTime fechaCalificacion { get; set; }
        public string habilidad1 { get; set; }
        public string habilidad2 { get; set; }
        public string habilidad3 { get; set; }
        public string habilidad4 { get; set; }
        public string habilidad5 { get; set; }
        public string habilidad6 { get; set; }

    }
    public class PerformanceVM
    {
        public int idPerformance { get; set; }
        public int idUsuario { get; set; }
        public string nombre { get; set; }
        public int ano { get; set; }
        public int antiguedad { get; set; }
        public int idJefe { get; set; }
        public string nombreJefe { get; set; }
        public int idAutoevaluacion { get; set; }
        public int idHabilidad { get; set; }
        public int idCalificacion { get; set; }
        public DateTime? fechaEvaluacion { get; set; }
        public DateTime? fechaAutoevaluacion { get; set; }
        public DateTime? fechaCalibracion { get; set; }
        public DateTime? fechaFeedback { get; set; }
        public int? idEstado { get; set; }
        public string estado { get; set; }
        public int? idHabilidad1 { get; set; }
        public int? idHabilidad2 { get; set; }
        public int? idHabilidad3 { get; set; }
        public int? idHabilidad4 { get; set; }
        public int? idHabilidad5 { get; set; }
        public int? idHabilidad6 { get; set; }
        public int? idCalificacion1 { get; set; }
        public int? idCalificacion2 { get; set; }
        public int? idCalificacion3 { get; set; }
        public int? idCalificacion4 { get; set; }
        public int? idCalificacion5 { get; set; }
        public int? idCalificacion6 { get; set; }
        public List<PerformanceAutoevaluacionVM> habilidades { get; set; }
    }
    public class PerformanceEstados
    {
        public int id { get; set; }
        public string estado { get; set; }
    }
    public class ColaboradorVM
    {      
        public int idUsuario { get; set; }
        public string nombre { get; set; }       
        public int antiguedad { get; set; }
        public int idJefe { get; set; }
        public string nombreJefe { get; set; }
        public DateTime? fechaIngreso { get; set; }
    }
    public class PerformanceProgresoVM
    {
        public int totalPerformance { get; set; }
        public int totalCompletar { get; set; }
        public int totalEvaluar { get; set; }
        public int totalCalibrar { get; set; }
        public int totalFinalizado { get; set; }
        public decimal porcentajeTotal {  get; set; }
        public decimal porcentajeCompletar { get; set; }
        public decimal porcentajeEvaluar{ get; set; }
        public decimal porcentajeCalibrar { get; set; }
        public decimal porcentajeFinalizado { get; set; }

    }
    public class DatosPerformanceVM
    {
        public int idUsuario { get; set; }
        public string colaborador { get; set; }
        public string lider { get; set; }
        public int idPerformance { get; set; }
        public int ano { get; set; }
        public int? idHabilidadAutoevaluacion { get; set; }
        public int? idCalificacionAutoevaluacion { get; set; }
        public DateTime? fechaCalificacionAutoevaluacion { get; set; }       
        public int? idHabilidadEvaluacion { get; set; }
        public int? idCalificacionEvaluacion { get; set; }
        public DateTime? fechaCalificacionEvaluacion { get; set; }
        public string nombreHabilidadAutoevaluacion { get; set; }
        public string calificacionAutoevaluacion { get; set; }
        public string nombreHabilidadEvaluacion { get; set; }
        public string calificacionEvaluacion { get; set; }
    }
}
