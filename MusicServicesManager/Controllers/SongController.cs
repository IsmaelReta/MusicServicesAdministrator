using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using MusicServicesManager.Models;
using Newtonsoft.Json;


namespace MusicServicesManager.Controllers
{
    public class SongsController : Controller
    {
        private readonly AuthorsController _authorsController = new();

        // API url
        private readonly string baseURL = "http://localhost:5293/";

        // GET: Songs
        public async Task<IActionResult> Index()
        {
            List<Song> lstSong = [];
            using (var _httpClient = new HttpClient())
            {
                _httpClient.BaseAddress = new Uri(baseURL + "api/");
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage getData = await _httpClient.GetAsync("Songs");

                if (getData.IsSuccessStatusCode)
                {
                    string result = getData.Content.ReadAsStringAsync().Result;
                    lstSong = JsonConvert.DeserializeObject<List<Song>>(result)!;
                }
                else
                {
                    return View("ErrorPage");
                }
            }
            return View(lstSong);
        }

        public Task<IActionResult> Create()
        {
            return Task.FromResult<IActionResult>(View());
        }
        public async Task<IActionResult> CreateSong(Song SongDTO)
        {
            using var _httpClient = new HttpClient();

            _httpClient.BaseAddress = new Uri(baseURL + "api/Songs");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage getData = await _httpClient.PostAsJsonAsync("", SongDTO);

            if (getData.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("ErrorPage");
            }


        }

        public async Task<IActionResult> Details(Guid id)
        {
            Song SongDetails = new();

            using (var _httpClient = new HttpClient())
            {
                _httpClient.BaseAddress = new Uri(baseURL + "api/Songs/");
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage getData = await _httpClient.GetAsync($"{id}");

                if (getData.IsSuccessStatusCode)
                {
                    string result = getData.Content.ReadAsStringAsync().Result;
                    SongDetails = JsonConvert.DeserializeObject<Song>(result)!;
                    ViewBag.author = new Author()
                    {
                        FullName = _authorsController.DetailName(id).ToString(),
                    };
                }
                else
                {
                    return View("ErrorPage");
                }
            }
            return View(SongDetails);

        }

        public async Task<IActionResult> UpdateSong(Guid Id, Song SongDTO)
        {
            using var _httpClient = new HttpClient();

            _httpClient.BaseAddress = new Uri(baseURL + "api/Songs/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage getData = await _httpClient.PutAsJsonAsync($"{Id}", SongDTO);

            if (getData.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("ErrorPage");
            }


        }

        public async Task<IActionResult> Delete(Guid id)
        {
            Song SongDetails = new();

            using (var _httpClient = new HttpClient())
            {
                _httpClient.BaseAddress = new Uri(baseURL + "api/Songs/");
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage getData = await _httpClient.GetAsync($"{id}");

                if (getData.IsSuccessStatusCode)
                {
                    string result = getData.Content.ReadAsStringAsync().Result;
                    SongDetails = JsonConvert.DeserializeObject<Song>(result)!;
                }
                else
                {
                    return View("ErrorPage");
                }
            }
            return View(SongDetails);

        }

        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            using var _httpClient = new HttpClient();

            _httpClient.BaseAddress = new Uri(baseURL + "api/Songs/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage getData = await _httpClient.DeleteAsync($"{id}");

            if (getData.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("ErrorPage");
            }

        }

        public IActionResult ErrorPage()
        {
            return View();
        }
    }
}