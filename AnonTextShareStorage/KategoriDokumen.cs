﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonTextShareStorage
{
    public class KategoriDokumen
    {
        public enum Kategori
        {
            LAIN,
            POLITIK,
            OLAHRAGA,
            BISNIS,
            HIBURAN
        }


        public static string[] kategoriDokumen { get; } = new string[]
            {
                "Lainnya",
                "Politik",
                "Olahraga",
                "Bisnis",
                "Hiburan"

            };

        public static Kategori kategoriFromString(string kategoriCari)
        {
            if (kategoriCari != null)
            {
                for (int i = 0; i < kategoriDokumen.Length; i++)
                {
                    if (kategoriDokumen[i].Trim().ToLower().Equals(kategoriCari.Trim().ToLower()))
                    {
                        return (Kategori)i;
                    }
                }
            }
            
            return Kategori.LAIN;
        }

        class Dokumen
        {
            private string namaDokumen;
            private Kategori kategori;

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
