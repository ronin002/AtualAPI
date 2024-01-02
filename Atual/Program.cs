using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Atual.Services.Utils;
using Microsoft.IdentityModel.Tokens;
using Atual.Data;
using Microsoft.EntityFrameworkCore;
using Atual.Data.InterfacesRepo;
using Atual.Data.ImplRepositories;

var configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.json");
var config = configuration.Build();
var connectionString = config.GetConnectionString("DefaultConnection");

var keyJwt = new ConfigurationBuilder().AddJsonFile($"appsettings.json").Build().GetSection("SectionSecurity")["JwtKey"];
UtilsSecurity.JWT_KEY = keyJwt;


// Add services to the container.

var builder = WebApplication.CreateBuilder(args);

ConfigureMVC(builder);
ConfigureAuthentication(builder);
ConfigureData(builder);

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x => x
    .AllowAnyHeader()
    .AllowAnyOrigin()
    .AllowAnyMethod()
    );

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();


void ConfigureMVC(WebApplicationBuilder builder)
{
    builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });

}

void ConfigureAuthentication(WebApplicationBuilder builder)
{

    //string key1 = builder.Configuration.GetValue<string>("JwtKey");

    var keyBytes = Encoding.ASCII.GetBytes(UtilsSecurity.JWT_KEY); //(Globals._KeyT);
    builder.Services.AddAuthentication(configure =>
    {
        configure.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        configure.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

    }).AddJwtBearer(autenticacao =>
    {
        autenticacao.RequireHttpsMetadata = false;
        autenticacao.SaveToken = true;
        autenticacao.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

    //builder.Services.AddCors();
    //Globals._KeyT = key1;
}




void ConfigureData(WebApplicationBuilder builder)
{
    //MYSQL
    var connString = builder.Configuration.GetConnectionString("DefaultConnection");

    builder.Services.AddDbContext<DataContext>(options =>
    {
        options.UseMySql(connString, ServerVersion.AutoDetect(connString));
    });


    /* PostGress
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");//Configuration["dbContextSettings:ConnectionString"];
    
    builder.Services.AddDbContext<DataContext>(options =>
          options.UseNpgsql(connectionString) PostGrees
    );
    */
    //builder.Services.AddTransient<TokenService>();

    builder.Services.AddScoped<IAddress, AddressRepo>();
    builder.Services.AddScoped<IAmbiente, AmbienteRepo>();
    builder.Services.AddScoped<IClientRepo, ClienteRepo>();
    builder.Services.AddScoped<ICompanyRepo, CompanyRepo>();
    builder.Services.AddScoped<IContrato, ContratoRepo>();
    builder.Services.AddScoped<IFuncionario, FuncionarioRepo>();
    builder.Services.AddScoped<IMontadores, MontadoresRepo>();
    builder.Services.AddScoped<IMontagem, MontagemRepo>();
    builder.Services.AddScoped<IReportIncidente, ReportIncidenteRepo>();
    builder.Services.AddScoped<IRole, RoleRepo>();
    builder.Services.AddScoped<IRoleUser, RoleUserRepo>();
    builder.Services.AddScoped<ITimeMontadores, TimeMontadoresRepo>();
    builder.Services.AddScoped<IUserRepo, UserRepo>();


    builder.Services.AddScoped<IAddressService, AddressService>();
    builder.Services.AddScoped<IAmbienteService, AmbienteService>();
    builder.Services.AddScoped<IClientService, ClienteService>();
    builder.Services.AddScoped<ICompanyService, CompanyService>();
    builder.Services.AddScoped<IContratoService, ContratoService>();
    builder.Services.AddScoped<IFuncionarioService, FuncionarioService>();
    builder.Services.AddScoped<IMontadoresService, MontadoresService>();
    builder.Services.AddScoped<IMontagemService, MontagemService>();
    builder.Services.AddScoped<IReportIncidenteService, ReportIncidenteService>();
    builder.Services.AddScoped<IRoleService, RoleService>();
    builder.Services.AddScoped<IRoleUserService, RoleUserService>();
    builder.Services.AddScoped<ITimeMontadoresService, TimeMontadoresService>();
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddTransient<DataContext>();
    //builder.Services.AddScoped<IGroupRowsRepository, GroupRowsRepositoryImpl>();


}
