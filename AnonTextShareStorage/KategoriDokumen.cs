using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonTextShareStorage
{
    internal class KategoriDokumen
    {
        enum Kategori
        {
            POLITIK,
            OLAHRAGA,
            BISNIS,
            HIBURAN
        }

        class Dokumen
        {
            private string namaDokumen;
            private Kategori kategori;

            private static string[] kategoriDokumen = new string[]
            {
                "Politik",
                "Olahraga",
                "Bisnis",
                "Hiburan"
            };

            public Dokumen(string namaDokumen, Kategori kategori)
            {
                this.namaDokumen = namaDokumen;
                this.kategori = kategori;
            }

            public string NamaDokumen
            {
                get { return namaDokumen; }
                set { namaDokumen = value; }
            }

            public Kategori KategoriDokumen
            {
                get { return kategori; }
                set { kategori = value; }
            }

            public void TampilkanInfo()
            {
                Console.WriteLine("Nama Dokumen: {0}", namaDokumen);
                Console.WriteLine("Kategori: {0}", kategoriDokumen[(int)kategori]);
            }
        }
    }
}
