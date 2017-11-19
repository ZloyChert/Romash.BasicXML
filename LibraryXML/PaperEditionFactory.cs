using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using LibraryXML.Entities;

namespace LibraryXML
{
    public class PaperEditionFactory
    {
        private readonly Dictionary<string, Func<XElement, IPaperEdition>> initializers = new Dictionary<string, Func<XElement, IPaperEdition>>();

        public void AddInitializer(Func<XElement, IPaperEdition> initializer, string name)
        {
            if (initializers.ContainsKey(name))
            {
                throw new ArgumentException("This parser have already added");
            }
            initializers.Add(name, initializer);
        }

        public IPaperEdition CreateInstatnce(XElement element)
        {
            if (!initializers.ContainsKey(element.Name.LocalName))
            {
                throw new ArgumentException("There is no parser for this name");
            }
            return initializers[element.Name.LocalName](element);
        }
    }
}
