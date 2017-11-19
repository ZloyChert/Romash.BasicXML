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
    public class Magazine : IPaperEdition
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
    }
}
