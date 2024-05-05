using HSKItemMapping;
using �ݼ�������.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// HttpClient ���
builder.Services.AddHttpClient();
builder.Services.AddTransient<HSKǰ����θ����ȸService>();
builder.Services.AddTransient<�η�ǥ��ǰ���ڵ���ȸAPIService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
