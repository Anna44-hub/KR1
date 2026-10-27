using System;
using System.Collections.Generic;
using System.Text;

namespace KR1
{
    // Результат расчёта. Отделяет вычисления от печати.
    public sealed class OrderTotals
    {
        public decimal Subtotal { get; set; }
        public decimal Tax { get; set; }
        public decimal FinalTotal { get; set; }
        public decimal PaymentAdjustment { get; set; }
        public string Warning { get; set; }
    }
}
