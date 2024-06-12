using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApiKurs.Models.Configurations;

namespace WebApiKurs.Models.Tables;

// класс описывающий запись в таблице Стран
[EntityTypeConfiguration(typeof(CountryConfiguration))]
public class Country
{
    // ПК сущности
    public int Id { get; set; }

    // Название страны
    public string CountryName { get; set; } = string.Empty;

    // стоимость транспортных услуг в стране
    public int TransportPrice { get; set; }

    // стоимость оформления визы
    public int VisaPrice { get; set; }

    // стоимость для пребывания в стране
    public int PricePerDay { get; set; }

    #region Настройка для внешних ключей

    // Навигационные свойства для связи "один ко многим"
    // Roads     : вспомогательная сущность для связи "один ко многим"
    [JsonIgnore]
    public virtual List<Road> Roads { get; set; } = new();

    #endregion
}

