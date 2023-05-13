

namespace AnonTextShareAPI
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
                this.contents.Add(new TextDocument(kode));
            }

        }

        internal TextCollection(string id)
        {
            this.id = id;
            this.title = Config.db.GetCollectionTitle(id);
            this.contents = new();
            foreach (string kode in Config.db.GetCollectionContents(id))
            {
                this.contents.Add(new TextDocument(kode));
            }
            this.views = Config.db.GetCollectionViews(id);
        }
    }
}
