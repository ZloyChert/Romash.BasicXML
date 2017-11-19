using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using LibraryXML.Entities;

namespace LibraryXML.ElementWriters
{
    public class PatentWriter
    {
        public static void WritePatent(XmlWriter writer, IPaperEdition element)
        {
            if (element is Patent patent)
            {
                writer.WriteStartElement("Patent");
                writer.WriteAttributeString("Name", patent.Name);
                writer.WriteAttributeString("AdditionalInfo", patent.AdditionalInfo);
                writer.WriteAttributeString("Country", patent.Country);
                writer.WriteAttributeString("Discoverier", patent.Discoverier);
                writer.WriteAttributeString("PageNumber", patent.PageNumber.ToString());
                writer.WriteAttributeString("PublicationDate", patent.PublicationDate.ToString("O"));
                writer.WriteAttributeString("RegisterNumber", patent.RegisterNumber.ToString());
                writer.WriteAttributeString("RequestDate", patent.RequestDate.ToString("O"));
                writer.WriteEndElement();
            }
        }
    }
}
