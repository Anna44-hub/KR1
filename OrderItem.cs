using System;
using System.Collections.Generic;
using System.Text;

namespace KR1
{
    // Одна позиция заказа. Раньше были три параллельных списка:
    // items, prices, qty. Теперь всё в одном объекте.
    public sealed class OrderItem
    {
        public string Name { get; }
        public decimal Price { get; }
        public int Quantity { get; }

        public OrderItem(string name, decimal price, int quantity)
        {//обработка ошибки throw останавливает действие программы ArgumentException выводит ошибку
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Название блюда обязательно", nameof(name));

            if (price < 0)
                throw new ArgumentOutOfRangeException(nameof(price), "Цена не может быть отрицательной");

            if (quantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(quantity), "Количество должно быть больше 0");

            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public decimal Total => Price * Quantity;
    }
}
