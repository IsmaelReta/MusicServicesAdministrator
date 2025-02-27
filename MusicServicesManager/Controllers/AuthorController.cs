using Microsoft.AspNetCore.Mvc;
using MusicServicesManager.Models;
using Newtonsoft.Json;


namespace MusicServicesManager.Controllers
{
    public class AuthorsController : Controller
    {
        // API url
        private readonly string baseURL = "http://localhost:5293/";
        // GET: Authors
        public async Task<IActionResult> Index()
        {
            List<Author> lstAuthor = [];
            using (var _httpClient = new HttpClient())
            {
                _httpClient.BaseAddress = new Uri(baseURL + "api/");
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage getData = await _httpClient.GetAsync("Authors");

                if (getData.IsSuccessStatusCode)
                {
                    string result = getData.Content.ReadAsStringAsync().Result;
                    lstAuthor = JsonConvert.DeserializeObject<List<Author>>(result)!;
                }
                else
                {
                    return View("ErrorPage");
                }
            }
            return View(lstAuthor);
        }

        public Task<IActionResult> Create()
        {
            return Task.FromResult<IActionResult>(View());
        }
        public async Task<IActionResult> CreateAuthor(Author AuthorDTO)
        {
            using var _httpClient = new HttpClient();

            _httpClient.BaseAddress = new Uri(baseURL + "api/Authors");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage getData = await _httpClient.PostAsJsonAsync("", AuthorDTO);

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
            Author AuthorDetails = new();

            using (var _httpClient = new HttpClient())
            {
                _httpClient.BaseAddress = new Uri(baseURL + "api/Authors/");
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage getData = await _httpClient.GetAsync($"{id}");

                if (getData.IsSuccessStatusCode)
                {
                    string result = getData.Content.ReadAsStringAsync().Result;
                    AuthorDetails = JsonConvert.DeserializeObject<Author>(result)!;
                }
                else
                {
                    return View("ErrorPage");
                }
            }
            return View(AuthorDetails);

        }

        public async Task<IActionResult> DetailName(Guid id)
        {
            Author AuthorDetails = new();

            using (var _httpClient = new HttpClient())
            {
                _httpClient.BaseAddress = new Uri(baseURL + "api/Authors/");
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage getData = await _httpClient.GetAsync($"{id}/name");

                if (getData.IsSuccessStatusCode)
                {
                    string result = getData.Content.ReadAsStringAsync().Result;
                    AuthorDetails = JsonConvert.DeserializeObject<Author>(result)!;
                }
                else
                {
                    return View("ErrorPage");
                }
            }

            #pragma warning disable CS8604 
            return Content(AuthorDetails.FullName);
            #pragma warning restore CS8604 

        }

        public async Task<IActionResult> UpdateAuthor(Guid Id, Author AuthorDTO)
        {
            using var _httpClient = new HttpClient();

            _httpClient.BaseAddress = new Uri(baseURL + "api/Authors/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage getData = await _httpClient.PutAsJsonAsync($"{Id}", AuthorDTO);

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
            Author AuthorDetails = new();

            using (var _httpClient = new HttpClient())
            {
                _httpClient.BaseAddress = new Uri(baseURL + "api/Authors/");
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage getData = await _httpClient.GetAsync($"{id}");

                if (getData.IsSuccessStatusCode)
                {
                    string result = getData.Content.ReadAsStringAsync().Result;
                    AuthorDetails = JsonConvert.DeserializeObject<Author>(result)!;
                }
                else
                {
                    return View("ErrorPage");
                }
            }
            return View(AuthorDetails);

        }

        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            using var _httpClient = new HttpClient();

            _httpClient.BaseAddress = new Uri(baseURL + "api/Authors/");
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