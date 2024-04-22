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
                       join e in db.Estados on p.estado equals e.id
                       select new PerformanceVM
                       {
                           ano = p.ano,
                           idPerformance = p.idPerformance,
                           idUsuario = p.idUsuario,
                           nombre = p.nombre,
                           idJefe = p.idJefe,
                           nombreJefe = "nombre jefe",//Buscar forma de tener el nombre del jefe
                           antiguedad = p.antiguedad,
                           fechaAutoevaluacion = p.fechaAutoevaluacion, // Asignar null a las fechas
                           fechaEvaluacion = p.fechaEvaluacion,
                           fechaCalibracion = null,
                           idEstado = p.estado,
                           estado = e.estado,
                           //fechaCalificacion = p.fechaCalificacion,
                           //fechaAutoevaluacion = p.fechaAutoevaluacion,
                           //fechaCalibracion = p.fechaCalibracion,
                       }).OrderByDescending(x => x.ano);
            var algo = tmp.ToList();

            return tmp;
        }

        public List<PerformanceVM> listarPerformance(int? colaborador, int? estado, string idPerfil)
        {
            var listaPpal = ListarPerformanceTodas().ToList();

            if (colaborador != null)
            {
                if(idPerfil == "127")
                {
                    listaPpal = listaPpal.Where(p => p.idJefe == colaborador).ToList();
                }
                if(idPerfil == "128") {
                    listaPpal = listaPpal.Where(p => p.idJefe == colaborador).ToList();
                }
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
                var query = (from d in db.Estados
                             select new PerformanceEstados
                             {
                                 id = d.id,
                                 estado = d.estado,
                             });
                return query.ToList();
            }
        }

    }
}
