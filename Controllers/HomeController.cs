using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotLiquid;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mojo.Features;
using Engines = Mojo.Features.TemplatingEngines;

namespace template_engine.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        private readonly ITemplateEngine<Engines.DotLiquid.ViewModelOptions> dotLiquidTemplateEngine;
        private readonly ITemplateEngine<Engines.Handlebars.ViewModelOptions> handlebarsTemplateEngine;
        string RawTemplate = "Hello from {{name}}.";
        public HomeController(ITemplateEngine<Engines.DotLiquid.ViewModelOptions> dotLiquidEngine, ITemplateEngine<Engines.Handlebars.ViewModelOptions> handlebarsEngine)
        {
            dotLiquidTemplateEngine = dotLiquidEngine;
            handlebarsTemplateEngine = handlebarsEngine;
        }
        // GET DotLiquid Rendering
        [HttpGet("/d")]
        public string Get()
        {
            // var engine = HttpContext.RequestServices.GetService(typeof(ITemplateEngine<Engines.DotLiquid.ViewModelOptions>));
            var template = dotLiquidTemplateEngine.Compile(RawTemplate);
            Hash hash = new Hash();
            hash["name"] = "DotLiquid";
            return template.Render(new Engines.DotLiquid.ViewModelOptions{ Hash = hash });
        }

        // GET Handlebars Rendering
        [HttpGet("/h")]
        public string Get(int id)
        {
            var template = handlebarsTemplateEngine.Compile(RawTemplate);
            var obj = new
            {
                name = "Handlebars"
            };
            return template.Render(new Engines.Handlebars.ViewModelOptions { Object = obj });
        }
    }
}
