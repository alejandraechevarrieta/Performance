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

        public List<PerformanceVM> listarPerformance(string idUsuario, string idPerfil, int? colaborador, int? estado, int? lider)
        {
            var listaPpal = ListarPerformanceTodas().ToList();
            var idUsuarioInt = Convert.ToInt16(idUsuario);
            if (idPerfil != null)
            {
                if (idPerfil == "127")
                {
                    listaPpal = listaPpal.Where(p => p.idUsuario == idUsuarioInt).ToList();
                }
                if (idPerfil == "128")
                {
                    listaPpal = listaPpal.Where(p => p.idJefe == idUsuarioInt).ToList();
                }              
            }
            if (colaborador != null)
            {
                listaPpal = listaPpal.Where(p => p.idUsuario == colaborador).ToList();

            }
            if (estado != null)
            {
                listaPpal = listaPpal.Where(p => p.idEstado == estado).ToList();
            }
            if (lider != null)
            {
                listaPpal = listaPpal.Where(p => p.idJefe == lider).ToList();
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
        public List<ColaboradorVM> ListarColaboradores()
        {
            List<ColaboradorVM> lista = null;

            lista =
            (from d in db.PerformanceColaborador
             select new ColaboradorVM
             {
                 idUsuario = d.idUsuario,
                 nombre = d.nombre,
             }).Where(x => x.nombre != "").Distinct().ToList();

            return lista.OrderBy(x => x.nombre).ToList();
        }
        public List<ColaboradorVM> ListarLideres()
        {
            List<ColaboradorVM> lista = null;

            lista =
            (from d in db.PerformanceColaborador
             select new ColaboradorVM
             {
                 idUsuario = d.idJefe,
                 nombreJefe = d.nombreJefe,
             }).Where(x => x.nombreJefe != "").Distinct().ToList();

            return lista.OrderBy(x => x.nombreJefe).ToList();
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
        /// <summary>
        /// calulos progreso de estados 
        /// </summary>
        /// <returns></returns>
        public List<PerformanceProgresoVM> listarPerformanceProgreso()
        {
            var list = ListarPerformanceTodas();
            var anoAnterior = DateTime.Now.Year - 1;
            var tmp = list.Where(x => x.ano == anoAnterior).ToList();
            var totalPerformance = 0;
            var totalPendiente= 0;
            var totalCompletado = 0;
            var totalEvaluado = 0;
            var totalFeedback = 0;
            var totalFinalizado = 0;
            decimal porcentajePendiente = 0;
            decimal porcentajeCompletado = 0;
            decimal porcentajeEvaluado = 0;
            decimal porcentajeFeedback = 0;
            decimal porcentajeFinalizado = 0;

            foreach (var item in tmp)
            {
                totalPerformance++;
                if (item.idEstado == 1)
                    totalPendiente++;
                else if (item.idEstado == 2)
                    totalCompletado++;
                else if (item.idEstado == 3)
                    totalEvaluado++;
                else if (item.idEstado == 4)
                    totalFeedback++;
                else if (item.idEstado == 5)
                    totalFinalizado++;
            }
            
            if (totalPerformance > 0)
            {
                porcentajePendiente = (decimal)totalPendiente / totalPerformance * 100;
                porcentajeCompletado = (decimal)totalCompletado / totalPerformance * 100;
                porcentajeEvaluado = (decimal)totalEvaluado / totalPerformance * 100;
                porcentajeFeedback = (decimal)totalFeedback / totalPerformance * 100;
                porcentajeFinalizado = (decimal)totalFinalizado / totalPerformance * 100;
            }

            var lista = new List<PerformanceProgresoVM>();
           
            lista.Add(new PerformanceProgresoVM
            {                
                totalPerformance = totalPerformance,
                totalPendiente = totalPendiente,
                totalCompletado = totalCompletado,
                totalEvaluado = totalEvaluado,
                totalFeedback = totalFeedback,
                totalFinalizado = totalFinalizado,
                porcentajePendiente = porcentajePendiente,
                porcentajeCompletado = porcentajeCompletado,
                porcentajeEvaluado = porcentajeEvaluado,
                porcentajeFeedback = porcentajeFeedback,
                porcentajeFinalizado = porcentajeFinalizado
            });
            
            return lista;
        }
        public List<DatosPerformanceVM> buscarDatosPerformance(int idPerformance)
        {
            var datosPerformance = (
    from p in db.PerformanceColaborador
    join a in db.AutoEvaluacion on p.idPerformance equals a.idPerformance
    join ha in db.Habilidades on a.idHabilidad equals ha.idHabilidad
    join ca in db.Calificacion on a.idCalificacion equals ca.idCalificacion
    where p.idPerformance == idPerformance
    select new DatosPerformanceVM
    {       
        idHabilidadAutoevaluacion = ha.idHabilidad,
        idCalificacionAutoevaluacion = ca.idCalificacion,
        fechaCalificacionAutoevaluacion = a.fechaAutoEvaluacion,
        nombreHabilidadAutoevaluacion = ha.habilidad,
        calificacionAutoevaluacion = ca.nombre,
        idHabilidadEvaluacion = null,
        idCalificacionEvaluacion = null,
        fechaCalificacionEvaluacion = null,
        nombreHabilidadEvaluacion = null,
        calificacionEvaluacion = null,
        ano = p.ano,
        colaborador = p.nombre,
        lider = p.nombreJefe,
    }
).ToList();

            var evaluaciones = (
                from a in db.EvaluacionPerformance
                join he in db.Habilidades on a.idHabilidad equals he.idHabilidad into habilidadesEvaluacion
                from he in habilidadesEvaluacion.DefaultIfEmpty()
                join ce in db.Calificacion on a.idCalificacion equals ce.idCalificacion into calificacionesEvaluacion
                from ce in calificacionesEvaluacion.DefaultIfEmpty()
                where a.idPerformance == idPerformance
                select new DatosPerformanceVM
                {
                    idHabilidadAutoevaluacion = null,
                    idCalificacionAutoevaluacion = null,
                    fechaCalificacionAutoevaluacion = null,
                    nombreHabilidadAutoevaluacion = null,
                    calificacionAutoevaluacion = null,
                    idHabilidadEvaluacion = he.idHabilidad,
                    idCalificacionEvaluacion = ce.idCalificacion,
                    fechaCalificacionEvaluacion = a.fechaEvaluacion,
                    nombreHabilidadEvaluacion = he.habilidad,
                    calificacionEvaluacion = ce.nombre,                   

                }
            ).ToList();
            var datos = (
   from p in db.PerformanceColaborador  
   where p.idPerformance == idPerformance
   select new DatosPerformanceVM
   {       
       ano = p.ano,
       colaborador = p.nombre,
       lider = p.nombreJefe,
   }
).ToList();
            datosPerformance.AddRange(evaluaciones);
            datosPerformance.AddRange(datos);

            return datosPerformance;
        }

    }
}
