using SyzygyLibrarySystem.Data;
using SyzygyLibrarySystem.Repositories.Authors;
using SyzygyLibrarySystem.Repositories.Books;
using SyzygyLibrarySystem.Repositories.LoanDetails;
using SyzygyLibrarySystem.Repositories.Loans;
using SyzygyLibrarySystem.Repositories.Publishers;
using SyzygyLibrarySystem.Repositories.Students;
using SyzygyLibrarySystem.Services.Email;

internal class Program
{
	private static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.
		builder.Services.AddControllersWithViews();

		builder.Services.AddTransient<IEmailService, EmailService>();

		builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
		builder.Services.AddScoped<IPublisherRepository, PublisherRepository>();
		builder.Services.AddScoped<ILoanRepository, LoanRepository>();
        builder.Services.AddScoped<ILoanDetailRepository, LoanDetailRepository>();
        builder.Services.AddScoped<IBookRepository, BookRepository>();
        builder.Services.AddScoped<IStudentRepository, StudentRepository>();
        builder.Services.AddScoped<IAuthorsRepository, AuthorsRepository>();

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
			pattern: "{controller=Book}/{action=Index}/{id?}");

		app.Run();
	}
}