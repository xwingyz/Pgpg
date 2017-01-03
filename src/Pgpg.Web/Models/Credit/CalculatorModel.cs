using Pgpg.Credit.Service;

namespace Pgpg.Web.Models.Credit
{
    public class CalculatorModel
    {
        public RepaymentWay RepaymentWay { get; set; } = RepaymentWay.等额本息;
        public decimal Principal { get; set; } = 100000;
        public decimal Rate { get; set; } = 10;
        public DateType DeadlineType { get; set; } = DateType.月;
        public int Deadline { get; set; } = 12;
    }
}
