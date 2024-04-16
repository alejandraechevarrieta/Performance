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
        //PerformanceEntities

    }
}
