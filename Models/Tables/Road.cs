using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApiKurs.Models.Configurations;

namespace WebApiKurs.Models.Tables;

// класс описывающий запись в таблице Маршруты
[EntityTypeConfiguration(typeof(RoadConfiguration))]
public class Road
{
    // ПК сущности
    public int Id { get; set; }

    // доп. поле стоимость поездки
    // указываем nullable т.к. при создании модели внешние ключи не будут подвязаны, 
    // но модель постарается получить данные
    [JsonIgnore]
    public int RoadPricePerDay => (Country?.PricePerDay + Goal?.PricePerDay ?? 0);

    #region Настройка для внешних ключей

    // Страна, в которую идёт маршрут
    // навигационное свойство - связь со страной
    // отношение "один-ко-многим" (1:М), сторона "один"
    // внешний ключ
    public int IdCountry { get; set; }
    public virtual Country Country { get; set; } = null!;

    // Цель, с которой осуществляется поездка
    // навигационное свойство - связь с целью поездки
    // отношение "один-ко-многим" (1:М), сторона "один"
    // внешний ключ
    public int IdGoal { get; set; }
    public virtual Goal Goal { get; set; } = null!;

    // Навигационные свойства для связи "один ко многим"
    // Trips     : вспомогательная сущность для связи "один ко многим"
    [JsonIgnore]
    public virtual List<Trip> Trips { get; set; } = new();

    #endregion
}
