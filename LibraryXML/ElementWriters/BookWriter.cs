using System.Xml;
using LibraryXML.Entities;

namespace LibraryXML.ElementWriters
{
    public class BookWriter
    {
        public static void WriteBook(XmlWriter writer, IPaperEdition element)
        {
            if (element is Book book)
            {
                writer.WriteStartElement("Book");
                writer.WriteAttributeString("AdditionalInfo", book.AdditionalInfo);
                writer.WriteAttributeString("Author", book.Author);
                writer.WriteAttributeString("CreatedPlace", book.CreatedPlace);
                writer.WriteAttributeString("EditionName", book.EditionName);
                writer.WriteAttributeString("Isbn", book.Isbn);
                writer.WriteAttributeString("Name", book.Name);
                writer.WriteAttributeString("PageNumber", book.PageNumber.ToString());
                writer.WriteAttributeString("Year", book.Year.ToString());
                writer.WriteEndElement();
            }
        }
    }
}
