using System;
using System.Xml.Serialization;

namespace LibraryXML.Entities
{
    [Serializable]
    [XmlRoot(ElementName = "Patent")]
    public class Patent : IPaperEdition, IEquatable<Patent>
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlAttribute("Discoverier")]
        public string Discoverier { get; set; }
        [XmlAttribute("Country")]
        public string Country { get; set; }
        [XmlAttribute("RegisterNumber")]
        public int RegisterNumber { get; set; }
        [XmlAttribute("RequestDate")]
        public DateTimeOffset RequestDate { get; set; }
        [XmlAttribute("PublicationDate")]
        public DateTimeOffset PublicationDate { get; set; }
        [XmlAttribute("PageNumber")]
        public int PageNumber { get; set; }
        [XmlAttribute("AdditionalInfo")]
        public string AdditionalInfo { get; set; }

        public bool Equals(Patent other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Name, other.Name) && string.Equals(Discoverier, other.Discoverier) 
                && string.Equals(Country, other.Country) && RegisterNumber == other.RegisterNumber 
                && RequestDate.Equals(other.RequestDate) && PublicationDate.Equals(other.PublicationDate)
                && PageNumber == other.PageNumber && string.Equals(AdditionalInfo, other.AdditionalInfo);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Patent) obj);
        }
    }
}
