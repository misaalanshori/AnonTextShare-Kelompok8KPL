using System;

namespace AnonTextAppConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string IdDoksli = ClientAPI.createDocument("Dalang G30S PKI", "Dalang G30S PKI adalah S_______", "12345").Result;
            Console.WriteLine($"ID Doksli adalah {IdDoksli}");

            TextDocument doksli = ClientAPI.getDocument(IdDoksli).Result;
            Console.WriteLine(doksli.title);
            Console.WriteLine(doksli.contents);

            Task task =ClientAPI.changeTitle(IdDoksli,"12345","asu");
            task = ClientAPI.updateContent(IdDoksli, "12345", "Masa iya bang?");

            doksli = ClientAPI.getDocument(IdDoksli).Result;
            Console.WriteLine(doksli.title);
            Console.WriteLine(doksli.contents);
            string doc1 = ClientAPI.createDocument("AAA", "Doksli","12345").Result;
            string doc2 = ClientAPI.createDocument("BBB", "Doksli", null).Result;

            List<string> ListDoksli = new List<string> { doc1, doc2 };
            string IdSupersemar = ClientAPI.createCollection("Supersemar", "12345",ListDoksli).Result;
            Console.WriteLine($"ID Doksli adalah {IdSupersemar}");

            TextCollection ListSupersemar = ClientAPI.getCollection(IdSupersemar).Result;
            Console.WriteLine(ListSupersemar.title);
            for(int i = 0; i < ListSupersemar.contents.Count; i++)
            {
                Console.WriteLine(ListSupersemar.contents[i].title);
            }

            task = ClientAPI.changeCollectionsTitle(IdSupersemar, "12345", "DOOKSLI");
            string doc3 = ClientAPI.createDocument("CCC", "Doksli", null).Result;
            task = ClientAPI.AddContents(IdSupersemar, "12345", doc3);
            task = ClientAPI.deleteContent(IdSupersemar, "12345", doc1);
            ListSupersemar = ClientAPI.getCollection(IdSupersemar).Result;
            Console.WriteLine(ListSupersemar.title);
            for (int i = 0; i < ListSupersemar.contents.Count; i++)
            {
                Console.WriteLine(ListSupersemar.contents[i].title);
            }
        }
    }
}