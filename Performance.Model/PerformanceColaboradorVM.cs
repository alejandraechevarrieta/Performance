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
        public int idAutoevaluacion { get; set; }
        public int idPerformance { get; set; }
        public int idHabilidad { get; set; }
        public int idCalificacion { get; set; }
        public DateTime fechaCalificacion { get; set; }
    }
}
