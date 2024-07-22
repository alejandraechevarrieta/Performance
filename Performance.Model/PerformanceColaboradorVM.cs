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
        public string nombreUsuario { get; set; }
        public int idResponsable { get; set; }
        public int idAutoevaluacion { get; set; }
        public int idPerformance { get; set; }
        public int? idHabilidad { get; set; }
        public int? idCalificacion { get; set; }
        public int? idCalificacionFinal { get; set; }
        public DateTime fechaAutoEvaluacion { get; set; }
        public DateTime fechaCalificacion { get; set; }
        public string habilidad1 { get; set; }
        public string habilidad2 { get; set; }
        public string habilidad3 { get; set; }
        public string habilidad4 { get; set; }
        public string habilidad5 { get; set; }
        public string habilidad6 { get; set; }
        public string calificacionFinal { get; set; }
        public string body { get; set; }
        public string asunto { get; set; }
        public string adjunto { get; set; }
        public string comentario {  get; set; }

    }
    public class PerformanceCalibracionVM
    {
        public int idUsuario { get; set; }
        public int idResponsable { get; set; }
        public string nombreUsuario { get; set; }
        public int idAutoevaluacion { get; set; }
        public int idPerformance { get; set; }
        public int? idHabilidad { get; set; }
        public int? idCalificacion { get; set; }
        public int? idCalificacionFinal { get; set; }
        public DateTime fechaAutoEvaluacion { get; set; }
        public DateTime fechaCalificacion { get; set; }
        public string habilidad1 { get; set; }
        public string habilidad2 { get; set; }
        public string habilidad3 { get; set; }
        public string habilidad4 { get; set; }
        public string habilidad5 { get; set; }
        public string habilidad6 { get; set; }
        public string calificacionFinal { get; set; }      
        public string comentario { get; set; }

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
        public string dominio { get; set; }
        public string convenio { get; set; }
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
        public bool? eliminado { get; set; }
        public List<PerformanceAutoevaluacionVM> habilidades { get; set; }
        public bool? tieneEncuesta { get; set; }
    }
    public class PerformanceEstados
    {
        public int id { get; set; }
        public string estado { get; set; }
    }
    public class PerformanceAnos
    {
        public int ano { get; set; }
       
    }
    public class ColaboradorVM
    {      
        public int idUsuario { get; set; }
        public Nullable<int> legajo { get; set; }
        public string nombre { get; set; }
        public DateTime? fechaNacimiento { get; set; }
        public Nullable<int> edad { get; set; }
        public string sexo { get; set; }
        public int antiguedad { get; set; }
        public string pais { get; set; }
        public string convenio { get; set; }
        public string dominio { get; set; }
        public string categoria { get; set; }
        public int idJefe { get; set; }
        public string nombreJefe { get; set; }
        public DateTime? fechaIngreso { get; set; }
    }
    public class PerformanceProgresoVM
    {
        public int totalPerformance { get; set; }
        public int totalPendiente { get; set; }
        public int totalCompletado { get; set; }
        public int totalEvaluado { get; set; }
        public int totalFeedback { get; set; }
        public int totalFinalizado { get; set; }      
        public decimal porcentajePendiente { get; set; }
        public decimal porcentajeCompletado { get; set; }
        public decimal porcentajeEvaluado { get; set; }
        public decimal porcentajeFeedback { get; set; }
        public decimal porcentajeFinalizado { get; set; }

    }
    public class DatosPerformanceVM
    {
        public Nullable<int> legajo { get; set; }
        public int idUsuario { get; set; }
        public string colaborador { get; set; }
        public Nullable<int> edad { get; set; }
        public string sexo { get; set; }
        public string pais { get; set; }
        public string convenio { get; set; }
        public string dominio { get; set; }
        public string categoria { get; set; }
        public string lider { get; set; }
        public int idPerformance { get; set; }
        public int idJefe { get; set; }
        public string nombreJefe { get; set; }
        public int ano { get; set; }
        public int? idEstado { get; set; }
        public string estado { get; set; }
        public int antiguedad { get; set; }
        public int? idHabilidadAutoevaluacion { get; set; }
        public int? idCalificacionAutoevaluacion { get; set; }
        public DateTime? fechaCalificacionAutoevaluacion { get; set; }       
        public int? idHabilidadEvaluacion { get; set; }
        public int? idCalificacionEvaluacion { get; set; }
        public DateTime? fechaCalificacionEvaluacion { get; set; }
        public DateTime? fechaCalibracion { get; set; }
        public DateTime? fechaFeedback { get; set; }
        public string nombreHabilidadAutoevaluacion { get; set; }
        public string calificacionAutoevaluacion { get; set; }
        public string nombreHabilidadEvaluacion { get; set; }
        public string calificacionEvaluacion { get; set; }
        public int? idCalificacionFinal {  get; set; }
        public string calificacionFinal { get; set; }
        public string comentario { get; set; }
        public string calificacionFinalAntes { get; set; }

        //COSAS DE AUTOEVALUACION
        public int idAutoevaluacion { get; set; }
        public int? idHabilidad { get; set; }
        public string habilidad { get; set; }
        public int? idCalificacion { get; set; }
        public string calificacion { get; set; }
        public List<int?> autoEvaluaciones { get; set; }
        public List<int?> evaluaciones { get; set; }

        //ENCUESTA
        public int? feedback { get; set; }
        public int? calidad { get; set; }
        public DateTime? fechaEncuesta { get; set; }
        public string comentarioEncuesta { get; set; }
    }

    public class DatosGeneralPerformanceVM
    {
        public List<DatosPerformanceVM> listDatosPerformance { get; set; }
        public int? idCalificacionFinal { get; set; }
        public string calificacionFinal { get; set; }
    }

    public class HistorialVM
    {
        public int idHistorial { get; set; }
        public int idPerformance { get; set; }
        public int? estado { get; set; }
        public string estadoStr { get; set; }
        public int? idUsuarioCambio { get; set; }
        public bool? autoevaluacion { get; set; }
        public bool? evaluacion { get; set; }
        public bool? calibracion { get; set; }
        public bool? eliminado { get; set; }
        public int? idHabilidad { get; set; }
        public int? idCalificacion { get; set; }
        public int? idCalificacionFinal { get; set; }
        public string comentario { get; set; }
        public DateTime fechaCambio { get; set; }
        public DateTime? fechaOriginal { get; set; }
        public DateTime? fechaPerformance { get; set; }
        public string nombreUsuario { get; set; }

    }
    public class MailVM
    {
        public List<int> IdsDestinatarios { get; set; }
        public string mensaje { get; set; }
        public string asunto { get; set; }
        public string adjunto { get; set; }
    }
    public class PDIMetasVM
    {
        public int idUsuario { get; set; }
        public string colaborador { get; set; }
        public int idJefe { get; set; }
        public string lider { get; set; }
        public string dominio { get; set; }
        public int idMeta { get; set; }
        public Nullable<int> idPDI { get; set; }
        public Nullable<int> tipoAccion { get; set; }
        public string nombreTipoAccion { get; set; }
        public Nullable<int> habilidad { get; set; }
        public string nombreHabilidad { get; set; }
        public string metaTitulo { get; set; }
        public string metaDescripcion { get; set; }
        public Nullable<System.DateTime> fechaDesde { get; set; }
        public Nullable<System.DateTime> fechaHasta { get; set; }
        public Nullable<int> status { get; set; }
        public string nombreStatus { get; set; }
        public string accionesRealizadas { get; set; }
    }
    public class StatusVM
    {
        public int idStatus { get; set; }
        public string nombre { get; set; }
    }
    public class TipoAccionVM
    {
        public int idTipoAccion { get; set; }
        public string nombre { get; set; }
    }
    public class HabilidadesVM
    {
        public int idHabilidad { get; set; }
        public string habilidad { get; set; }
        public Nullable<bool> activo { get; set; }
    }
    public class EncuestasVM
    {
        public int idEncuesta{ get; set; }
        public int idUsuario { get; set; }
        public int idPerformance { get; set; }
        public int feedback { get; set; }
        public Nullable<int> calidad { get; set; }
        public string comentario { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public string nombreUsuario { get; set; }
    }
}
