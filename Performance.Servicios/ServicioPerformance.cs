using Performance.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Performance.Servicios
{
    public class ServicioPerformance : IDisposable
    {
        private readonly PerformanceEntities db;

        public ServicioPerformance()
        {
            db = new PerformanceEntities(); 
        }

        public List<PerformanceColaboradorVM> listarColaboradores(int? idUsuario)
        {
            var query = (from d in db.PerformanceColaborador
                         select new PerformanceColaboradorVM
                         {
                             idPerformance = d.idPerformance,
                             idUsuario = d.idUsuario,
                             nombre = d.nombre,
                             ano = d.ano,
                             antiguedad = d.antiguedad,
                             idJefe = d.idJefe,
                         }).ToList();
            query = query.Where(x => x.idUsuario == idUsuario).ToList();
            return query;
        }

        public IQueryable<PerformanceVM> ListarPerformanceTodas()
        {
            var tmp = (from p in db.PerformanceColaborador                       
                       select new PerformanceVM
                       {
                           ano = p.ano,
                           idPerformance = p.idPerformance,
                           idUsuario = p.idUsuario,
                           nombre = p.nombre,
                           idJefe = p.idJefe,
                           antiguedad = p.antiguedad,
                           fechaAutoevaluacion = null, // Asignar null a las fechas
                           fechaEvaluacion = null,
                           fechaCalibracion = null,
                           estado = 1
                           //fechaCalificacion = p.fechaCalificacion,
                           //fechaAutoevaluacion = p.fechaAutoevaluacion,
                           //fechaCalibracion = p.fechaCalibracion,
                       }).OrderByDescending(x => x.ano);

            return tmp;
        }

        public List<PerformanceVM> listarPerformance(int? colaborador, int? estado, string idPerfil)
        {
            var listaPpal = ListarPerformanceTodas().ToList();

            if (colaborador != null)
            {
                listaPpal = listaPpal.Where(p => p.idUsuario == colaborador).ToList();
            }

          

            return listaPpal;
        }

        public void Dispose()
        {
            db.Dispose(); // Liberar recursos del contexto de la base de datos
        }

        public List<PerformanceEstados> listarEstadosPerformance()
        {
            using (var db = new PerformanceEntities())
            {
                var query = (from d in db.PerformanceColaborador
                             select new PerformanceEstados
                             {
                                 id = d.idPerformance,
                                 estado = d.nombre,
                             });
                return query.ToList();
            }
        }

    }
}
