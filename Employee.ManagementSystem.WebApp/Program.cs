using AutoMapper;
using Azure.Identity;
using Employee.ManagementSystem.Data.Employee.AutoMapperProfiles;
using Employee.ManagementSystem.WebApp.Data;
using Employee.ManagementSystem.WebApp.Data.Employee.Services;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

// Access Key Vault
var credentialOptions = new DefaultAzureCredentialOptions()
{
    ManagedIdentityClientId  = builder.Configuration["KeyVault:AzureADManagedIdentityClientId"],
    ExcludeVisualStudioCredential = true
};

builder.Configuration.AddAzureKeyVault(
    new Uri($"https://{builder.Configuration["KeyVault:Vault"]}.vault.azure.net/"), 
    new DefaultAzureCredential(credentialOptions));

// Add Db
builder.Services.AddDbContext<EmployeeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeContext")));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
// Blazor Radzen Examples
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();

// Add Mappers
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new EmployeeMapperProfile());
});
var mapper = mappingConfig.CreateMapper();

builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


var movieApiKey = builder.Configuration["ConnectionStrings:EmployeeContext"];
Console.WriteLine("MOVIE KEY {0}", movieApiKey);

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();