using System;
using System.Xml.Linq;
using LibraryXML.Entities;

namespace LibraryXML.ElementReaders
{
    public class BookReader
    {
        public static Book ReadBook(XElement element)
        {
            return new Book
            {
                AdditionalInfo = element.Attribute("AdditionalInfo")?.Value,
                Author = element.Attribute("Author")?.Value,
                CreatedPlace = element.Attribute("CreatedPlace")?.Value,
                EditionName = element.Attribute("EditionName")?.Value,
                Isbn = element.Attribute("Isbn")?.Value,
                Name = element.Attribute("Name")?.Value,
                PageNumber = int.Parse(element.Attribute("PageNumber")?.Value ??
                                       throw new InvalidOperationException("Attribute PageNumber doesn't set")),
                Year = int.Parse(element.Attribute("Year")?.Value ??
                                 throw new InvalidOperationException("Attribute Year doesn't set"))
            };
        }
    }
}
