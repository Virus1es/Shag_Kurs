using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebApiKurs.Models.Tables;

namespace WebApiKurs.Models.Configurations;

// класс отвечающий за настройку и заполнение таблицы Страны
public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    void IEntityTypeConfiguration<Country>.Configure(EntityTypeBuilder<Country> builder)
    {
        // При помощи Fluent API настраиваем модель (таблицу, столбцы, свойства)

        // настроить ограничение поля TransportPrice для Country:
        // цена за транспортные услуги должна быть больше 0
        builder
            //                                  имя поля    SQL-выражение для ограничения
            .ToTable(t => t.HasCheckConstraint("TransportPrice", "TransportPrice > 0"));

        // настроить ограничение поля VisaPrice для Country:
        // цена за оформление визы должна быть больше 0
        builder
            //                                  имя поля    SQL-выражение для ограничения
            .ToTable(t => t.HasCheckConstraint("VisaPrice", "VisaPrice > 0"));

        // настроить ограничение поля PricePerDay для Country:
        // цена за 1 день пребывания в стране должна быть больше 0
        builder
            //                                  имя поля    SQL-выражение для ограничения
            .ToTable(t => t.HasCheckConstraint("PricePerDay", "PricePerDay > 0"));

        // инициализация
        var countries = new List<Country> {

            new() {Id =  1, CountryName =            "США", TransportPrice = 3000, VisaPrice = 3500, PricePerDay = 1500},
            new() {Id =  2, CountryName =       "Германия", TransportPrice = 2800, VisaPrice = 2000, PricePerDay = 1300},
            new() {Id =  3, CountryName =         "Канада", TransportPrice = 2900, VisaPrice = 1500, PricePerDay =  900},
            new() {Id =  4, CountryName =        "Франция", TransportPrice = 3200, VisaPrice = 1900, PricePerDay = 1100},
            new() {Id =  5, CountryName = "Великобритания", TransportPrice = 3500, VisaPrice = 2400, PricePerDay = 1300},
            new() {Id =  6, CountryName =        "Испания", TransportPrice = 2800, VisaPrice = 2600, PricePerDay = 1450},
            new() {Id =  7, CountryName =         "Италия", TransportPrice = 3000, VisaPrice = 3600, PricePerDay = 1600},
            new() {Id =  8, CountryName =         "Япония", TransportPrice = 3000, VisaPrice = 2800, PricePerDay = 1250},
            new() {Id =  9, CountryName =          "Китай", TransportPrice = 2600, VisaPrice = 2300, PricePerDay =  900},
            new() {Id = 10, CountryName =            "ОАЭ", TransportPrice = 4000, VisaPrice = 3000, PricePerDay = 1300}
        };
        builder.HasData(countries);
    }
}