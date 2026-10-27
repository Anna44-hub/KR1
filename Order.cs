using System;
using System.Collections.Generic;
using System.Text;

namespace KR1
{
    // Сам заказ: состав, оплата, статус, флаги.

    // sealed - это модификатор, который запрещает наследование от класса
    public sealed class Order
    {
        public List<OrderItem> Items { get; } = new List<OrderItem>();// вещи
        public PaymentMethod Payment { get; set; } = PaymentMethod.Unknown;// способ оплаты
        public OrderStatus Status { get; set; } = OrderStatus.New;// статус заказа
        public bool IsLoyal { get; set; }// постоянный клиент
        public bool IsWeekend { get; set; }// выходные

        public bool IsEmpty => Items.Count == 0;

        public decimal ItemsSubtotal => Items.Sum(item => item.Total);
    }
}
