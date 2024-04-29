using Performance.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
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
                           fechaFeedback = p.fechaEvaluacion, //cambiar
                           idEstado = p.estado,
                           estado = e.estado,
                       }).OrderByDescending(x => x.ano).ThenBy(x => x.nombre);
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
                var habilidades = db.Habilidades.Where(x => x.activo == true).ToList();

                AutoEvaluacion nuevaAutoevaluacion = new AutoEvaluacion();

                List<string> calificacion = new List<string>();
                calificacion.Add(autoevaluacion.habilidad1);
                calificacion.Add(autoevaluacion.habilidad2);
                calificacion.Add(autoevaluacion.habilidad3);
                calificacion.Add(autoevaluacion.habilidad4);
                calificacion.Add(autoevaluacion.habilidad5);
                calificacion.Add(autoevaluacion.habilidad6);

                //AutoEvaluacion
                var numero = 1; // Inicializar numero en 0

                foreach (var habilidad in habilidades)
                {
                    if (autoevaluacion != null)
                    {
                        nuevaAutoevaluacion.idPerformance = autoevaluacion.idPerformance;
                        nuevaAutoevaluacion.idHabilidad = habilidad.idHabilidad;
                        nuevaAutoevaluacion.fechaAutoEvaluacion = DateTime.Now;

                        // Obtener la calificación correspondiente a la habilidad actual
                        var habilidadIndex = habilidades.IndexOf(habilidad);
                        var item = calificacion.ElementAtOrDefault(habilidadIndex); // Obtener la calificación para la habilidad actual
                        if (item != null)
                        {
                            var idCalificacion = db.Calificacion
                                .Where(x => x.activo == true && x.formulario == "A" && x.nombre.Contains(item))
                                .Select(x => x.idCalificacion)
                                .FirstOrDefault();

                            if (idCalificacion != 0)
                            {
                                nuevaAutoevaluacion.idCalificacion = idCalificacion;

                                db.AutoEvaluacion.Add(nuevaAutoevaluacion);
                                db.SaveChanges();
                            }
                            else
                            {
                                // Manejar la situación donde no se encuentra una calificación para la habilidad actual
                            }
                        }
                    }
                }


                //Performance
                var performance = db.PerformanceColaborador.Where(x => x.idPerformance == autoevaluacion.idPerformance).FirstOrDefault();

                if (performance != null)
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

        public int GenerarAltasPerformance(List<ColaboradorVM> colaboradores)
        {
            try
            {
                
                var anoAnterior = DateTime.Now.Year - 1;
                int anoActual = DateTime.Now.Year;

                PerformanceColaborador nuevaPerformance = new PerformanceColaborador();

                foreach (var item in colaboradores)
                {
                    var existe = db.PerformanceColaborador.Where(x => x.ano == anoAnterior && x.idUsuario == item.idUsuario).FirstOrDefault();
                    if(existe == null)
                    {
                        nuevaPerformance.ano = anoAnterior;
                        nuevaPerformance.idUsuario = item.idUsuario;
                        nuevaPerformance.nombre = item.nombre;
                        nuevaPerformance.idJefe = item.idJefe;
                        nuevaPerformance.nombreJefe = item.nombreJefe;
                        nuevaPerformance.estado = 1;

                        //calculo antiguedad
                        int anoIngreso = item.fechaIngreso.Value.Year;
                        int antiguedad= Math.Abs(anoActual - anoIngreso);
                        nuevaPerformance.antiguedad = antiguedad;
                        
                        db.PerformanceColaborador.Add(nuevaPerformance);
                        db.SaveChanges();
                    }                  
                }

                return anoAnterior;
            }
            catch (Exception e)
            {
                var ex = e.GetBaseException();
                return 0;
            }
        }

    }
}
