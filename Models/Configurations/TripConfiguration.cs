using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebApiKurs.Models.Tables;

namespace WebApiKurs.Models.Configurations;

// класс отвечающий за настройку и заполнение таблицы Поездки
public class TripConfiguration : IEntityTypeConfiguration<Trip>
{
    void IEntityTypeConfiguration<Trip>.Configure(EntityTypeBuilder<Trip> builder)
    {
        // При помощи Fluent API настраиваем модель (таблицу, столбцы, свойства)
        // настроить SQL-ограничение поля DateStart для Trip:
        // дата поездки не может быть будущей 
        builder
            //                                  имя поля    SQL-выражение для ограничения
            .ToTable(t => t.HasCheckConstraint("DateStart", "DateStart <= GetDate()"));

        // настроить ограничение поля DaysAmount для Trip:
        // дней пребывания должно быть больше 0
        builder
            //                                  имя поля    SQL-выражение для ограничения
            .ToTable(t => t.HasCheckConstraint("DaysAmount", "DaysAmount > 0"));

        // Настройка связи с таблицей Roads "один-ко-многим"
        builder
            .HasOne(t => t.Road)
            .WithMany(r => r.Trips)
            .HasForeignKey(t => t.IdRoad)
            .OnDelete(DeleteBehavior.NoAction);

        // Настройка связи с таблицей Clients "один-ко-многим"
        builder
            .HasOne(t => t.Client)
            .WithMany(c => c.Trips)
            .HasForeignKey(t => t.IdClient)
            .OnDelete(DeleteBehavior.NoAction);


        // инициализация
        var trips = new List<Trip> {

            new() {Id =  1, IdClient =  2, IdRoad =  3, DateStart = new DateTime(2023,  7, 10), DaysAmount =  4},
            new() {Id =  2, IdClient =  7, IdRoad =  8, DateStart = new DateTime(2023,  8, 10), DaysAmount = 21},
            new() {Id =  3, IdClient =  9, IdRoad =  2, DateStart = new DateTime(2023,  3, 21), DaysAmount =  3},
            new() {Id =  4, IdClient =  3, IdRoad =  5, DateStart = new DateTime(2023,  7, 11), DaysAmount = 37},
            new() {Id =  5, IdClient =  1, IdRoad =  2, DateStart = new DateTime(2023,  8,  1), DaysAmount = 29},
            new() {Id =  6, IdClient =  6, IdRoad =  7, DateStart = new DateTime(2023,  5,  9), DaysAmount = 41},
            new() {Id =  7, IdClient =  4, IdRoad = 10, DateStart = new DateTime(2023,  6,  7), DaysAmount = 11},
            new() {Id =  8, IdClient =  5, IdRoad =  2, DateStart = new DateTime(2023,  5, 31), DaysAmount =  3},
            new() {Id =  9, IdClient =  8, IdRoad =  9, DateStart = new DateTime(2023,  7, 17), DaysAmount = 43},
            new() {Id = 10, IdClient = 10, IdRoad =  6, DateStart = new DateTime(2023, 10, 10), DaysAmount = 25},
            new() {Id = 11, IdClient =  2, IdRoad =  1, DateStart = new DateTime(2023,  7, 10), DaysAmount = 25},
            new() {Id = 12, IdClient =  2, IdRoad =  8, DateStart = new DateTime(2023, 11, 10), DaysAmount = 45}
        };
        builder.HasData(trips);
    }
}
