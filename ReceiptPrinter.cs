using System;
using System.Collections.Generic;
using System.Text;

namespace KR1
{
    // Печать чека и статуса. Отдельная ответственность.
    public sealed class ReceiptPrinter
    {
        public void Print(Order order, OrderTotals totals)
        {
            if (order.IsEmpty)
            {
                Console.WriteLine("Корзина пуста");
                Console.WriteLine("Итог: 0");
                return;
            }

            if (!string.IsNullOrWhiteSpace(totals.Warning))
                Console.WriteLine("Предупреждение: " + totals.Warning);

            Console.WriteLine(GetStatusText(order.Status));

            Console.WriteLine("---Receipt---");

            foreach (var item in order.Items)
                Console.WriteLine($"{item.Name} x{item.Quantity} - {item.Total}");

            Console.WriteLine("Subtotal: " + totals.Subtotal);
            Console.WriteLine("Tax: " + totals.Tax);
            Console.WriteLine("Total: " + totals.FinalTotal);
            Console.WriteLine("Payment: " + order.Payment);
            Console.WriteLine("Status: " + order.Status);
        }

        // Было: набор if (status == "new")...
        // Стало: отдельный метод с switch -  это оператор ветвления, который позволяет выбрать один из нескольких вариантов действий в зависимости от значения переменной (замена is/else)
        private static string GetStatusText(OrderStatus status)
        {
            return status switch
            {
                OrderStatus.New => "Order accepted",
                OrderStatus.Cooking => "Cooking...",
                OrderStatus.Ready => "Ready",
                OrderStatus.Done => "Given",
                // _ - значение по умолчанию. _ => Помогает нам обработать все остальные случаи "Во всех остальных случаях верни/сделай..."
                _ => "Unknown status"
            };
        }
    }
}