using NowApi.Extensions;
using Application;
using Persistance.Services;
using NowApi;
string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);


//builder.Services.CorsPolicyConfiguration(MyAllowSpecificOrigins);
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        builder1 =>
        {

            //builder.WithOrigins(Configuration.GetSection("frontend:IpAndServerAddress").Value, "app://.").AllowAnyMethod()
            //.AllowAnyHeader();

            builder1.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
        });
});
builder.Services.BehaviorExtensionService();
builder.Services.ApplicationExtensionService();
builder.Services.PersistanceConfigureService(builder.Configuration);
builder.Services.ApiExtensionService(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler("/error");
app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseErrorHandler();
app.MapControllers();

app.Run();
