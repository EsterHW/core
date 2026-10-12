using Microsoft.AspNetCore.Mvc;

namespace core.Controllers;

[ApiController]
[Route("[controller]")]
public class JewerlyStoreController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "gold", "silver", "copper", "goldfeed", "silver plate", "gold plate", "Pearls", "Diamonds"
    };

    private readonly ILogger<JewerlyStoreController> _logger;

    public JewerlyStoreController(ILogger<JewerlyStoreController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetJewerlyStore")]
    public IEnumerable<JewerlyStore> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new JewerlyStore
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Price = Random.Shared.Next(500, 5000),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}


