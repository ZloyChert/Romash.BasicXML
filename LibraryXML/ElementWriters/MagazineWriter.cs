using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using LibraryXML.Entities;

namespace LibraryXML.ElementWriters
{
    public class MagazineWriter
    {
        public static void WriteMagazine(XmlWriter writer, IPaperEdition element)
        {
            if (element is Magazine magazine)
            {
                writer.WriteStartElement("Magazine");
                writer.WriteAttributeString("EditionName", magazine.EditionName);
                writer.WriteAttributeString("Name", magazine.Name);
                writer.WriteAttributeString("AdditionalInfo", magazine.AdditionalInfo);
                writer.WriteAttributeString("CreatedPlace", magazine.CreatedPlace);
                writer.WriteAttributeString("Issn", magazine.Issn);
                writer.WriteAttributeString("Date", magazine.Date.ToString("O"));
                writer.WriteAttributeString("Number", magazine.Number.ToString());
                writer.WriteAttributeString("PageNumber", magazine.PageNumber.ToString());
                writer.WriteAttributeString("Year", magazine.Year.ToString());
                writer.WriteEndElement();
            }
        }
    }
}
