using System;
namespace AnonTextAppConsoleUI
{
    public class TextCollection
    {
        public string? Id { get; set; }
        public string Title { get; set; }
        public List<TextDocument> Contents { get; set; }
        public int? Views { get; set; }

        public TextCollection() { }

        public TextCollection(string title, List<string> contents)
        {
            this.Title = title;
            this.Contents = new();
            foreach (string kode in contents)
            {
                this.Contents.Add(ClientAPI.GetDocument(Id).Result);
            }
        }
    }
}

