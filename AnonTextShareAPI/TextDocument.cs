using AnonTextShareStorage;

namespace AnonTextShareAPI
{
    public class TextDocument
    {
        public string? id { get; internal set; }
        public string? title { get; set; }
        public string? contents { get; set; }
        public List<string>? comments { get; internal set; }
        public int? views { get; internal set; }
        public string? kategori { get; set; }
        public bool isExplicit => !KeywordFilter.FilterText(contents);
        public bool isLocked { get; set; }
        public int reportCount { get; set; }
        public string? reportState { get; set; }


        public TextDocument() { }

        public TextDocument(string title, string contents, string kategori)
        {
            this.title = title;
            this.contents = contents;
            this.kategori = kategori;
        }

        internal TextDocument(string id)
        {
            this.id = id;
            this.title = Config.db.GetDocumentTitle(id);
            this.contents = Config.db.GetDocumentText(id);
            this.comments = Config.db.GetDocumentComments(id);
            this.views = Config.db.GetDocumentViews(id);
            this.kategori = Config.db.getDocumentCategoryString(id);
            this.reportCount = Config.db.getReportCount(id);
            this.reportState = Config.db.getReportState(id).ToString();

        }

    }
}
