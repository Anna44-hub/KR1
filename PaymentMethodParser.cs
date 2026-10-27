using System;
using System.Collections.Generic;
using System.Text;

namespace KR1
{
    // Парсер строки оплаты — чтобы можно было принимать "cash"/"card"/"bonus"
    // и явно превращать неизвестное значение в Unknown.
    public static class PaymentMethodParser
    {
        public static PaymentMethod Parse(string value)
        {
            // Дает возможность вводить пустую строку, но при этом если строка не пустая то ?.Trim() обрезает пробелы по краям, а ToLowerInvariant() приводит к нижнему регистру.
            // Нужно нам чтобы преобразовать строку в чистую
            return value?.Trim().ToLowerInvariant() switch
            {
                "cash" => PaymentMethod.Cash,
                "card" => PaymentMethod.Card,
                "bonus" => PaymentMethod.Bonus,
                _ => PaymentMethod.Unknown
            };
        }
    }
}