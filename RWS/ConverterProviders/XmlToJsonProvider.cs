using Newtonsoft.Json;
using RWS.Contracts;
using System;
using System.Xml.Linq;

namespace RWS.ConverterProviders
{
    public class XmlToJsonProvider : ConverterProvider
    {
        public Result<string> Convert(string input)
        {
            try
            {
                var xDocument = XDocument.Parse(input);
                var document = new
                {
                    Title = xDocument.Root.Element("title").Value,
                    Text = xDocument.Root.Element("text").Value
                };
                var result = JsonConvert.SerializeObject(document);
                return Result<string>.Success(result);
            }
            catch (Exception ex)
            {
                return Result<string>.Failure(ex.Message);
            }

        }
    }
}
