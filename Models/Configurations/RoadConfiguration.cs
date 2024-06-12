using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebApiKurs.Models.Tables;

namespace WebApiKurs.Models.Configurations;

// класс отвечающий за настройку и заполнение таблицы Маршруты
public class RoadConfiguration : IEntityTypeConfiguration<Road>
{
    void IEntityTypeConfiguration<Road>.Configure(EntityTypeBuilder<Road> builder)
    {
        // При помощи Fluent API настраиваем модель (таблицу, столбцы, свойства)

        // Настройка связи с таблицей Countries "один-ко-многим"
        builder
            .HasOne(r => r.Country)
            .WithMany(c => c.Roads)
            .HasForeignKey(r => r.IdCountry)
            .OnDelete(DeleteBehavior.NoAction);

        // Настройка связи с таблицей Goals "один-ко-многим"
        builder
            .HasOne(r => r.Goal)
            .WithMany(g => g.Roads)
            .HasForeignKey(r => r.IdGoal)
            .OnDelete(DeleteBehavior.NoAction);

        // инициализация
        var roads = new List<Road> {
            new() {Id =  1, IdCountry =  1, IdGoal = 5},
            new() {Id =  2, IdCountry =  1, IdGoal = 1},
            new() {Id =  3, IdCountry =  3, IdGoal = 7},
            new() {Id =  4, IdCountry =  7, IdGoal = 3},
            new() {Id =  5, IdCountry =  4, IdGoal = 8},
            new() {Id =  6, IdCountry =  2, IdGoal = 4},
            new() {Id =  7, IdCountry =  8, IdGoal = 9},
            new() {Id =  8, IdCountry =  6, IdGoal = 2},
            new() {Id =  9, IdCountry =  5, IdGoal = 6},
            new() {Id = 10, IdCountry = 10, IdGoal = 2},
        };
        builder.HasData(roads);
    }
}