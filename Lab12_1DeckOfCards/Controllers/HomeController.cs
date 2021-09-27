using Lab12_1DeckOfCards.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lab12_1DeckOfCards.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> NewDeck()
        {
            string domain = "https://deckofcardsapi.com";
            string path = "api/deck/new/draw/?count=5";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(domain);
            var connection = await client.GetAsync(path);
            Root result = await connection.Content.ReadAsAsync<Root>();

            return View(result);
        }

        public async Task<IActionResult> Draw(string deckId)
        {
            string domain = "https://deckofcardsapi.com";
            string path = $"api/deck/{deckId}/draw/?count=5";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(domain);
            var connection = await client.GetAsync(path);
            Root result = await connection.Content.ReadAsAsync<Root>();

            return View("NewDeck", result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
