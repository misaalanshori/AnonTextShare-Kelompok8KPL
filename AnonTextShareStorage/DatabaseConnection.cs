namespace AnonTextShareStorage
{
    public abstract class DatabaseConnection
    {
        // Document methods
        public abstract string CreateDocument(string title, string text, KategoriDokumen.Kategori category);
        public abstract string CreateDocument(string title, string text, KategoriDokumen.Kategori category, string pass);
        public abstract bool CheckDocument(string id);
        public abstract bool CheckDocument(string id, string pass);
        public abstract string? GetDocumentTitle(string id);
        public abstract string? GetDocumentText(string id);
        public abstract bool UpdateDocumentTitle(string id, string pass, string title);
        public abstract bool UpdateDocumentText(string id, string pass, string contents);
        public abstract bool DeleteDocument(string id, string pass);
        public abstract int GetDocumentViews(string id);
        public abstract bool AddDocumentComment(string id, string text);
        public abstract List<string>? GetDocumentComments(string id);
        public abstract bool UpdateDocumentCategory(string id, KategoriDokumen.Kategori category, string pass);
        public abstract string? GetDocumentCategoryString(string id);
        public abstract KategoriDokumen.Kategori? GetDocumentCategory(string id);
        public abstract bool TriggerDocumentLock(string id, EditingAutomata.Trigger trigger, string pass);
        public abstract EditingAutomata.State? GetDocumentLock(string id);
        public abstract bool ReportDocument(string id);
        public abstract bool UnlockDocument(string id, string pass);
        public abstract int GetReportCount(string id);
        public abstract ReportingHabli.State? GetReportState(string id);

        // Collection methods
        public abstract string CreateCollection(string title, List<string> contents);
        public abstract string CreateCollection(string title, List<string> contents, string pass);
        public abstract bool CheckCollection(string id);
        public abstract bool CheckCollection(string id, string pass);
        public abstract string? GetCollectionTitle(string id);
        public abstract List<string>? GetCollectionContents(string id);
        public abstract bool UpdateCollectionTitle(string id, string title, string pass);
        public abstract bool AddCollectionDocument(string id, string documentId, string pass);
        public abstract bool RemoveCollectionDocument(string id, string documentId, string pass);
        public abstract bool DeleteCollection(string id, string pass);
        public abstract int GetCollectionViews(string id);
    }
}