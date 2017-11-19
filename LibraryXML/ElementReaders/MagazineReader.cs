using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using LibraryXML.Entities;

namespace LibraryXML.ElementReaders
{
    public class MagazineReader
    {
        public static Magazine ReadMagazine(XElement element)
        {
            return new Magazine
            {
                AdditionalInfo = element.Attribute("AdditionalInfo")?.Value,
                CreatedPlace = element.Attribute("CreatedPlace")?.Value,
                EditionName = element.Attribute("EditionName")?.Value,
                Name = element.Attribute("Name")?.Value,
                PageNumber = int.Parse(element.Attribute("PageNumber")?.Value ?? throw new InvalidOperationException("Attribute PageNumber doesn't set")),
                Year = int.Parse(element.Attribute("Year")?.Value ?? throw new InvalidOperationException("Attribute Year doesn't set")),
                Date = DateTimeOffset.Parse(element.Attribute("Date")?.Value),
                Issn = element.Attribute("Issn")?.Value,
                Number = int.Parse(element.Attribute("Number")?.Value ?? throw new InvalidOperationException("Attribute Number doesn't set"))
            };
        }
    }
}
