using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using LibraryXML;
using LibraryXML.Entities;

namespace ConsoleTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Book b = new Book
            {
                AdditionalInfo = "ai",
                Author = "au",
                CreatedPlace = "cp",
                EditionName = "en",
                Isbn = "is45",
                Name = "na",
                PageNumber = 45,
                Year = 1998
            };

            Magazine m = new Magazine
            {
                AdditionalInfo = "ai",
                CreatedPlace = "cp",
                Date = DateTimeOffset.Now,
                EditionName = "en",
                Issn = "asd5",
                Name = "naa",
                Number = 5,
                PageNumber = 45,
                Year = 1994
            };

            Patent p = new Patent
            {
                AdditionalInfo = "ai",
                Name = "naa",
                PageNumber = 45,
                Country = "co",
                Discoverier = "Pavel",
                PublicationDate = DateTimeOffset.MaxValue,
                RegisterNumber = 456,
                RequestDate = DateTimeOffset.MinValue
            };
            List<IPaperEdition> list = new List<IPaperEdition>{b, m, p};

            XmlEnumeration xml = new XmlEnumeration("library.xml");
            xml.WriteToFile(list);
            var a = xml.ReadFromFile().ToList();
            Console.Read();
        }
    }
}
