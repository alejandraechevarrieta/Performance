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
           
            return 0;
        }

    }
}
