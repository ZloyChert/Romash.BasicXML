using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using LibraryXML.Entities;

namespace LibraryXML
{
    public class XmlElementWriter
    {
        private readonly Dictionary<Type, Action<XmlWriter, IPaperEdition>> editionWriters = new Dictionary<Type, Action<XmlWriter, IPaperEdition>>();

        public void AddWriter(Type type, Action<XmlWriter, IPaperEdition> writer)
        {
            if (editionWriters.ContainsKey(type))
            {
                throw new ArgumentException("Writer for this type has already added");
            }
            editionWriters.Add(type, writer);
        }

        public void WriteElement(XmlWriter writer, IPaperEdition edition)
        {
            if (!editionWriters.ContainsKey(edition.GetType()))
            {
                throw new ArgumentException("Writer for this type hasn't added yet");
            }
            editionWriters[edition.GetType()](writer, edition);
        }
    }
}
