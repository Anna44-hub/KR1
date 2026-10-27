namespace KR1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var calculator = new OrderCalculator();
            var printer = new ReceiptPrinter();

            // Тестовый пример 1: Coffee, cash, new.
            var order1 = new Order
            {
                Payment = PaymentMethodParser.Parse("cash"),
                Status = OrderStatus.New,
                IsLoyal = false,
                IsWeekend = false
            };
            order1.Items.Add(new OrderItem("Coffee", 2.0m, 1));

            printer.Print(order1, calculator.Calculate(order1));
            Console.WriteLine();

            // Тестовый пример 2: пустая корзина, card, ready.
            var order2 = new Order
            {
                Payment = PaymentMethodParser.Parse("card"),
                Status = OrderStatus.Ready
            };

            printer.Print(order2, calculator.Calculate(order2));
            Console.WriteLine();

            // Тестовый пример 3: Soup, unknown payment, new.
            var order3 = new Order
            {
                Payment = PaymentMethodParser.Parse("unknown"),
                Status = OrderStatus.New
            };
            order3.Items.Add(new OrderItem("Soup", 4.0m, 1));

            printer.Print(order3, calculator.Calculate(order3));
        }
    }
}