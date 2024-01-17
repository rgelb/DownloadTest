using DownloadTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;

namespace DownloadTest.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IWebHostEnvironment _hostingEnvironment;

    public HomeController(ILogger<HomeController> logger, IWebHostEnvironment hostingEnvironment) {
        _logger = logger;
        _hostingEnvironment = hostingEnvironment;
    }

    public IActionResult Index() {
        return View();
    }

    public IActionResult Privacy() {
        return View();
    }

    public IActionResult Download() {

        Assembly executingAssembly = Assembly.GetExecutingAssembly();
        string assemblyPath = executingAssembly.Location;
        string assemblyDirectoryName = Path.GetDirectoryName(assemblyPath);


        var filePath = Path.Combine(assemblyDirectoryName, "Files", "My Big File.pdf");

        // Replace "your_file_name.ext" with the desired file name
        var fileName = "My Big File.pdf";

        // Set the content type based on the file extension or your specific requirement
        var contentType = "application/pdf";

        // Return the file to the client
        return PhysicalFile(filePath, contentType, fileName);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
