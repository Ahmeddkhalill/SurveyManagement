var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();

// Add Mapster
var mappingConfig = TypeAdapterConfig.GlobalSettings;
mappingConfig.Scan(Assembly.GetExecutingAssembly());

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddSingleton<IJwtProvider, JwtProvider>();
//builder.Services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.SectionName));

builder.Services.AddOptions<JwtOptions>().BindConfiguration(JwtOptions.SectionName)
.ValidateDataAnnotations().ValidateOnStart();

var jwtSettings = configuration.GetSection(JwtOptions.SectionName).Get<JwtOptions>();

builder.Services.AddSingleton<IMapper>(new Mapper(mappingConfig));

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IPollService, PollService>();

builder.Services.AddFluentValidationAutoValidation()
    .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(o =>
    {
        o.SaveToken = true;
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings?.Key!)),
            ValidIssuer = jwtSettings?.Issuer,
            ValidAudience = jwtSettings?.Audience
        };
    }); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json","v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();
   
app.MapControllers();

app.Run();
