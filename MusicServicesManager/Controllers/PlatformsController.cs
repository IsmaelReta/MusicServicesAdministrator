using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicServicesManager.Data;
using MusicServicesManager.Models;
using Newtonsoft.Json;


namespace MusicServicesManager.Controllers
{
    public class PlatformsController : Controller
    {
        // API url
        private readonly string baseURL = "http://localhost:5293/";
        // GET: Platforms
        public async Task<IActionResult> Index()
        {
            List<Platform> lstPlatform = [];
            using (var _httpClient = new HttpClient())
            {
                _httpClient.BaseAddress = new Uri(baseURL + "api/");
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage getData = await _httpClient.GetAsync("Platforms");

                if (getData.IsSuccessStatusCode)
                {
                    string result = getData.Content.ReadAsStringAsync().Result;
                    lstPlatform = JsonConvert.DeserializeObject<List<Platform>>(result)!;
                }
                else
                {
                    return View("ErrorPage");
                }
            }
            return View(lstPlatform);
        }

        public Task<IActionResult> Create()
        {
            return Task.FromResult<IActionResult>(View());
        }
        public async Task<IActionResult> CreatePlatform(Platform platformDTO)
        {
            using var _httpClient = new HttpClient();
            
                _httpClient.BaseAddress = new Uri(baseURL + "api/platforms");
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage getData = await _httpClient.PostAsJsonAsync("", platformDTO);

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
            Platform platformDetails = new();

            using (var _httpClient = new HttpClient())
            {
                _httpClient.BaseAddress = new Uri(baseURL + "api/platforms/");
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage getData = await _httpClient.GetAsync($"{id}");

                if (getData.IsSuccessStatusCode)
                {
                    string result = getData.Content.ReadAsStringAsync().Result;
                    platformDetails = JsonConvert.DeserializeObject<Platform>(result)!;
                }
                else
                {
                    return View("ErrorPage");
                }
            }
            return View(platformDetails);

        }

        public async Task<IActionResult> UpdatePlatform(Guid Id, Platform platformDTO)
        {
            using var _httpClient = new HttpClient();

            _httpClient.BaseAddress = new Uri(baseURL + "api/platforms/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage getData = await _httpClient.PutAsJsonAsync($"{Id}", platformDTO);

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
            Platform platformDetails = new();

            using (var _httpClient = new HttpClient())
            {
                _httpClient.BaseAddress = new Uri(baseURL + "api/platforms/");
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage getData = await _httpClient.GetAsync($"{id}");

                if (getData.IsSuccessStatusCode)
                {
                    string result = getData.Content.ReadAsStringAsync().Result;
                    platformDetails = JsonConvert.DeserializeObject<Platform>(result)!;
                }
                else
                {
                    return View("ErrorPage");
                }
            }
            return View(platformDetails);

        }

        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            using var _httpClient = new HttpClient();
            
                _httpClient.BaseAddress = new Uri(baseURL + "api/platforms/");
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