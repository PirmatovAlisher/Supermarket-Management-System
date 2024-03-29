using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Plugins.DataStore.InMemory;
using Plugins.DataStore.SQL;
using UseCases;
using UseCases.CategoriesUseCase;
using UseCases.DataStorePluginInterfaces;
using UseCases.ProductsUseCase;
using UseCases.UseCaseInterfaces;
using WebApp.Data;

namespace WebApp;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.
		builder.Services.AddRazorPages();
		builder.Services.AddServerSideBlazor();


		var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
		builder.Services.AddDbContext<MarketContext>(options =>
			options.UseSqlServer(connectionString), ServiceLifetime.Transient);

		// Add Dependency Injection
		//builder.Services.AddScoped<ICategoryRepository, CategoryInMemoryRepository>();
		//builder.Services.AddScoped<IProductRepository, ProductInMemoryRepository>();
		//builder.Services.AddScoped<ITransactionRepository, TransactionInMemoryRepository>();

		// Dependency Injection For EF Core Data Base for SQL
		builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
		builder.Services.AddTransient<IProductRepository, ProductRepository>();
		builder.Services.AddTransient<ITransactionRepository, TransactionRepository>();

		builder.Services.AddTransient<IViewCategoriesUseCase, ViewCategoriesUseCase>();
		builder.Services.AddTransient<IViewProductsByCategoryId, ViewProductsByCategoryId>();
		builder.Services.AddTransient<IViewProductsUseCase, ViewProductsUseCase>();
		builder.Services.AddTransient<IAddCategoryUseCase, AddCategoryUseCase>();	
		builder.Services.AddTransient<IAddProductUseCase, AddProductUseCase>();	
		builder.Services.AddTransient<IEditCategoryUseCase, EditCategoryUseCase>();	
		builder.Services.AddTransient<IEditProductUseCase, EditProductUseCase>();	
		builder.Services.AddTransient<IGetCategoryByIdUseCase, GetCategoryByIdUseCase>();	
		builder.Services.AddTransient<IGetProductByIdUseCase, GetProductByIdUseCase>();	
		builder.Services.AddTransient<IDeleteCategoryUseCase, DeleteCategoryUseCase>();	
		builder.Services.AddTransient<IDeleteProductUseCase, DeleteProductUseCase>();	
		builder.Services.AddTransient<ISellProductUseCase, SellProductUseCase>();	
		builder.Services.AddTransient<IRecordTransactionUseCase, RecordTransactionUseCase>();	
		builder.Services.AddTransient<IGetTodayTransactionsUseCase, GetTodayTransactionsUseCase>();	
		builder.Services.AddTransient<IGetTransactionsUseCase, GetTransactionsUseCase>();	




		var app = builder.Build();

		// Configure the HTTP request pipeline.
		if (!app.Environment.IsDevelopment())
		{
			app.UseExceptionHandler("/Error");
			// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
			app.UseHsts();
		}

		app.UseHttpsRedirection();

		app.UseStaticFiles();

		app.UseRouting();

		app.MapBlazorHub();
		app.MapFallbackToPage("/_Host");

		app.Run();
	}
}
