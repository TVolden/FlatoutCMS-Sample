using FlatoutCMS.Core;
using FlatoutCMS_Sample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace FlatoutCMS_Sample.Controllers
{
    public class CMSController : Controller
    {
        private readonly ModelRepository modelRepository;
        private readonly IConfiguration configuration;

        public CMSController(ModelRepository modelRepository, IConfiguration configuration)
        {
            this.modelRepository = modelRepository;
            this.configuration = configuration;
        }

        [Route("{*path}")]
        public IActionResult Index(string path)
        {
            IActionResult result = NotFound();

            var uri = string.IsNullOrWhiteSpace(path) ? configuration["DefaultPages"] : path;
            modelRepository.GetModel(uri).Apply(model =>
            {
                result = View(model.View, (dynamic)model);
            });

            return result;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
