using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApiKurs.Models.Configurations;

namespace WebApiKurs.Models.Tables;

// класс описывающий запись в таблице Поездки
[EntityTypeConfiguration(typeof(TripConfiguration))]
public class Trip
{
    // ПК сущности
    public int Id { get; set; }

    // Дата прибытия в страну
    public DateTime DateStart { get; set; }

    // Количество дней пребывания в стране
    public int DaysAmount { get; set; }

    // доп поле Стоимость поездки 
    // указываем nullable т.к. при создании модели внешние ключи не будут подвязаны, 
    // но модель постарается получить данные
    [JsonIgnore]
    public int TripPrice => (Road?.RoadPricePerDay * DaysAmount + Road?.Country.TransportPrice + Road?.Country.VisaPrice ?? 0);

    #region Настройка для внешних ключей

    // Маршрут поезки
    // навигационное свойство - связь с маршрутами
    // отношение "один-ко-многим" (1:М), сторона "один"
    // внешний ключ
    public int IdRoad { get; set; }
    public virtual Road Road { get; set; } = null!;

    // Клиент совершивший поездку
    // навигационное свойство - связь с клиентами
    // отношение "один-ко-многим" (1:М), сторона "один"
    // внешний ключ
    public int IdClient { get; set; }
    public virtual Client Client { get; set; } = null!;

    #endregion
}
