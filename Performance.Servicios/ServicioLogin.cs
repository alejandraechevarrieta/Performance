using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Performance.Model;
using Performance.Servicios;
using System.Data;


using System.Web;

using System.Net.Http;




namespace Performance.Servicios
{
    public class ServicioLogin 
    {
        PerformanceEntities db = new PerformanceEntities();
       
        public int? ValidarIngreso(int idUsuario)
        {
            //var perfilesPerformance = _db.SegUsuarioPerfil.Where(x => x.idUsuario == idUsuario && (x.idPerfil == 117 || x.idPerfil == 118)).Select(x => x.idPerfil).ToList();

            //int? idPerfil = 0;            
            //if (perfilesPerformance != null)
            //{
            //    foreach(var perfil in perfilesPerformance)
            //    {
            //        idPerfil = perfil;
            //    }

            //    return idPerfil; 
            //}
            //else
            //{
            //return idPerfil;
            //    
            //}
            return 0;
        }

    }
}
