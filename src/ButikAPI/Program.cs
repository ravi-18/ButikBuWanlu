using ButikAPI.Data;
using ButikAPI.GraphQL.Mutations;
using ButikAPI.GraphQL.Queries;
using ButikAPI.Services;
using ButikAPI.Services.Implementation;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IBranchService, BranchService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();

builder.Services.AddGraphQLServer().AddQueryType<BranchQuery>();
builder.Services.AddGraphQLServer().AddQueryType<CustomerQuery>();
builder.Services.AddGraphQLServer().AddQueryType<ProductQuery>();
builder.Services.AddGraphQLServer().AddQueryType<TransactionQuery>();

builder.Services.AddGraphQLServer().AddMutationType<TransactionMutation>();

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

app.MapGraphQL("/graphql");

app.Run();
