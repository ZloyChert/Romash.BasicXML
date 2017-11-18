using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using LibraryXML.Entities;

namespace LibraryXML
{
    public class XmlEnumeration
    {
        private readonly string filename;

        public XmlEnumeration(string filename)
        {
            this.filename = filename;
        }

        public void WriteToFile(IEnumerable<IPaperEdition> editionList)
        {
            using (var writerStream = new StreamWriter(filename))
            {
                using (XmlWriter writer = XmlWriter.Create(writerStream))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Editions");
                    foreach (var edition in editionList)
                    {
                        switch (edition)
                        {
                            case Book book:
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
                                break;
                            case Patent patent:
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
                                break;
                            case Magazine magazine:
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
                                break;
                        }
                    }
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
        }

        public IEnumerable<IPaperEdition> ReadFromFile()
        {
            using (var readerStream = new StreamReader(filename))
            {
                using (XmlReader reader = XmlReader.Create(readerStream))
                {
                    reader.ReadToFollowing("Editions");
                    reader.ReadStartElement();
                    do
                    {
                        if(reader.NodeType != XmlNodeType.Element)
                            break;
                        var xnode = XNode.ReadFrom(reader);
                        if (xnode is XElement element)
                        {
                            if (element.Name.LocalName == "Book")
                                yield return new Book
                                {
                                    AdditionalInfo = element.Attribute("AdditionalInfo")?.Value,
                                    Author = element.Attribute("Author")?.Value,
                                    CreatedPlace = element.Attribute("CreatedPlace")?.Value,
                                    EditionName = element.Attribute("EditionName")?.Value,
                                    Isbn = element.Attribute("Isbn")?.Value,
                                    Name = element.Attribute("Name")?.Value,
                                    PageNumber = int.Parse(element.Attribute("PageNumber").Value),
                                    Year = int.Parse(element.Attribute("Year").Value)
                                };

                            if (element.Name.LocalName == "Patent")
                                yield return new Patent
                                {
                                    AdditionalInfo = element.Attribute("AdditionalInfo")?.Value,
                                    Name = element.Attribute("Name")?.Value,
                                    PageNumber = int.Parse(element.Attribute("PageNumber").Value),
                                    Country = element.Attribute("Country")?.Value,
                                    Discoverier = element.Attribute("Discoverier")?.Value,
                                    PublicationDate = DateTimeOffset.Parse(element.Attribute("PublicationDate")?.Value),
                                    RegisterNumber = int.Parse(element.Attribute("RegisterNumber")?.Value),
                                    RequestDate = DateTimeOffset.Parse(element.Attribute("RequestDate")?.Value)
                                };


                            if (element.Name.LocalName == "Magazine")
                            {
                                var magazine = new Magazine();
                                magazine.AdditionalInfo = element.Attribute("AdditionalInfo")?.Value;
                                magazine.CreatedPlace = element.Attribute("CreatedPlace")?.Value;
                                magazine.EditionName = element.Attribute("EditionName")?.Value;
                                magazine.Name = element.Attribute("Name")?.Value;
                                magazine.PageNumber = int.Parse(element.Attribute("PageNumber").Value);
                                magazine.Year = int.Parse(element.Attribute("Year").Value);
                                magazine.Date = DateTimeOffset.Parse(element.Attribute("Date").Value);
                                magazine.Issn = element.Attribute("Issn")?.Value;
                                magazine.Number = int.Parse(element.Attribute("Number").Value);
                                yield return magazine;
                            }
                        }
                    } while (!reader.EOF);
                }
            }
        }
    }
}
