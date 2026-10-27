using System;
using System.Collections.Generic;
using KR1;
using System.Text;

namespace KR1
{
    // Расчёт заказа. Раньше все if-ы были в Main.
    public sealed class OrderCalculator
    {
        // Магические числа вынесены в константы.
        private const decimal CardFeeRate = 0.05m;
        private const decimal CashFee = 0.5m;
        private const decimal BonusDiscount = 5m;
        private const decimal BonusThreshold = 100m;
        private const decimal LoyaltyDiscountRate = 0.10m;
        private const decimal WeekendDiscountRate = 0.05m;
        private const decimal TaxRate = 0.20m;

        public OrderTotals Calculate(Order order)
        {
            // Было: пустая корзина отдельно не обрабатывалась.
            // Стало: Замена if, мы сначала делаем проверку, а после возвращаем return, если смысла дальше идти нет смысла
            if (order.IsEmpty)
            {
                return new OrderTotals
                {
                    Subtotal = 0,// промежуточный итог
                    Tax = 0,// налог
                    FinalTotal = 0,// итоговая сумма к оплате
                    PaymentAdjustment = 0, // корректировка из заспособа оплаты
                    Warning = "Корзина пуста" // предупреждение
                };
            }
            // полный подсчет заказа
            decimal total = order.ItemsSubtotal;
            decimal paymentAdjustment = 0;
            string warning = null;

            // Было: if (pay == "card"), if (pay == "cash")...
            // Стало: switch по enum.
            switch (order.Payment)
            {// оплата карта
                case PaymentMethod.Card:
                    paymentAdjustment = total * CardFeeRate;
                    break;
                    // оплата по наличными
                case PaymentMethod.Cash:
                    paymentAdjustment = CashFee;
                    break;
                    //оплата бонусами
                case PaymentMethod.Bonus:
                    if (total > BonusThreshold)
                        paymentAdjustment = -BonusDiscount;
                    break;

                case PaymentMethod.Unknown:
                    // Было: неизвестная оплата молча игнорировалась.
                    // Стало: предупреждение, комиссия 0.
                    warning = "Неизвестный способ оплаты. Комиссия не начислена.";
                    paymentAdjustment = 0;
                    break;
            }

            total += paymentAdjustment;

            // Скидки применяются к сумме после корректировки оплаты,
            // как в исходном коде.
            if (order.IsLoyal)
                total -= total * LoyaltyDiscountRate;

            if (order.IsWeekend)
                total -= total * WeekendDiscountRate;

            decimal tax = total * TaxRate;
            decimal finalTotal = total + tax;

            if (finalTotal < 0)
                finalTotal = 0;

            return new OrderTotals
            {
                Subtotal = total,
                Tax = tax,
                FinalTotal = finalTotal,
                PaymentAdjustment = paymentAdjustment,
                Warning = warning
            };
        }
    }
}
