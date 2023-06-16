using System;
namespace AnonTextAppConsoleUI
{
    public class TextDocument
    {
        public string? Id { get; internal set; }
        public string? Title { get; set; }
        public string? Contents { get; set; }
        public List<string>? Comments { get; set; }
        public int? Views { get; internal set; }
        public string? Kategori { get; set; }
        public bool IsExplicit { get; set; }
        public bool IsLocked { get; set; }
        public int ReportCount { get; set; }
        public string? ReportState { get; set; }


        public TextDocument() { }

        public TextDocument(string title, string contents, string kategori)
        {
            this.Title = title;
            this.Contents = contents;
            this.Kategori = kategori;
        }

        public TextDocument(string? id, string? title, string? contents, List<string>? comments, int? views, string? kategori, bool isExplicit, bool isLocked, int reportCount, string? reportState) : this(id, title, contents)
        {
            this.Id = id;
            this.Title = title;
            this.Contents = contents;
            this.Comments = comments;
            this.Views = views;
            this.Kategori = kategori;
            this.IsExplicit = isExplicit;
            this.IsLocked = isLocked;
            this.ReportCount = reportCount;
            this.ReportState = reportState;
        }
    }
}

