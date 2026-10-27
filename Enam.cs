using System;
using System.Collections.Generic;
using System.Text;

namespace KR1
{
    // Было: string pay = "card";
    // Стало: перечисление. Опечататься в "card" больше нельзя.
    public enum PaymentMethod
    {
        Cash,
        Card,
        Bonus,
        Unknown
    }

    // Было: string status = "new";
    // Стало: перечисление статусов заказа.
    public enum OrderStatus
    {
        New,
        Cooking,
        Ready,
        Done
    }
}
