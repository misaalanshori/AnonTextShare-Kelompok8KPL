namespace AnonTextShareStorage
{
    public abstract class DatabaseConnection
    {
        // Document methods
        public abstract string CreateDocument(string title, string text); // return string id document, password isi null
        public abstract string CreateDocument(string title, string text, string pass); // return string id document, simpan password di hash
        public abstract bool CheckDocument(string id); // return true jika dokumen ditemukan
        public abstract bool CheckDocument(string id, string pass); // return true jika dokumen ditemukan dan pass benar
        public abstract string GetDocumentTitle(string id);
        public abstract string GetDocumentText(string id);
        public abstract bool UpdateDocumentTitle(string id, string pass, string title); // return true jika title dokumen berhasil di update (dokumen ada dan pass benar)
        public abstract bool UpdateDocumentText(string id, string pass, string contents); // return true jika teks dokumen berhasil di update (dokumen ada dan pass benar)
        public abstract bool DeleteDocument(string id, string pass); // return true jika dokumen berhasil dihapus (dokumen ada dan pass benar)
        public abstract int GetDocumentViews(string id); // Document Views di increment setiap GetDocumentText dipanggil
        public abstract bool AddDocumentComment(string id, string text);
        public abstract List<string> GetDocumentComments(string id);

        // Collection methods
        public abstract string CreateCollection(string title, List<string> contents); // return string id collection, password isi null
        public abstract string CreateCollection(string title, List<string> contents, string pass); // return string id collection, simpan password di hash
        public abstract bool CheckCollection(string id); // return true jika koleksi ditemukan
        public abstract bool CheckCollection(string id, string pass); // return true jika koleksi ditemukan dan pass benar
        public abstract string GetCollectionTitle(string id);
        public abstract List<String> GetCollectionContents(string id); // return list string id dokumen
        public abstract bool UpdateCollectionTitle(string id, string title, string pass); // return true jika judul berhasil di ubah
        public abstract bool AddCollectionDocument(string id, string documentId, string pass); // return true jika id dokumen berhasil ditambahkan
        public abstract bool RemoveCollectionDocument(string id, string documentId, string pass); // return true jika id dokumen berhasil dihapus
        public abstract bool DeleteCollection(string id, string pass); // return true jika koleksi berhasil di hapus
        public abstract int GetCollectionViews(string id); // Collection Views di increment setiap GetCollectionContents dipanggil
    }
}