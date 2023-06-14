using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Reflection.Metadata;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;

namespace AnonTextShareStorage
{ 
    public class SimpleDB : DatabaseConnection
    {
        // Random
        private static Random rnd = new();

        // Document Storage
        private Dictionary<string, string> _docPass = new();
        private Dictionary<string, string> _docTitle = new();
        private Dictionary<string, string> _docContent = new();
        private Dictionary<string, int> _docViews = new();
        private Dictionary<string, List<string>> _docComments = new();
        private Dictionary<string, KategoriDokumen.Kategori> _docCategory = new();
        private Dictionary<string, EditingAutomata.State> _docLock = new();
        private Dictionary<string, int> _docReportCount = new();
        private Dictionary<string, ReportingHabli.State> _docReportState = new();

        // Collection Storage
        private Dictionary<string, string> _colPass = new();
        private Dictionary<string, string> _colTitle = new();
        private Dictionary<string, List<string>> _colContent = new();
        private Dictionary<string, int> _colViews = new();

        // String hashing method
        private static String sha256Hash(string value)
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
        public override string CreateDocument(string title, string text, KategoriDokumen.Kategori category)
        {
            try
            {
                string key = generateRandomID();
                _docPass.Add(key, "");
                _docTitle.Add(key, title);
                _docContent.Add(key, text);
                _docViews.Add(key, 0);
                _docComments.Add(key, new List<string>());
                _docCategory.Add(key, category);
                _docLock.Add(key, EditingAutomata.State.UnLocked);
                _docReportCount.Add(key, 0);
                _docReportState.Add(key, ReportingHabli.State.Safe);
                return key;
            }
            catch (ArgumentException e)
            {
                return CreateDocument(title, text, category);
            }
        } // return string id document, password isi empty string


        public override string CreateDocument(string title, string text, KategoriDokumen.Kategori category, string pass)
        {
            Debug.Assert(pass.Length > 4);
            string passkey = sha256Hash(pass);
            try
            {
                string key = generateRandomID();
                _docPass.Add(key, passkey);
                _docTitle.Add(key, title);
                _docContent.Add(key, text);
                _docViews.Add(key, 0);
                _docComments.Add(key, new List<string>());
                _docCategory.Add(key, category);
                _docLock.Add(key, EditingAutomata.State.UnLocked);
                _docReportCount.Add(key, 0);
                _docReportState.Add(key, ReportingHabli.State.Safe);
                return key;
            }
            catch (ArgumentException e)
            {
                return CreateDocument(title, text, category, pass);
            }

        } // return string id document, simpan password di hash

        public override bool CheckDocument(string id)
        {
            return _docTitle.ContainsKey(id);
        } // return true jika dokumen ditemukan

        public override bool CheckDocument(string id, string pass)
        {
            Debug.Assert(pass.Length > 4);
            return _docPass.ContainsKey(id) && _docPass[id].Equals(sha256Hash(pass));
        } // return true jika dokumen ditemukan dan pass benar

        public override string? GetDocumentTitle(string id)
        {
            if (CheckDocument(id))
            {
                return _docTitle[id];
            }
            return null;
        }

        public override string? GetDocumentText(string id)
        {
            if (CheckDocument(id))
            {
                _docViews[id]++;
                return _docContent[id];
            }
            return null;
        }

        public override bool UpdateDocumentTitle(string id, string pass, string title)
        {
            if (CheckDocument(id, pass))
            {
                _docTitle[id] = title;
                return true;
            }
            return false;
        } // return true jika title dokumen berhasil di update (dokumen ada dan pass benar)

        public override bool UpdateDocumentText(string id, string pass, string contents)
        {
            if (CheckDocument(id, pass))
            {
                _docContent[id] = contents;
                return true;
            }
            return false;
        } // return true jika teks dokumen berhasil di update (dokumen ada dan pass benar)

        public override bool DeleteDocument(string id, string pass)
        {
            if (CheckDocument(id, pass))
            {
                _docPass.Remove(id);
                _docTitle.Remove(id);
                _docContent.Remove(id);
                _docViews.Remove(id);
                _docComments.Remove(id);
                return true;
            }
            return false;
        } // return true jika dokumen berhasil dihapus (dokumen ada dan pass benar)

        public override int GetDocumentViews(string id)
        {
            if (CheckDocument(id))
            {
                return _docViews[id];
            }
            return -1;
        } // Document Views di increment setiap GetDocumentText dipanggil

        public override bool AddDocumentComment(string id, string text)
        {
            if (CheckDocument(id))
            {
                _docComments[id].Add(text);
                return true;
            }
            return false;
        }

        public override List<string>? GetDocumentComments(string id)
        {
            if (CheckDocument(id))
            {
                return _docComments[id];
            }
            return null;
        }

        public override bool UpdateDocumentCategory(string id, KategoriDokumen.Kategori category, string pass)
        {
            if (CheckDocument(id, pass))
            {
                _docCategory[id] = category;
                return true;
            }
            return false;
        }

        public override string? GetDocumentCategoryString(string id)
        {
            if (CheckDocument(id))
            {
                return KategoriDokumen.kategoriDokumen[(int)_docCategory[id]] ;
            }
            return null;
        }

        public override KategoriDokumen.Kategori? GetDocumentCategory(string id)
        {
            if (CheckDocument(id))
            {
                return _docCategory[id];
            }
            return null;
        }

        public override bool TriggerDocumentLock(string id, EditingAutomata.Trigger trigger, string pass)
        {
            if (CheckDocument(id, pass))
            {
                _docLock[id] = EditingAutomata.getNextState(_docLock[id], trigger);
                return true;
            }
            return false;
        }

        public override EditingAutomata.State? GetDocumentLock(string id)
        {
            if (CheckDocument(id))
            {
                return _docLock[id];
            }
            return null;
        }

        public override bool ReportDocument(string id)
        {
            if (CheckDocument(id))
            {
                _docReportCount[id] = _docReportCount[id] + 1;
                if (_docReportCount[id] % 10 == 0)
                {
                    _docReportState[id] = ReportingHabli.GetNextState(_docReportState[id], ReportingHabli.Trigger.Escalate);
                }
            }
            return false;
        }

        public override bool UnlockDocument(string id, string pass)
        {
            if (CheckDocument(id, pass))
            {
                _docReportState[id] = ReportingHabli.GetNextState(_docReportState[id], ReportingHabli.Trigger.Unlock);
                return true;
            }
            return false;
        }

        public override int GetReportCount(string id)
        {
            if (CheckDocument(id))
            {
                return _docReportCount[id];
            }
            return -1;
        }

        public override ReportingHabli.State? GetReportState(string id)
        {
            if (CheckDocument(id))
            {
                return _docReportState[id];
            }
            return null;
        }

        // Collection methods
        public override string CreateCollection(string title, List<string> contents)
        {
            string newID = generateRandomID();
            try
            {
                _colPass.Add(newID, "");
                _colTitle.Add(newID, new string(title));
                _colContent.Add(newID, new List<string>(contents));
                _colViews.Add(newID, 0);
                return newID;
            } catch (ArgumentException e)
            {
                return CreateCollection(title, contents);
            }
            
        } // return string id collection, password isi empty string

        public override string CreateCollection(string title, List<string> contents, string pass)
        {
            Debug.Assert(pass.Length > 4); // Password harus lebih dari 4 karakter
            string newID = generateRandomID();
            try
            {
                _colPass.Add(newID, sha256Hash(pass));
                _colTitle.Add(newID, new string(title));
                _colContent.Add(newID, new List<string>(contents));
                _colViews.Add(newID, 0);
                return newID;
            } catch (ArgumentException e)
            {
                return CreateCollection(title, contents, pass);
            }
            
        } // return string id collection, simpan password di hash

        public override bool CheckCollection(string id)
        {
            return _colPass.ContainsKey(id);
        } // return true jika koleksi ditemukan

        public override bool CheckCollection(string id, string pass)
        {
            Debug.Assert(pass.Length > 4); // Password harus lebih dari 4 karakter
            return _colPass.ContainsKey(id) && _colPass[id].Equals(sha256Hash(pass));
        } // return true jika koleksi ditemukan dan pass benar

        public override string? GetCollectionTitle(string id)
        {
            if (CheckCollection(id))
            {
                return new string(_colTitle[id]);
            }
            return null;
        }

        public override List<string>? GetCollectionContents(string id)
        {
            if (CheckCollection(id))
            {
                _colViews[id]++;
                return new List<string>(_colContent[id]);
            }
            return null;
            
        } // return list string id dokumen

        public override bool UpdateCollectionTitle(string id, string title, string pass)
        {
            if (CheckCollection(id, pass))
            {
                _colTitle[id] = new string(title);
                return true;
            }
            return false;
        } // return true jika judul berhasil di ubah

        public override bool AddCollectionDocument(string id, string documentId, string pass)
        {
            if (CheckCollection(id, pass))
            {
                _colContent[id].Add(documentId);
                return true;
            }
            return false;
        } // return true jika id dokumen berhasil ditambahkan

        public override bool RemoveCollectionDocument(string id, string documentId, string pass)
        {
            if (CheckCollection(id, pass))
            {
                _colContent[id].Remove(documentId);
                return true;
            }
            return false;
        } // return true jika id dokumen berhasil dihapus

        public override bool DeleteCollection(string id, string pass)
        {
            if (CheckCollection(id, pass))
            {
                _colPass.Remove(id);
                _colTitle.Remove(id);
                _colContent.Remove(id);
                _colViews.Remove(id);
                return true;
            }
            return false;
        } // return true jika koleksi berhasil di hapus

        public override int GetCollectionViews(string id)
        {
            if(CheckCollection(id))
            {
                return _colViews[id];
            }
            return -1;
        } // Collection Views di increment setiap GetCollectionContents dipanggil
    }
}
