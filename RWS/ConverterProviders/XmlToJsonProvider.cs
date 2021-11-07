using Newtonsoft.Json;
using RWS.Contracts;
using System.Xml.Linq;

namespace RWS.ConverterProviders
{
    public class XmlToJsonProvider : ConverterProvider
    {
        public string Convert(string input)
        {
            var xdoc = XDocument.Parse(input);
            var doc = new
            {
                Title = xdoc.Root.Element("title").Value,
                Text = xdoc.Root.Element("text").Value
            };
            var serializedInput = JsonConvert.SerializeObject(doc);
            return serializedInput;
        }
    }
}
