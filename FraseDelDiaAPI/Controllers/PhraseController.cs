using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
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
            // Getting the HTML 2
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("http://www.frasedehoy.com");
            var pageContents = await response.Content.ReadAsStringAsync();

            // Extracting Content Test
            HtmlDocument pageDocument = new HtmlDocument();
            pageDocument.LoadHtml(pageContents);

            string statment = pageDocument.DocumentNode.SelectSingleNode("(//div[contains(@id,'frase_container')]//h1)[1]").InnerText;
            statment = statment.Replace("&quot;", string.Empty);

            string author = pageDocument.DocumentNode.SelectSingleNode("(//div[contains(@id,'frase_container')]//p)[1]").InnerText;
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
