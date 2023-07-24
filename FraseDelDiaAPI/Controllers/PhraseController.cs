using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HtmlAgilityPack;
using Newtonsoft.Json;

namespace FraseDelDiaAPI.Controllers
{
    public class Phrase
    {
        public string phrase;
        public string author;
    }

    [Route("api/[controller]")]
    [ApiController]
    public class PhraseController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public async Task<string> GetAsync()
        {
            // Getting the HTML
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://proverbia.net/frase-del-dia");
            var pageContents = await response.Content.ReadAsStringAsync();

            // Extracting Content Test
            HtmlDocument pageDocument = new HtmlDocument();
            pageDocument.LoadHtml(pageContents);

            string statment = pageDocument.DocumentNode.SelectSingleNode("(//blockquote[contains(@class,'bsquote')]//p)[1]").InnerText.Trim();

            string author = pageDocument.DocumentNode.SelectSingleNode("(//blockquote[contains(@class,'bsquote')]//a)[1]").InnerText.Trim();
            author = author.Replace("&mdash;", string.Empty);

            Phrase resultantPhrase = new Phrase
            {
                phrase = statment,
                author = author
            };

            return JsonConvert.SerializeObject(resultantPhrase);
        }
    }
}
