using FluentValidation.AspNetCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.SwaggerGen;
using ToyRobot.Models;
using ToyRobot.Validator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<TableDimension>(builder.Configuration.GetSection("TableTop"));
builder.Services.AddSingleton(sp =>
{
    var config = sp.GetRequiredService<IOptions<TableDimension>>().Value;
    return new Robot(config.Width, config.Height);
});

builder.Services.AddControllers()
                .AddFluentValidation(fluentValidate =>
                {
                    fluentValidate.RegisterValidatorsFromAssemblyContaining<RequestValidator>();
                })
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.Converters.Add(new StringEnumConverter
                    {
                        NamingStrategy = new UpperCaseNamingStrategy()
                    });
                });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new OpenApiInfo { Title = "Toy Robot API", Version = "v1" });
    config.SchemaFilter<EnumSchemaFilter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Toy Robot API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public class EnumSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.Type.IsEnum && schema.Enum != null && schema.Enum.Count > 0)
        {
            schema.Enum.Clear();
            var enumNames = System.Enum.GetNames(context.Type).ToList();
            enumNames.ForEach(name => schema.Enum.Add(new OpenApiString(name)));
        }
    }
}

public class UpperCaseNamingStrategy : NamingStrategy
{
    protected override string ResolvePropertyName(string name)
    {
        return name.ToUpperInvariant();
    }
}