using Microsoft.AspNetCore.Mvc;
using WebApiKurs.Models;
using WebApiKurs.Models.Dto;
using WebApiKurs.Models.Tables;

namespace WebApiKurs.Controllers;

[ApiController]
[Route("[controller]/{action}")]
public class QueriesController(TurAgancyContext context) : Controller
{
    // соединение с БД
    // ссылка на базу данных
    private TurAgancyContext _db = context;

    #region Запросы

    // запрос 1
    // Запрос на выборку
    // Выбирает информацию о маршрутах с заданной целью поездки
    [HttpGet]
    public JsonResult Query01([FromForm] string goal) => 
        new(_db.Roads.Where(r => r.Goal.GoalName == goal)
                     .ToList());

    // запрос 2
    // Запрос на выборку
    // Выбирает информацию о маршрутах с заданной целью поездки и стоимостью 
    // транспортных услуг менее заданного значения
    [HttpGet]
    public JsonResult Query02([FromForm] string goal, [FromForm] int price) => 
        new(_db.Roads.Where(r => r.Goal.GoalName == goal && r.Country.TransportPrice < price)
                     .ToList());


    // запрос 3
    // Запрос на выборку
    // Выбирает информацию о клиентах, совершивших поездки с заданным 
    // количеством дней пребывания в стране
    [HttpGet]
    public JsonResult Query03([FromForm] int days) => 
        new(_db.Trips.Where(t => t.DaysAmount == days)
                     .Select(t => t.Client)
                     .ToList());


    // запрос 4
    // Итоговый запрос – агрегатные функции
    // Определяет минимальную, среднюю и максимальную стоимость 1 дня пребывания
    [HttpGet]
    public JsonResult Query04()
    {
        // получить все маршруты из БД   
        var roads = _db.Roads.ToList();

        // достать все цены за 1 день пребывания по маршрутам
        var prices = roads.Select(r => r.RoadPricePerDay).ToList();

        // вычислить нужные значения
        return new((List<double>)[prices.Min(), prices.Average(), prices.Max()]);
    }


    // запрос 5
    // Итоговый запрос – агрегатные функции
    // Для проданных поездок вычисляет среднюю стоимость транспортных услуг
    [HttpGet]
    public double Query05() =>
    _db.Trips.Select(t => t.Road.Country.TransportPrice)
             .ToList()
             .Average();
    
    #endregion
}
