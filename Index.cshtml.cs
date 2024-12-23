using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Clima.Models;
using Clima.Data;
using Clima.Services;

namespace Clima.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly ApplicationDbContext _context;
    private readonly WeatherService _weatherService;

    public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context, WeatherService weatherService)
    {
        _logger = logger;
        _context = context;
        _weatherService = weatherService;
    }

    [BindProperty]
    public string Cidade { get; set; }

    public Clima.Models.Weather ClimaAtual { get; set; }

    public void OnGet()
    {
        TempData.Remove("Erro");
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (string.IsNullOrEmpty(Cidade))
        {
            TempData["Erro"] = "Por favor, insira o nome da cidade.";
            return Page();
        }

        try
        {
            ClimaAtual = await _weatherService.GetWeatherAsync(Cidade);

            if (ClimaAtual != null)
            {
                _context.Climas.Add(ClimaAtual);
                await _context.SaveChangesAsync();
            }
            else
            {
                TempData["Erro"] = "Não foi possível encontrar os dados para a cidade informada. Por favor, verifique o nome e tente novamente.";
            }
        }
        catch (HttpRequestException)
        {
            TempData["Erro"] = "Não foi possível encontrar os dados para a cidade informada. Por favor, verifique o nome e tente novamente.";
        }
        catch (Exception)
        {
            TempData["Erro"] = "Não foi possível encontrar os dados para a cidade informada. Por favor, verifique o nome e tente novamente.";
        }
        return Page();
    }
}