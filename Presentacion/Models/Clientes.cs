using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentacion.Models
{
    public class Clientes
    {
        public List<E_Clientes> Consulta_Solicitud_Clientes(Request_WF_Clientes oRq)
        {
            Response_FW_Consulta_solicitud oRp = MvcApplication._Deserialize<Response_FW_Consulta_solicitud>
                (MvcApplication._Servicio_Operativa.FW_Una_consulta_solicitud_clientes(MvcApplication._Serialize(oRq)));

            return oRp.Obj;
        }
        public string Add_solicitud_Cliente(Request_WF_Clientes oRq)
        {
            Response_FW_add_solicitud oRp;

            oRp = MvcApplication._Deserialize<Response_FW_add_solicitud>(MvcApplication._Servicio_Operativa.FW_Una_Add_Clientes(MvcApplication._Serialize(oRq)));

            return oRp.obj;
        }
        public string Add_solicitud_Bono(Request_WF_Clientes oRq)
        {
            Response_FW_add_solicitud oRp;

            oRp = MvcApplication._Deserialize<Response_FW_add_solicitud>(MvcApplication._Servicio_Operativa.FW_Una_Add_Bono(MvcApplication._Serialize(oRq)));

            return oRp.obj;
        }
    }

    public class Request_WF_Clientes
    {    
        [JsonProperty("_a")]
        public int pOpcion { get; set; }
        [JsonProperty("_b")]
        public string pParametro { get; set; }


    }
    public class E_Clientes
    {
        //IdCliente, DNI, Nombres, FechaNacimiento, SaldoDisponible, PuntosAcumulados, Estado
        [JsonProperty("_a")]
        public int IdCliente { get; set; }
        [JsonProperty("_b")]
        public int DNI { get; set; }
        [JsonProperty("_c")]
        public string Nombres { get; set; }
        [JsonProperty("_d")]
        public string FechaNacimiento { get; set; }
        [JsonProperty("_e")]
        public double SaldoDisponible { get; set; }
        [JsonProperty("_f")]
        public int PuntosAcumulados { get; set; }
        [JsonProperty("_g")]
        public int Estado { get; set; }
    }
    public class Response_FW_Consulta_solicitud
    {
        [JsonProperty("_a")]
        public List<E_Clientes> Obj { get; set; }
    }
    public class Response_FW_add_solicitud
    {
        [JsonProperty("_a")]
        public string obj { get; set; }
    }
}