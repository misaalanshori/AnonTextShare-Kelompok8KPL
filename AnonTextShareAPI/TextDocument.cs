using AnonTextShareStorage;

namespace AnonTextShareAPI
{
    public class TextDocument
    {
        public string? Id { get; internal set; }
        public string? Title { get; set; }
        public string? Contents { get; set; }
        public List<string>? Comments { get; internal set; }
        public int? Views { get; internal set; }
        public string? Kategori { get; set; }
        public bool IsExplicit => !KeywordFilter.FilterText(Contents);
        public bool IsLocked { get; internal set; }
        public int ReportCount { get; internal set; }
        public string? ReportState { get; internal set; }


        public TextDocument() { }

        public TextDocument(string title, string contents, string kategori)
        {
            this.Title = title;
            this.Contents = contents;
            this.Kategori = kategori;
        }

        internal TextDocument(string id)
        {
            this.Id = id;
            this.Title = Config.db.GetDocumentTitle(id);
            this.Contents = Config.db.GetDocumentText(id);
            this.Comments = Config.db.GetDocumentComments(id);
            this.Views = Config.db.GetDocumentViews(id);
            this.Kategori = Config.db.GetDocumentCategoryString(id);
            this.ReportCount = Config.db.GetReportCount(id);
            this.ReportState = Config.db.GetReportState(id).ToString();
            this.IsLocked = Config.db.GetDocumentLock(id) == EditingAutomata.State.Locked ? true : false;
        }

    }
}
