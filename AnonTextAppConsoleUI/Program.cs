using System;

namespace AnonTextAppConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string IdDoksli = ClientAPI.createDocument("Dalang G30S PKI", "Dalang G30S PKI adalah S_______", "no", "12345").Result;
            Console.WriteLine($"ID Doksli adalah {IdDoksli}");

            TextDocument doksli = ClientAPI.getDocument(IdDoksli).Result;
            Console.WriteLine(doksli.Title);
            Console.WriteLine(doksli.Contents);

            Task task =ClientAPI.changeTitle(IdDoksli,"12345","asu");
            task = ClientAPI.updateContent(IdDoksli, "12345", "Masa iya bang?");

            doksli = ClientAPI.getDocument(IdDoksli).Result;
            Console.WriteLine(doksli.Title);
            Console.WriteLine(doksli.Contents);
            List<string> ListDoksli = new List<string> { IdDoksli, IdDoksli };
            string IdSupersemar = ClientAPI.createCollection("Supersemar", "12345",ListDoksli).Result;
            Console.WriteLine($"ID Doksli adalah {IdSupersemar}");
            TextCollection ListSupersemar = ClientAPI.getCollection(IdSupersemar).Result;
            Console.WriteLine(ListSupersemar.title);
            for(int i = 0; i < ListSupersemar.contents.Count; i++)
            {
                Console.WriteLine(ListSupersemar.contents[i].Title);
            }

            task = ClientAPI.changeCollectionsTitle(IdSupersemar, "12345", "DOOKSLI");
            task = ClientAPI.AddContents(IdSupersemar, "12345", IdDoksli);
            task = ClientAPI.deleteContent(IdSupersemar, "12345", IdDoksli);
            ListSupersemar = ClientAPI.getCollection(IdSupersemar).Result;
            Console.WriteLine(ListSupersemar.title);
            for (int i = 0; i < ListSupersemar.contents.Count; i++)
            {
                Console.WriteLine(ListSupersemar.contents[i].Title);
            }
            while (true);
        }
    }
}