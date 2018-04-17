using System;

namespace WebCrawler
{
    public class BookInfo : Object
    {
        private string _title;
        private string _author;
        private string _publisher;
        private string _isbn;
        private string _image;
        private string _summary;
        private string _price;

        public string Title
        {
            get => _title;
            set => _title = value;
        }
        public string Author
        {
            get => _author;
            set => _author = value;
        }

        public string Publisher
        {
            get => _publisher;
            set => _publisher = value;
        }
        public string ISBN
        {
            get => _isbn;
            set => _isbn = value;
        }

        public string Image
        {
            get => _image;
            set => _image = value;
        }
        public string Summary
        {
            get => _summary;
            set => _summary = value;
        }
        public string Price
        {
            get => _price;
            set => _price = value;
        }
        public BookInfo()
        {

        }
        public BookInfo(
                        string title,
                        string author,
                        string publisher,
                        string isbn,
                        string image,
                        string summary,
                        string price
                        )
        {
            this._title = title;
            this._author = author;
            this._publisher = publisher;
            this._isbn = isbn;
            this._image = image;
            this._summary = summary;
            this._price = price;

        }

        public override string ToString()
        {
            return $"{Title} - {Author} - {Publisher} - {ISBN} - {Image} - {Summary} - {Price}";
        }
    }
}