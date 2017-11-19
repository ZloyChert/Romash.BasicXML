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
        private readonly string root = "Editions";
        private readonly string filename;
        public PaperEditionFactory EditionFactory { get; }
        public XmlElementWriter XmlElementWriter { get; }

        public XmlEnumeration(string filename, PaperEditionFactory factory, XmlElementWriter elementWriter)
        {
            this.filename = filename;
            EditionFactory = factory;
            XmlElementWriter = elementWriter;
        }

        public void WriteToFile(IEnumerable<IPaperEdition> editionList)
        {
            using (var writerStream = new StreamWriter(filename))
            {
                using (XmlWriter writer = XmlWriter.Create(writerStream))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement(root);
                    foreach (var edition in editionList)
                    {
                        XmlElementWriter.WriteElement(writer, edition);
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
                    reader.ReadToFollowing(root);
                    reader.ReadStartElement();
                    do
                    {
                        if (reader.NodeType != XmlNodeType.Element)
                        {
                            break;
                        }
                        XNode xnode = XNode.ReadFrom(reader);
                        if (xnode is XElement element)
                        {
                            yield return EditionFactory.CreateInstatnce(element);
                        }
                    } while (!reader.EOF);
                }
            }
        }
    }
}
