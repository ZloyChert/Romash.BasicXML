using System;
using System.Xml.Serialization;

namespace LibraryXML.Entities
{
    [Serializable]
    [XmlRoot(ElementName = "Book")]
    public class Book : IPaperEdition, IEquatable<Book>
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlAttribute("Author")]
        public string Author { get; set; }
        [XmlAttribute("CreatedPlace")]
        public string CreatedPlace { get; set; }
        [XmlAttribute("EditionName")]
        public string EditionName { get; set; }
        [XmlAttribute("Year")]
        public int Year { get; set; }
        [XmlAttribute("PageNumber")]
        public int PageNumber { get; set; }
        [XmlAttribute("AdditionalInfo")]
        public string AdditionalInfo { get; set; }
        [XmlAttribute("Isbn")]
        public string Isbn { get; set; }

        public bool Equals(Book other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Name, other.Name) && string.Equals(Author, other.Author) 
                && string.Equals(CreatedPlace, other.CreatedPlace) && string.Equals(EditionName, other.EditionName) 
                && Year == other.Year && PageNumber == other.PageNumber 
                && string.Equals(AdditionalInfo, other.AdditionalInfo) && string.Equals(Isbn, other.Isbn);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Book) obj);
        }
    }
}
