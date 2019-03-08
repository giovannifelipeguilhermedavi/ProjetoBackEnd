using Projeto.Dominio.Abstract;
using Projeto.Dominio.CartaoFactory;
using Projeto.Dominio.CartaoFactorys;
using Projeto.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AplicacaoCartao.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Index()
        {
            CarregaCombo();

            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            CarregaCombo();
            string NumeroCartao = collection["numeroCartao"];
            if (!string.IsNullOrEmpty(NumeroCartao))
            {


                string Bandeira = collection["Bandeira"];
                FactoryCartao cartaoFactory = null;

                switch (Bandeira.ToUpper())
                {
                    case "AMEX":
                        cartaoFactory = new CartaoAmexFactory(NumeroCartao, Bandeira);
                        break;
                    case "DISCOVER":    
                        cartaoFactory = new CartaoDiscoveryFactory(NumeroCartao, Bandeira);
                        break;
                    case "MASTERCARD":
                        cartaoFactory = new CartaoMasterCardFactory(NumeroCartao, Bandeira);
                        break;
                    case "VISA":
                        cartaoFactory = new CartaoVisaFactory(NumeroCartao, Bandeira);
                        break;
                    default:
                        ViewBag.Cartao = "Desconhecido: " + NumeroCartao + " (inválido)";
                        break;
                }
                if (cartaoFactory != null)
                {
                    Cartao cartao = cartaoFactory.GetCartao();

                    if (cartao.ValidarBandeira())
                    {
                        if (cartao.validarCartao())
                        {
                            ViewBag.Cartao = cartao.TipoCartao + ":" + NumeroCartao + " (válido)";
                        }
                        else
                        {
                            ViewBag.Cartao = cartao.TipoCartao + ":" + NumeroCartao + " (inválido)";
                        }
                    }
                    else
                    {
                        ViewBag.Cartao = cartao.TipoCartao + ":" + NumeroCartao + " (inválido)";
                    }
                    return View();
                }
                else
                {                    
                    return View();
                }
            }
            else
            {
                ViewBag.Cartao = "informe número do cartão";
                return View();
            }
        }
        private void CarregaCombo()
        {
            List<SelectListItem> bandeiras = new List<SelectListItem>();
            bandeiras.Add(new SelectListItem { Text = "AMEX", Value = "1" });
            bandeiras.Add(new SelectListItem { Text = "DISCOVER", Value = "2" });
            bandeiras.Add(new SelectListItem { Text = "MASTERCARD", Value = "3" });
            bandeiras.Add(new SelectListItem { Text = "VISA", Value = "4" });
            ViewBag.Bandeiras = bandeiras;
        }
    }
}