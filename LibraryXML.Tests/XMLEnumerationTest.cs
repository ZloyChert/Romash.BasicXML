using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryXML.ElementReaders;
using LibraryXML.ElementWriters;
using LibraryXML.Entities;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace LibraryXML.Tests
{
    [TestFixture]
    public class XmlEnumerationTest
    {
        [Test]
        public void WriteReadFile()
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
            List<IPaperEdition> list = new List<IPaperEdition> { b, m, p, b, p };
            var fac = new PaperEditionFactory();
            fac.AddInitializer(BookReader.ReadBook, "Book");
            fac.AddInitializer(PatentReader.ReadPatent, "Patent");
            fac.AddInitializer(MagazineReader.ReadMagazine, "Magazine");

            XmlElementWriter wr = new XmlElementWriter();
            wr.AddWriter(typeof(Book), BookWriter.WriteBook);
            wr.AddWriter(typeof(Magazine), MagazineWriter.WriteMagazine);
            wr.AddWriter(typeof(Patent), PatentWriter.WritePatent);

            XmlEnumeration xml = new XmlEnumeration("library.xml", fac, wr);
            xml.WriteToFile(list);
            var readList = xml.ReadFromFile().ToList();
            CollectionAssert.AreEqual(list, readList);
        }
    }
}
