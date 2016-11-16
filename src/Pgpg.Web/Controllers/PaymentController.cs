using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pgpg.Application.Payment;

namespace Pgpg.Web.Controllers
{
    public class PaymentController : PgpgControllerBase
    {
        private IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public ActionResult Index()
        {
            ViewBag.Payments = string.Join(",", _paymentService.LoadActivePaymentMethods().Select(p => p.PaymentChannel));
            ViewBag.Alipay = _paymentService.LoadPaymentMethodBySystemName("Alipay").PaymentChannel;
            ViewBag.WeChat = _paymentService.LoadPaymentMethodBySystemName("WeChat").PaymentChannel;
            return View();
        }

        public ActionResult Notity()
        {
            return Content("Success");
        }
    }
}
