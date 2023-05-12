using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Reflection.Metadata;

namespace AnonTextShareStorage
{ 
    public class SimpleDB : DatabaseConnection
    {
        // Random
        private static Random rnd = new();

        // Document Storage
        private Dictionary<string, string> docPass = new();
        private Dictionary<string, string> docTitle = new();
        private Dictionary<string, string> docContent = new();
        private Dictionary<string, int> docViews = new();
        private Dictionary<string, List<string>> docComments = new();

        // Collection Storage
        private Dictionary<string, string> colPass = new();
        private Dictionary<string, string> colTitle = new();
        private Dictionary<string, List<string>> colContent = new();
        private Dictionary<string, int> colViews = new();

        // String hashing method
        private static String SHA256Hash(string value)
        {
            StringBuilder Sb = new StringBuilder();

            using (var hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }

        // Random ID generator
        private static string generateRandomID()
        {
            return rnd.Next(1, 2147483647).ToString();
        }

        // Document Methods
        public override string CreateDocument(string title, string text)
        {
            throw new NotImplementedException();
        } // return string id document, password isi null

        public override string CreateDocument(string title, string text, string pass)
        {
            throw new NotImplementedException();
        } // return string id document, simpan password di hash

        public override bool CheckDocument(string id)
        {
            throw new NotImplementedException();
        } // return true jika dokumen ditemukan

        public override bool CheckDocument(string id, string pass)
        {
            throw new NotImplementedException();
        } // return true jika dokumen ditemukan dan pass benar

        public override string GetDocumentTitle(string id)
        {
            throw new NotImplementedException();
        }

        public override string GetDocumentText(string id)
        {
            throw new NotImplementedException();
        }

        public override bool UpdateDocumentTitle(string id, string pass, string title)
        {
            throw new NotImplementedException();
        } // return true jika title dokumen berhasil di update (dokumen ada dan pass benar)

        public override bool UpdateDocumentText(string id, string pass, string contents)
        {
            throw new NotImplementedException();
        } // return true jika teks dokumen berhasil di update (dokumen ada dan pass benar)

        public override bool DeleteDocument(string id, string pass)
        {
            throw new NotImplementedException();
        } // return true jika dokumen berhasil dihapus (dokumen ada dan pass benar)

        public override int GetDocumentViews(string id)
        {
            throw new NotImplementedException();
        } // Document Views di increment setiap GetDocumentText dipanggil

        public override bool AddDocumentComment(string id, string text)
        {
            throw new NotImplementedException();
        }

        public override List<string> GetDocumentComments(string id)
        {
            throw new NotImplementedException();
        }


        // Collection methods
        public override string CreateCollection(string title, List<string> contents)
        {
            string newID = generateRandomID();
            colPass.Add(newID, "");
            colTitle.Add(newID, new string(title));
            colContent.Add(newID, new List<string>(contents));
            colViews.Add(newID, 0);
            return newID;
        } // return string id collection, password isi null

        public override string CreateCollection(string title, List<string> contents, string pass)
        {
            string newID = generateRandomID();
            colPass.Add(newID, SHA256Hash(pass));
            colTitle.Add(newID, new string(title));
            colContent.Add(newID, new List<string>(contents));
            colViews.Add(newID, 0);
            return newID;
        } // return string id collection, simpan password di hash

        public override bool CheckCollection(string id)
        {
            return colPass.ContainsKey(id);
        } // return true jika koleksi ditemukan

        public override bool CheckCollection(string id, string pass)
        {
            return colPass.ContainsKey(id) && colPass[id].Equals(SHA256Hash(pass));
        } // return true jika koleksi ditemukan dan pass benar

        public override string GetCollectionTitle(string id)
        {
            return new string(colTitle[id]);
        }

        public override List<string> GetCollectionContents(string id)
        {
            colViews[id]++;
            return new List<string>(colContent[id]);
        } // return list string id dokumen

        public override bool UpdateCollectionTitle(string id, string title, string pass)
        {
            if (CheckCollection(id, pass))
            {
                colTitle[id] = new string(title);
                return true;
            }
            return false;
        } // return true jika judul berhasil di ubah

        public override bool AddCollectionDocument(string id, string documentId, string pass)
        {
            if (CheckCollection(id, pass))
            {
                colContent[id].Add(documentId);
                return true;
            }
            return false;
        } // return true jika id dokumen berhasil ditambahkan

        public override bool RemoveCollectionDocument(string id, string documentId, string pass)
        {
            if (CheckCollection(id, pass))
            {
                colContent[id].Remove(documentId);
                return true;
            }
            return false;
        } // return true jika id dokumen berhasil dihapus

        public override bool DeleteCollection(string id, string pass)
        {
            if (CheckCollection(id, pass))
            {
                colPass.Remove(id);
                colTitle.Remove(id);
                colContent.Remove(id);
                colViews.Remove(id);
                return true;
            }
            return false;
        } // return true jika koleksi berhasil di hapus

        public override int GetCollectionViews(string id)
        {
            return colViews[id];
        } // Collection Views di increment setiap GetCollectionContents dipanggil
    }
}
