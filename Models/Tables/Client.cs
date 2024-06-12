using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApiKurs.Models.Configurations;

namespace WebApiKurs.Models.Tables;

// класс описывающий запись в таблице Клиенты
[EntityTypeConfiguration(typeof(ClientConfiguration))]
public class Client
{    
    // ПК сущности
    public int Id { get; set; }

    // имя
    public string Name { get; set; } = string.Empty;

    // фамилия
    public string Surname {  get; set; } = string.Empty;

    // отчество
    public string Patronymic { get; set; } = string.Empty;

    // пасспорт
    public string Passport { get; set; } = string.Empty;

    #region Настройка для внешних ключей

    // Навигационные свойства для связи "один ко многим"
    // Trips     : вспомогательная сущность для связи "один ко многим"
    [JsonIgnore]
    public virtual List<Trip> Trips { get; set; } = new();

    #endregion
}
