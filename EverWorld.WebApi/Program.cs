using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);


var sqlConnectionString = builder.Configuration.GetValue<string>("SqlConnectionString");
var sqlConnectionStringFound = !string.IsNullOrWhiteSpace(sqlConnectionString);

builder.Services.AddScoped<DbConnectionService>(provider =>
{
    return new DbConnectionService(sqlConnectionString);
});
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<EnvironmentService>();

builder.Services.AddAuthorization();
builder.Services
    .AddIdentityApiEndpoints<IdentityUser>()
    .AddDapperStores(options =>
    {
        options.ConnectionString = sqlConnectionString;
    });


// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IAuthenticationService, AspNetIdentityAuthenticationService>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseAuthorization();

app.MapGroup("/auth")
    .MapIdentityApi<IdentityUser>();

//app.MapPost("/auth/logout",
//    async (SignInManager<IdentityUser> signInManager,
//    [FromBody] object empty) =>
//    {
//        if (empty != null)
//        {
//            await signInManager.SignOutAsync();
//            return Results.Ok();

//        }
//        return Results.Unauthorized();
//    });

app.MapGet("/", () => $"The API is up. Connection string found: {(sqlConnectionStringFound ? "" : "")}");


//app.MapGroup("/account")
//    .MapIdentityApi<IdentityUser>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers()
    .RequireAuthorization();

app.Run();
