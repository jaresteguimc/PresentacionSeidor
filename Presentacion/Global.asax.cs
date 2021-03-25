using Newtonsoft.Json;
using Presentacion.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Presentacion
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static Ges_OperativaServiceClient _Servicio_Operativa;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            _Servicio_Operativa = new Ges_OperativaServiceClient("BasicHttpBinding_IGes_OperativaService");
        }
        public static string _Serialize(object value)
        {
            return JsonConvert.SerializeObject(value, new JsonSerializerSettings() { MaxDepth = Int32.MaxValue });
        }

   
        public static T _Deserialize<T>(string value)
        {
            T obj = Activator.CreateInstance<T>();
            obj = JsonConvert.DeserializeObject<T>(value);
            return obj;
        }
    }
}
