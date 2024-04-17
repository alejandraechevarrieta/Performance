using Performance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performance.Servicios
{
    public class ServicioPerformance
    {
        public List<PerformanceColaboradorVM> listarColaboradores(int idUsuario)
        {
            using (var db = new PerformanceEntities())
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
                query = query.Where(x => x.idJefe == idUsuario).ToList();
                return query;
            }
        }
        public IQueryable<PerformanceVM> ListarPerformanceTodas()
        {
            using (var db = new PerformanceEntities())
            {
                var tmp = (from p in db.PerformanceColaborador
                           orderby p.ano
                           join a in db.AutoEvaluacion on p.idPerformance equals a.idPerformance
                           join e in db.EvaluacionPerformance on p.idPerformance equals e.idPerformance
                           //join c in db.CalibracionPerformance on p.idPerformance equals c.idPerformance  

                           select new PerformanceVM
                           {
                               ano = p.ano,
                               idPerformance = p.idPerformance,
                               nombre = p.nombre,
                               idJefe = p.idJefe,
                               fechaCalificacion = a.fechaCalificacion,
                               //fechaEvaluacion = e.fechaEvaluacion                              
                           }).OrderByDescending(x => x.ano);
                //var algo = tmp.ToList();
                var temp = (IQueryable<PerformanceVM>)tmp;
                temp = temp.Union(temp);
                
                return temp;
            }    
        }
        public List<PerformanceVM> ListarPerformance(string filtro, string orden, string direccion, int? colaborador, int? estado, int? tarjeta,
            int? idUsuario, string idPerfil, int? tab, DateTime? fechaDesde, DateTime? fechaHasta, int? pais)
        {          

            Servicios.ServicioPerformance servicio = new Servicios.ServicioPerformance();

            var tmp = servicio.ListarPerformanceTodas();

            //var algo3 = tmp.ToList();
            //if (fechaDesde != null)
            //{
            //    tmp = tmp.Where(x => x.FechaSolicitud >= fechaDesde);
            //}
            //if (fechaHasta != null)
            //{
            //    tmp = tmp.Where(x => x.FechaSolicitud <= fechaHasta);
            //}
            //if (idPerfil != null)
            //{
            //    if (idPerfil == "116") // Basico
            //    {
            //        tmp = tmp.Where(py => py.idUsuario == idUsuario || py.idUsuarioSeguidor == idUsuario).OrderByDescending(x => x.idSolicitudViaje);
            //    }
            //    else if (idPerfil == "117") //Autorizante
            //    {
            //        tmp = tmp.Where(py => py.idUsuario == idUsuario || py.viajeRequeridoPor == idUsuario || py.idUsuarioSeguidor == idUsuario).OrderByDescending(x => x.idSolicitudViaje);
            //    }
            //    else if (idPerfil == "118") //Pagador
            //    {
            //        if (tab == 1)          // si selecciona pagos
            //        {
            //            tmp = tmp.Where(x => x.requiereViatico == true && (x.estado == 2 || x.estado >= 4));
            //        }
            //        else
            //        {
            //            tmp = tmp.Where(py => py.idUsuario == idUsuario || py.idUsuarioSeguidor == idUsuario).OrderByDescending(x => x.idSolicitudViaje);
            //        }

            //    }
            //    else if (idPerfil == "1") //Admin
            //    {
            //        if (tab == 1)          // si selecciona pagos
            //        {
            //            tmp = tmp.Where(x => x.requiereViatico == true && (x.estado == 2 || x.estado >= 4));
            //        }
            //    }
            //    else if (idPerfil == "119")
            //    {
            //        tmp = tmp.Where(py => py.idUsuario == idUsuario || py.idUsuarioSeguidor == idUsuario).OrderByDescending(x => x.idSolicitudViaje);
            //    }
            //    else if (idPerfil == "126")
            //    {
            //        tmp = tmp.Where(x => (x.requiereAlojamiento == true || x.requiereMovilidad == true) && (x.estado != 3 && x.estado != 1)).OrderByDescending(x => x.idSolicitudViaje);
            //    }
            //}


            ////aca

            var temp = (IQueryable<PerformanceVM>)tmp;
            ////temp = temp.Union(temp);
            ////var algo2 = tmp.ToList();


            ////Filtros
            //if (pais != null && pais != 0)
            //{
            //    temp = temp.Where(x => x.destino == pais);
            //}
            //if (colaborador != null)
            //{
            //    temp = temp.Where(x => x.idUsuario == colaborador);
            //    //algo = temp.ToList();
            //}
            //if (estado != null && estado != 0)
            //{
            //    if (estado == 1)           //pendientes
            //    {
            //        if (idPerfil == "118")
            //        {
            //            if (tab == 1)
            //            {
            //                temp = temp.Where(x => x.estado == 1 && x.estadoAjuste != 1 && x.estadoAjuste != 2 && DateTime.Today < x.fechaPago);
            //            }
            //            if (tab == 0)
            //            {
            //                temp = temp.Where(x => x.estado == 1 && x.estadoAjuste != 1 && x.estadoAjuste != 2);
            //            }
            //        }
            //        else if (idPerfil == "117" || idPerfil == "116" || idPerfil == "119" || idPerfil == "126")
            //        {
            //            temp = temp.Where(x => x.estado == 1 && x.estadoAjuste != 1 && x.estadoAjuste != 2);
            //        }
            //        else if (idPerfil == "1")
            //        {
            //            temp = temp.Where(x => x.estado == 1 && x.estadoAjuste != 1 && x.estadoAjuste != 2);
            //        }
            //    }
            //    if (estado == 2)           //aprobadas
            //    {
            //        if (idPerfil == "118")
            //        {
            //            if (tab == 1)
            //            {
            //                temp = temp.Where(x => x.estado == 2 && x.estadoAjuste != 1 && x.estadoAjuste != 2 && DateTime.Today < x.fechaPago);
            //            }
            //            if (tab == 0)
            //            {
            //                temp = temp.Where(x => x.estado == 2 && x.estadoAjuste != 1 && x.estadoAjuste != 2);
            //            }
            //        }
            //        else if (idPerfil == "117" || idPerfil == "116" || idPerfil == "119" || idPerfil == "126")
            //        {
            //            temp = temp.Where(x => x.estado == 2 && x.estadoAjuste != 1 && x.estadoAjuste != 2);
            //        }
            //        else if (idPerfil == "1")
            //        {
            //            temp = temp.Where(x => x.estado == 2 && x.estadoAjuste != 1 && x.estadoAjuste != 2);
            //        }
            //    }
            //    if (estado == 3)           //rechazada
            //    {
            //        temp = temp.Where(x => x.estado == 3);
            //    }
            //    if (estado == 4)           //a rendir (pagadas)
            //    {
            //        temp = temp.Where(x => x.estado == 4 && x.requiereViatico == true);
            //    }
            //    if (estado == 5)           //rendidos (rendición cerrada)
            //    {
            //        temp = temp.Where(x => x.estado == 5 && x.requiereViatico == true);
            //    }
            //    if (estado == 6)           //rendicion preaprobada
            //    {
            //        temp = temp.Where(x => x.estado == 7 && x.requiereViatico == true);
            //    }
            //    if (estado == 7)           //finalizada
            //    {
            //        temp = temp.Where(x => x.estado == 8);
            //    }
            //    if (estado == 10)           //a pagar (aprobadas)
            //    {
            //        temp = temp.Where(x => x.estado == 2 && x.requiereViatico == true);
            //    }
            //    if (estado == 11)           //pagadas
            //    {
            //        temp = temp.Where(x => x.estado == 4 && x.requiereViatico == true);
            //    }
            //}
            //var algo = temp.ToList();
            ////Tarjetas
            //if (tarjeta == 1)           //pendientes
            //{
            //    if (idPerfil == "118")
            //    {
            //        if (tab == 1)
            //        {
            //            temp = temp.Where(x => x.estado == 1 && x.estadoAjuste != 1 && x.estadoAjuste != 2 && DateTime.Today < x.fechaPago);
            //        }
            //        if (tab == 0)
            //        {
            //            temp = temp.Where(x => x.estado == 1 && x.estadoAjuste != 1 && x.estadoAjuste != 2);
            //        }

            //    }
            //    else if (idPerfil == "117" || idPerfil == "116" || idPerfil == "119" || idPerfil == "126")
            //    {
            //        temp = temp.Where(x => x.estado == 1 && x.estadoAjuste != 1 && x.estadoAjuste != 2);
            //    }
            //    else if (idPerfil == "1")
            //    {
            //        temp = temp.Where(x => x.estado == 1 && x.estadoAjuste != 1 && x.estadoAjuste != 2);
            //    }
            //}
            //if (tarjeta == 2)           //aprobadas
            //{
            //    if (idPerfil == "118")
            //    {
            //        if (tab == 1)
            //        {
            //            temp = temp.Where(x => x.estado == 2 && x.estadoAjuste != 1 && x.estadoAjuste != 2 && DateTime.Today < x.fechaPago);
            //        }
            //        if (tab == 0)
            //        {
            //            temp = temp.Where(x => x.estado == 2 && x.estadoAjuste != 1 && x.estadoAjuste != 2);
            //        }

            //    }
            //    else if (idPerfil == "117" || idPerfil == "116" || idPerfil == "119" || idPerfil == "126")
            //    {
            //        temp = temp.Where(x => x.estado == 2 && x.estadoAjuste != 1 && x.estadoAjuste != 2);
            //    }
            //    else if (idPerfil == "1")
            //    {
            //        temp = temp.Where(x => x.estado == 2 && x.estadoAjuste != 1 && x.estadoAjuste != 2);
            //    }
            //}
            //if (tarjeta == 3)           //a rendir (pagadas)
            //{
            //    temp = temp.Where(x => x.estado == 4 && x.requiereViatico == true);
            //}
            //if (tarjeta == 4)           //rendido (pagadas)
            //{
            //    temp = temp.Where(x => (x.estado == 5 || x.estado == 7) && x.requiereViatico == true);
            //}
            //if (tarjeta == 5)           //rendidos (rendición finalizada)
            //{
            //    temp = temp.Where(x => x.estado == 8 && x.requiereViatico == true);
            //}
            //if (tarjeta == 10)           //a pagar (aprobadas)
            //{
            //    temp = temp.Where(x => x.estado == 2 && x.requiereViatico == true);
            //}
            //if (tarjeta == 11)           //pagadas
            //{
            //    temp = temp.Where(x => x.estado >= 4 && x.requiereViatico == true);
            //}
            ////filtro
            //if ((filtro != "") && !(string.IsNullOrEmpty(filtro)))
            //{
            //    temp = temp.Where(x => x.nombreSolicitante.Contains(filtro));
            //}
            ////orden
            ////var t = temp.ToList();
            //if (orden != null)
            //{
            //    if (direccion == "desc")
            //    {
            //        switch (orden)
            //        {
            //            case "FechaSolicitud":
            //                temp = temp.OrderBy(x => x.FechaSolicitud);
            //                break;
            //            case "FechaDesde":
            //                temp = temp.OrderBy(x => x.FechaDesde);
            //                break;
            //            case "FechaHasta":
            //                temp = temp.OrderBy(x => x.FechaHasta);
            //                break;
            //            case "colaborador":
            //                temp = temp.OrderBy(x => x.colaborador);
            //                break;
            //            case "estado":
            //                temp = temp.OrderBy(x => x.estado);
            //                break;
            //        }
            //    }
            //    else
            //    {
            //        switch (orden)
            //        {
            //            case "FechaSolicitud":
            //                temp = temp.OrderByDescending(x => x.FechaSolicitud);
            //                break;
            //            case "FechaDesde":
            //                temp = temp.OrderByDescending(x => x.FechaDesde);
            //                break;
            //            case "FechaHasta":
            //                temp = temp.OrderByDescending(x => x.FechaHasta);
            //                break;
            //            case "colaborador":
            //                temp = temp.OrderByDescending(x => x.colaborador);
            //                break;
            //            case "estado":
            //                temp = temp.OrderByDescending(x => x.estado);
            //                break;
            //        }
            //    }
            //}
            //else
            //{
            //    temp = temp.OrderByDescending(x => x.FechaSolicitud);
            //}
            var lista = temp.ToList();
            //lista = lista.Where(x => x.idSolicitudViaje > 0).Distinct().ToList();
            //foreach (var item in lista)
            //{
            //    item.contadorAprobadas = algo.Where(x => x.estado == 2).Count();
            //    item.contadorFinalizadas = algo.Where(x => x.estado == 8 && x.requiereViatico == true).Count();
            //    item.contadorPagadas = algo.Where(x => x.estado == 4).Count();
            //    item.contadorPagar = algo.Where(x => x.estado == 2).Count();
            //    item.contadorPendientes = algo.Where(x => x.estado == 1).Count();
            //    item.contadorRendidas = algo.Where(x => (x.estado == 5 || x.estado == 7) && x.requiereViatico == true).Count();
            //    item.contadorRendir = algo.Where(x => x.estado == 4 && x.requiereViatico == true).Count();
            //}
            //foreach (var item in lista)
            //{
            //    item.requiereCamioneta = false;
            //    var unaMovilidad = _db.ViaMovilidad.Where(x => x.idSolicitudViaje == item.idSolicitudViaje).FirstOrDefault();
            //    var unaMoviliadCamioneta = _db.ViaMovilidad.Where(x => x.idSolicitudViaje == item.idSolicitudViaje && x.transporte == 3).FirstOrDefault();
            //    var unaMoviliadBusAereo = _db.ViaMovilidad.Where(x => x.idSolicitudViaje == item.idSolicitudViaje && (x.transporte == 1 || x.transporte == 2)).FirstOrDefault();
            //    if (unaMovilidad != null)
            //    {
            //        if (unaMovilidad.camioneta == true)
            //        {
            //            item.requiereCamioneta = true;
            //        }
            //    }
            //    if (unaMoviliadCamioneta != null)
            //    {
            //        item.requiereCamioneta = true;
            //    }
            //    if (unaMoviliadBusAereo == null)
            //    {
            //        item.requiereMovilidad = false;
            //    }
            //}
            return lista;
        }

    }
}
