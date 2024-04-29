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
        public int idHabilidad { get; set; }
        public int idCalificacion { get; set; }
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
}
