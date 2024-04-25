using Performance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

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
                           nombreJefe = p.nombreJefe,
                           antiguedad = p.antiguedad,
                           fechaAutoevaluacion = p.fechaAutoevaluacion, 
                           fechaEvaluacion = p.fechaEvaluacion,
                           fechaCalibracion = p.fechaCalibracion,
                           idEstado = p.estado,
                           estado = e.estado,                           
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
                    listaPpal = listaPpal.Where(p => p.idUsuario == colaborador).ToList();
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
        public int GuardarAutoevaluacion(PerformanceAutoevaluacionVM autoevaluacion)
        {
            try
            {
                var habilidad1 = db.Habilidades.Where(x => x.idHabilidad == 1).FirstOrDefault();
                var habilidad2 = db.Habilidades.Where(x => x.idHabilidad == 2).FirstOrDefault();
                var habilidad3 = db.Habilidades.Where(x => x.idHabilidad == 3).FirstOrDefault();
                var habilidad4 = db.Habilidades.Where(x => x.idHabilidad == 4).FirstOrDefault();
                var habilidad5 = db.Habilidades.Where(x => x.idHabilidad == 5).FirstOrDefault();
                var habilidad6 = db.Habilidades.Where(x => x.idHabilidad == 6).FirstOrDefault();

                AutoEvaluacion nuevaAutoevaluacion = new AutoEvaluacion();
               
                //AutoEvaluacion
                if(autoevaluacion != null)
                {
                    if(autoevaluacion.habilidad1 != null)
                    {
                        nuevaAutoevaluacion.idPerformance = autoevaluacion.idPerformance;
                        nuevaAutoevaluacion.idHabilidad = habilidad1.idHabilidad;
                        nuevaAutoevaluacion.fechaAutoEvaluacion = DateTime.Now;
                        db.AutoEvaluacion.Add(nuevaAutoevaluacion);
                        db.SaveChanges();
                    }
                    if (autoevaluacion.habilidad2 != null)
                    {
                        nuevaAutoevaluacion.idPerformance = autoevaluacion.idPerformance;
                        nuevaAutoevaluacion.idHabilidad = habilidad2.idHabilidad;
                        nuevaAutoevaluacion.fechaAutoEvaluacion = DateTime.Now;
                        db.AutoEvaluacion.Add(nuevaAutoevaluacion);
                        db.SaveChanges();
                    }
                    if (autoevaluacion.habilidad3 != null)
                    {
                        nuevaAutoevaluacion.idPerformance = autoevaluacion.idPerformance;
                        nuevaAutoevaluacion.idHabilidad = habilidad3.idHabilidad;
                        nuevaAutoevaluacion.fechaAutoEvaluacion = DateTime.Now;
                        db.AutoEvaluacion.Add(nuevaAutoevaluacion);
                        db.SaveChanges();
                    }
                    if (autoevaluacion.habilidad4 != null)
                    {
                        nuevaAutoevaluacion.idPerformance = autoevaluacion.idPerformance;
                        nuevaAutoevaluacion.idHabilidad = habilidad4.idHabilidad;
                        nuevaAutoevaluacion.fechaAutoEvaluacion = DateTime.Now;
                        db.AutoEvaluacion.Add(nuevaAutoevaluacion);
                        db.SaveChanges();
                    }
                    if (autoevaluacion.habilidad5 != null)
                    {
                        nuevaAutoevaluacion.idPerformance = autoevaluacion.idPerformance;
                        nuevaAutoevaluacion.idHabilidad = habilidad5.idHabilidad;
                        nuevaAutoevaluacion.fechaAutoEvaluacion = DateTime.Now;
                        db.AutoEvaluacion.Add(nuevaAutoevaluacion);
                        db.SaveChanges();
                    }
                    if (autoevaluacion.habilidad6 != null)
                    {
                        nuevaAutoevaluacion.idPerformance = autoevaluacion.idPerformance;
                        nuevaAutoevaluacion.idHabilidad = habilidad6.idHabilidad;
                        nuevaAutoevaluacion.fechaAutoEvaluacion = DateTime.Now;
                        db.AutoEvaluacion.Add(nuevaAutoevaluacion);
                        db.SaveChanges();
                    }
                   
                }    

                //Performance
                var performance = db.PerformanceColaborador.Where(x => x.idPerformance == autoevaluacion.idPerformance).FirstOrDefault();
               
                if(performance != null)
                {
                    performance.estado = 2;
                    performance.fechaAutoevaluacion = DateTime.Now;

                    db.SaveChanges();
                }
               
             
                return nuevaAutoevaluacion.idPerformance;
            }
            catch (Exception e)
            {
                var ex = e.GetBaseException();
                return 0;
            }
        }

    }
}
