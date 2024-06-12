using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApiKurs.Models.Configurations;

namespace WebApiKurs.Models.Tables;

// класс описывающий запись в таблице Целей поездки
[EntityTypeConfiguration(typeof(GoalConfiguration))]
public class Goal
{
    // ПК сущности
    public int Id { get; set; }

    // Название цели поездки
    public string GoalName { get; set; } = string.Empty;

    // стоимость для пребывания в стране
    public int PricePerDay { get; set; }

    #region Настройка для внешних ключей

    // Навигационные свойства для связи "один ко многим"
    // Roads     : вспомогательная сущность для связи "один ко многим"
    [JsonIgnore]
    public virtual List<Road> Roads { get; set; } = new();

    #endregion
}
