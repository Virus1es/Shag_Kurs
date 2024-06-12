using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebApiKurs.Models.Tables;

namespace WebApiKurs.Models.Configurations;

// класс отвечающий за настройку и заполнение таблицы Цели поездки
public class GoalConfiguration : IEntityTypeConfiguration<Goal>
{
    void IEntityTypeConfiguration<Goal>.Configure(EntityTypeBuilder<Goal> builder)
    {
        // При помощи Fluent API настраиваем модель (таблицу, столбцы, свойства)

        // настроить ограничение поля PricePerDay для Goal:
        // цена за 1 день пребывания в стране (по цели) должна быть больше 0
        builder
            //                                  имя поля    SQL-выражение для ограничения
            .ToTable(t => t.HasCheckConstraint("PricePerDay", "PricePerDay > 0"));

        // инициализация
        var goals = new List<Goal> {
            new() {Id =  1, GoalName =                      "Бизнес", PricePerDay = 1500},
            new() {Id =  2, GoalName =                      "Туризм", PricePerDay =  600},
            new() {Id =  3, GoalName =                     "Лечение", PricePerDay =  200},
            new() {Id =  4, GoalName =    "Встреча с родственниками", PricePerDay = 1100},
            new() {Id =  5, GoalName =                     "Религия", PricePerDay =  300},
            new() {Id =  6, GoalName =                      "Шопинг", PricePerDay = 3000},
            new() {Id =  7, GoalName =                     "Транзит", PricePerDay =  900},
            new() {Id =  8, GoalName =                 "Образование", PricePerDay = 2100},
            new() {Id =  9, GoalName = "Изучение научных достижений", PricePerDay = 2000},
            new() {Id = 10, GoalName =                      "Работа", PricePerDay =  800}
        };
        builder.HasData(goals);
    }
}