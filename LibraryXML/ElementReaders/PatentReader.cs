using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using LibraryXML.Entities;

namespace LibraryXML.ElementReaders
{
    public class PatentReader
    {
        public static Patent ReadPatent(XElement element)
        {
            return new Patent
            {
                AdditionalInfo = element.Attribute("AdditionalInfo")?.Value,
                Name = element.Attribute("Name")?.Value,
                PageNumber = int.Parse(element.Attribute("PageNumber")?.Value ?? throw new InvalidOperationException("Attribute PageNumber doesn't set")),
                Country = element.Attribute("Country")?.Value,
                Discoverier = element.Attribute("Discoverier")?.Value,
                PublicationDate = DateTimeOffset.Parse(element.Attribute("PublicationDate")?.Value),
                RegisterNumber = int.Parse(element.Attribute("RegisterNumber")?.Value ?? throw new InvalidOperationException("Attribute RegisterNumber doesn't set")),
                RequestDate = DateTimeOffset.Parse(element.Attribute("RequestDate")?.Value)
            };
        }
    }
}
