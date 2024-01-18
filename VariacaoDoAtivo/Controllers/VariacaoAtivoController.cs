using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using VariacaoDoAtivo.Data;
using VariacaoDoAtivo.Interfaces;
using VariacaoDoAtivo.Models;
using VariacaoDoAtivo.Repository;
using static System.Net.WebRequestMethods;

namespace VariacaoDoAtivo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VariacaoAtivoController : Controller
    {
        private readonly Dao? _dao;
        private readonly IVariacao _voivoRepository;

        public VariacaoAtivoController(Dao dao, IVariacao variacaoAtivoRepository)
        {
            _dao = dao; _voivoRepository = variacaoAtivoRepository;
        }
        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var list = _voivoRepository.GetAll();

        //    return View(list);
        //}


        [HttpGet]
        public async Task<IActionResult> GetUltimos30Dias()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string baseUrl = "https://query2.finance.yahoo.com/v8/finance/chart/PETR4.SA";

                httpClient.Timeout = TimeSpan.FromMinutes(3);
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

                HttpResponseMessage response = await httpClient.GetAsync(baseUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();

                    Root? result = JsonConvert.DeserializeObject<Root>(responseData);

                    if (result?.chart?.result?.Count > 0 && result?.chart?.result.Count != null)
                    {
                        _voivoRepository.Insert(result.chart.result[0].meta);

                        var last30DaysData = result.chart.result[0].indicators.quote[0].open.Take(30).ToList();

                        var variation = last30DaysData.Last() - last30DaysData.First();

                        var responseModel = new
                        {
                            Last30DaysData = last30DaysData,
                            PriceVariation = variation
                        };

                        return Ok(responseModel);
                    }
                    else
                    {
                        return NotFound("Dados não encontrados");
                    }
                }
                else
                {
                    return StatusCode((int)response.StatusCode, "Falha ao buscar os dados");
                }
            }
        }
    }
}
