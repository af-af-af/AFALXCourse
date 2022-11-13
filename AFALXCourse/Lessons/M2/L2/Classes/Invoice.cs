namespace AFALXCourse.Lessons.M2.L2.Classes
{
    public class Invoice
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public int NIP { get; set; }
        public double BruttoAmount { get; set; }
        public double NettoAmount { get; set; }

        public void PresentInvoice()
        {
            Console.WriteLine($"[Invoice] Id: {Id}");
            Console.WriteLine($"\tCustomer name: {CustomerName}");
            Console.WriteLine($"\tNIP: {NIP}");
            Console.WriteLine($"\tIncome (Brutto): {BruttoAmount}");
            Console.WriteLine($"\tIncome (Netto): {NettoAmount}");
        }
    }
}
