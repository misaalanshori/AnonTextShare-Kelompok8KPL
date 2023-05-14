using System;
namespace AnonTextAppConsoleUI
{
    public class TextCollection
    {
        public string? id { get; internal set; }
        public string title { get; set; }
        public List<TextDocument> contents { get; set; }
        public int? views { get; internal set; }

        public TextCollection() { }

        public TextCollection(string title, List<string> contents)
        {
            this.title = title;
            this.contents = new();
            foreach (string kode in contents)
            {
                this.contents.Add(ClientAPI.getDocument(id).Result);
            }
        }
    }
}

