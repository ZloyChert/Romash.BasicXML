using System;
using System.Xml.Serialization;

namespace LibraryXML.Entities
{
    [Serializable]
    [XmlRoot(ElementName = "Book")]
    public class Book : IPaperEdition
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
    }
}
