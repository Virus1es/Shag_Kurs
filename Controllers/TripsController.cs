using Microsoft.AspNetCore.Mvc;
using WebApiKurs.Models;
using WebApiKurs.Models.Tables;

namespace WebApiKurs.Controllers;

[ApiController]
[Route("[controller]/{action}")]
public class TripsController(TurAgancyContext context) : Controller
{    
    // соединение с БД
    // ссылка на базу данных
    private TurAgancyContext _db = context;

    [HttpGet]
    // IEnumerable<Trip>
    public JsonResult Get() => new(_db.Trips.ToList());

    // POST-запрос (модификация данных на сервере)
    [HttpPost]
    public string Post([FromForm] int id, [FromForm] int IdClient, [FromForm] int IdRoad, 
                       [FromForm] DateTime DateStart, [FromForm] int DaysAmount)
    {
        try
        {
            Trip trip = new()
            {
                // имитируем изменение данных
                Id = id,
                IdClient = IdClient,
                IdRoad = IdRoad,
                DateStart = DateStart,
                DaysAmount = DaysAmount
            };

            // сохраняем изменения
            _db.Trips.Update(trip);
            _db.SaveChanges();

            return "";
        }
        catch (Exception ex) { 
            return ex.Message;
        }
    }

    // PUT-запрос (создание данных на сервере)
    [HttpPut]
    public string Put([FromForm] int id, [FromForm] int IdClient, [FromForm] int IdRoad,
                       [FromForm] DateTime DateStart, [FromForm] int DaysAmount)
    {
        try
        {
            // находим максимальный индекс для вставки
            int maxid = _db.Trips.Select(t => t.Id).Max();

            // создание новой поездки
            Trip trip = new()
            {
                Id = id,
                IdClient = IdClient,
                IdRoad = IdRoad,
                DateStart = DateStart,
                DaysAmount = DaysAmount
            };

            // сохраняем изменения
            _db.Trips.Add(trip);
            _db.SaveChanges();
            return "";
        }
        catch (Exception ex) { 
            return ex.Message;
        }
    } // Put


    // DELETE-запрос (удаление данных на сервере)
    [HttpDelete]
    public string Delete([FromForm] int id)
    {
        try
        {
            // найти нужную поездку
            Trip trip = _db.Trips.First(t => t.Id == id);

            // если нашли удаляем
            if (trip != null) _db.Trips.Remove(trip);

            // сохраняем изменения
            _db.SaveChanges();

            return "";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    } // Delete

}
