using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LibraryXML.Entities
{
    [Serializable]
    [XmlRoot(ElementName = "Magazine")]
    public class Magazine : IPaperEdition, IEquatable<Magazine>
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }
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
        [XmlAttribute("Number")]
        public int Number { get; set; }
        [XmlAttribute("Date")]
        public DateTimeOffset Date { get; set; }
        [XmlAttribute("Issn")]
        public string Issn { get; set; }

        public bool Equals(Magazine other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Name, other.Name) && string.Equals(CreatedPlace, other.CreatedPlace) 
                && string.Equals(EditionName, other.EditionName) && Year == other.Year 
                && PageNumber == other.PageNumber && string.Equals(AdditionalInfo, other.AdditionalInfo) 
                && Number == other.Number && Date.Equals(other.Date) && string.Equals(Issn, other.Issn);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Magazine) obj);
        }
    }
}
