using System;
namespace AnonTextAppConsoleUI
{
	public class TextDocument
	{
        public string? id { get;  set; }
        public string title { get; set; }
        public string contents { get; set; }
        public List<string>? comments { get; set; }
        public int? views { get; set; }

        public TextDocument() { }

        public TextDocument(string title, string contents, List<string> comments, int views)
        {
            this.title = title;
            this.contents = contents;
            this.comments = comments;
            this.views = views;
        }

        public TextDocument(string title, string contents)
        {
            this.title = title;
            this.contents = contents;
        }

        
    }
}

