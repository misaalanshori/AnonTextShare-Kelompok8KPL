namespace AnonTextShareAPI
{
    public class TextDocument
    {
        public string? id { get; internal set; }
        public string title { get; set; }
        public string contents { get; set; }
        public List<string>? comments { get; internal set; }
        public int? views { get; internal set; }

        public TextDocument() { }

        public TextDocument(string title, string contents)
        {
            this.title = title;
            this.contents = contents;
        }

        internal TextDocument(string id)
        {
            this.id = id;
            this.title = Config.db.GetDocumentTitle(id);
            this.contents = Config.db.GetDocumentText(id);
            this.comments = Config.db.GetDocumentComments(id);
            this.views = Config.db.GetDocumentViews(id);
        }

    }
}
