using API_rest.Contexts;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AnnuaireContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
public class SalarieService
{
    private readonly AnnuaireContext _dbContext;

    public SalarieService(AnnuaireContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Salaries> GetSalaries()
    {
        return _dbContext.Salaries.ToList();
    }
    // Ajoutez d'autres méthodes pour les opérations liées aux salariés
}
