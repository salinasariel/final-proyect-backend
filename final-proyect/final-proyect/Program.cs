using final_proyect.Data;
using final_proyect.Interfaces;
using final_proyect.Models;
using final_proyect.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using final_proyect.HashData;
using Microsoft.OpenApi.Models;
using final_proyect.Observer;

var builder = WebApplication.CreateBuilder(args);

#region Injections
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOfferService, OfferService>();
builder.Services.AddScoped<IHashData, HashData>();
builder.Services.AddScoped<IApplicationServices, ApplicationServices>();
builder.Services.AddScoped<IAuthServices, AuthServices>();
builder.Services.AddScoped<OfferSubject, OfferSubject>();

#endregion

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("Policys",
        builder => builder
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.AddSecurityDefinition("TPI_NapolitanoSalinasVazquezApiBearerAuth", new OpenApiSecurityScheme()
    {
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        Description = "Ingrese el JWT"
    });

    setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "TPI_NapolitanoSalinasVazquezApiBearerAuth"
                }
            }, new List<string>()
        }
    });
}); // AUTH

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Authentication:Issuer"],
        ValidAudience = builder.Configuration["Authentication:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Authentication:SecretForKey"]))
    };
}); // JWT

builder.Services.AddAuthorization(options => {
    options.AddPolicy("Admin", policy => policy.RequireClaim("rol", "Admin"));
    options.AddPolicy("Student", policy => policy.RequireClaim("rol", "Student"));
    options.AddPolicy("Enterprise", policy => policy.RequireClaim("rol", "Enterprise"));
    options.AddPolicy("AdminOrEnterprise", policy => policy.RequireAssertion(context =>
        context.User.HasClaim(c => (c.Type == "rol" && (c.Value == "Admin" || c.Value == "Enterprise")))
    ));

}); // POLICY

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
}); // CONTEXT

builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));
builder.Services.AddTransient<EmailService>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseCors("Policys");
app.Run();
