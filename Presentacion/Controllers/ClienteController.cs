using Presentacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentacion.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult getClientes(int pOpcion, string pParametro)
        {
            return Content(new ContentResult
            {
                Content = MvcApplication._Serialize(new Clientes().Consulta_Solicitud_Clientes(new Request_WF_Clientes
                {
                    pOpcion = pOpcion,
                    pParametro = pParametro
                })),
                ContentType = "application/json"
            }.Content);
        }
        public ActionResult Add_Solicitud_Cliente(int pOpcion, string pParametro)
        {
            return Content(new ContentResult
            {
                Content = MvcApplication._Serialize(new Clientes().Add_solicitud_Cliente(
                new Request_WF_Clientes()
                {
                    pOpcion = pOpcion,
                    pParametro = pParametro
                }
            )),
                ContentType = "application/json"
            }.Content);
        }
        public ActionResult Add_Solicitud_Bono(int pOpcion, string pParametro)
        {
            return Content(new ContentResult
            {
                Content = MvcApplication._Serialize(new Clientes().Add_solicitud_Bono(
                new Request_WF_Clientes()
                {
                    pOpcion = pOpcion,
                    pParametro = pParametro
                }
            )),
                ContentType = "application/json"
            }.Content);
        }
    }
}