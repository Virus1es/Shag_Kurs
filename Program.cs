using Microsoft.EntityFrameworkCore;
using WebApiKurs.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// ����������� EF ��� ������� - ���������� ������
// ������ ����������� ���������� � appsettings.json
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<TurAgancyContext>(
    options => options
        // ����������� lazy loading, ������� ���������� NuGet-����� Microsoft.EntityFrameworkCore.Proxies
        .UseLazyLoadingProxies()
        .UseSqlServer(connection));

// ���������� ������� CORS (Cross Origin Resource Sharing)
// ��� ���������� �������� � ������� �� ������ �������
// �.�. �� ���������� ����������, ��������� � ������ ��������
builder.Services.AddCors();

var app = builder.Build();

// ��������� CORS - ��������� ������������ ����� ��������� ��������
// � ��� ���� REST-��������
app.UseCors(b => b.AllowAnyOrigin().AllowAnyMethod());

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
