using Microsoft.EntityFrameworkCore;
using System;
using WebApiKurs.Models.Tables;

namespace WebApiKurs.Models;


// Конфигурация БД, расширяем класс DbContext
public class TurAgancyContext : DbContext
{
    // таблицы базы данных

    public DbSet<Country> Countries => Set<Country>();
    public DbSet<Goal> Goals => Set<Goal>();
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<Road> Roads => Set<Road>();
    public DbSet<Trip> Trips => Set<Trip>();



    // конструктор контекста
    public TurAgancyContext()
    {
        // удаление старой весрии базы данных, создание новой версии базы данных
        //Database.EnsureDeleted();
        //Database.EnsureCreated();
    }

    // конструктор с параметром, испоьзуется в Program.cs
    public TurAgancyContext(DbContextOptions<TurAgancyContext> options) : base(options)
    {
        // удаление старой весрии базы данных, создание новой версии базы данных
        //Database.EnsureDeleted();
        //Database.EnsureCreated();
    }
}
