using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Pgpg.Credit.Dto;
using Pgpg.Credit.Service;
using Pgpg.Web.Models.Credit;
using Pgpg.Web.Utils;

namespace Pgpg.Web.Controllers
{
    public class CreditController : PgpgControllerBase
    {
        private readonly ICalculatorService _calculatorService;

        public CreditController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        [HttpGet]
        public ActionResult Calculator()
        {
            List<CreditRepaymentPlanDto> list = new List<CreditRepaymentPlanDto>();
            ViewBag.CalculatorModel = new CalculatorModel();
            return View(list);
        }

        [HttpPost]
        public ActionResult Calculator(CalculatorModel model)
        {
            DateTime startTime = DateTime.Now.Date;
            DateTime repaymentOverDate = model.DeadlineType == DateType.天
                ? startTime.AddDays(model.Deadline)
                : startTime.AddMonths(model.Deadline);
            List<CreditRepaymentPlanDto> list = _calculatorService.CalculationIncome(model.RepaymentWay, startTime,
                repaymentOverDate, model.Principal, (model.Rate) / 100);
            ViewBag.CalculatorModel = model;
            return View(list);
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}