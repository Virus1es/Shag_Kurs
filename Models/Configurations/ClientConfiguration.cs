using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebApiKurs.Models.Tables;

namespace WebApiKurs.Models.Configurations;

// класс отвечающий за настройку и заполнение таблицы Клиенты
public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    void IEntityTypeConfiguration<Client>.Configure(EntityTypeBuilder<Client> builder)
    {
        // При помощи Fluent API настраиваем модель (таблицу, столбцы, свойства)

        // настроить ограничение поля Passport для Client:
        // номер, серия паспорта должны быть уникальными
        builder
            .HasIndex(c => c.Passport)
            .IsUnique();

        // инициализация
        var clients = new List<Client> {
            new() {Id =  1, Surname = "Колбасов",  Name = "Кирил",     Patronymic = "Петрович",     Passport = "91 15 643214"},
            new() {Id =  2, Surname = "Ушкало",    Name = "Анна",      Patronymic = "Степановна",   Passport = "91 45 447890"},
            new() {Id =  3, Surname = "Капустин",  Name = "Игорь",     Patronymic = "Семёнович",    Passport = "81 33 566234"},
            new() {Id =  4, Surname = "Пригожин",  Name = "Андрей",    Patronymic = "Владимирович", Passport = "53 41 903145"},
            new() {Id =  5, Surname = "Иванова",   Name = "Екатерина", Patronymic = "Викторовна",   Passport = "45 44 934545"},
            new() {Id =  6, Surname = "Баранов",   Name = "Алексей",   Patronymic = "Кирилович",    Passport = "71 67 315670"},
            new() {Id =  7, Surname = "Афендиков", Name = "Игнат",     Patronymic = "Степанович",   Passport = "95 13 901331"},
            new() {Id =  8, Surname = "Синявская", Name = "Анастасия", Patronymic = "Петровна",     Passport = "91 15 372333"},
            new() {Id =  9, Surname = "Гусева",    Name = "Валерия",   Patronymic = "Ивановна",     Passport = "77 90 193451"},
            new() {Id = 10, Surname = "Гринь",     Name = "Виталий",   Patronymic = "Генадьевич",   Passport = "91 27 643214"}
        };
        builder.HasData(clients);
    }
}