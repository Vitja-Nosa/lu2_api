var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization();
builder.Services
    .AddIdentityApiEndpoints<IdentiyUser>()
    .AddDapperStores(options =>
    {
        options.ConnectionString = dbConnectionString;
    });


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

builder.Build();
app.UseAuthorization();

app.MapGroup("/account")
    .MapIdentityApi<IdentityUser>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
