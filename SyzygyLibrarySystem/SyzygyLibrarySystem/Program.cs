using SyzygyLibrarySystem.Data;
using SyzygyLibrarySystem.Repositories.Loans;
using SyzygyLibrarySystem.Repositories.Publishers;

internal class Program
{
	private static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.
		builder.Services.AddControllersWithViews();

		builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
		builder.Services.AddScoped<IPublisherRepository, PublisherRepository>();
		builder.Services.AddScoped<ILoanRepository, LoanRepository>();

		var app = builder.Build();

		// Configure the HTTP request pipeline.
		if (!app.Environment.IsDevelopment())
		{
			app.UseExceptionHandler("/Home/Error");
		}
		app.UseStaticFiles();

		app.UseRouting();

		app.UseAuthorization();

		app.MapControllerRoute(
			name: "default",
			pattern: "{controller=Home}/{action=Index}/{id?}");

		app.Run();
	}
}