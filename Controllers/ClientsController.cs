using Microsoft.AspNetCore.Mvc;
using WebApiKurs.Models;
using WebApiKurs.Models.Tables;

namespace WebApiKurs.Controllers;

[ApiController]
[Route("[controller]/{action}")]
public class ClientsController(TurAgancyContext context) : Controller
{
    // соединение с БД
    // ссылка на базу данных
    private TurAgancyContext _db = context;

    [HttpGet]
    public IEnumerable<Client> Get() => _db.Clients.ToList();
}
