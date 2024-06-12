using Microsoft.AspNetCore.Mvc;
using WebApiKurs.Models;
using WebApiKurs.Models.Tables;

namespace WebApiKurs.Controllers;

[ApiController]
[Route("[controller]/{action}")]
public class GoalsController(TurAgancyContext context) : Controller
{
    // соединение с БД
    // ссылка на базу данных
    private TurAgancyContext _db = context;

    [HttpGet]
    public JsonResult Get() => new(_db.Goals.ToList());
}
