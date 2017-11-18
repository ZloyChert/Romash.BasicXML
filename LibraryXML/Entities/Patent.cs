using System;
using System.Xml.Serialization;

namespace LibraryXML.Entities
{
    [Serializable]
    [XmlRoot(ElementName = "Patent")]
    public class Patent : IPaperEdition
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlAttribute("Discoverier")]
        public string Discoverier { get; set; }
        [XmlAttribute("Country")]
        public string Country { get; set; }
        [XmlAttribute("RegisterNumber")]
        public int RegisterNumber { get; set; }
        [XmlAttribute(AttributeName = "RequestDate")]
        public DateTimeOffset RequestDate { get; set; }
        [XmlAttribute(AttributeName = "PublicationDate")]
        public DateTimeOffset PublicationDate { get; set; }
        [XmlAttribute("PageNumber")]
        public int PageNumber { get; set; }
        [XmlAttribute("AdditionalInfo")]
        public string AdditionalInfo { get; set; }
    }
}
