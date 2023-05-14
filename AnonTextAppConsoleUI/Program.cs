namespace AnonTextAppConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string IdDoksli = ClientAPI.createDocument("Dalang G30S PKI", "Dalang G30S PKI adalah S_______", "123").Result;
            Console.WriteLine($"ID Doksli adalah {IdDoksli}");

            TextDocument doksli = ClientAPI.getDocument(IdDoksli).Result;
            Console.WriteLine(doksli.title);

            Task task = ClientAPI.changeTitle(IdDoksli,"123","Dasar PKI");

            doksli = ClientAPI.getDocument(IdDoksli).Result;
            Console.WriteLine(doksli.title);
        }
    }
}