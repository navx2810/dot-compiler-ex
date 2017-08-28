using System.Collections.Generic;
using HandlebarsDotNet;
using HBS = HandlebarsDotNet.Handlebars;

namespace Mojo.Features.TemplatingEngines.Handlebars
{
    public struct ViewModelOptions
    {
        public object Object { get; set; }
        public dynamic Dynamic { get; set; }
        public Dictionary<string, object> Dictionary { get; set; }

    }

    public class RenderTemplate : ITemplate<ViewModelOptions>
    {
        public System.Func<object, string> Template { get; set; }

        public string Render(ViewModelOptions options)
        {
            if(Template == null) { throw new TemplateInvalidException(); }

            if(options.Dictionary != null) { return Template(options.Dictionary); }
            else if(options.Object != null) { return Template(options.Object); }
            else if(options.Dynamic != null) { return Template(options.Dynamic); }
            else { throw new TemplateInvalidViewModelException(); }
        }

        public string Render()
        {
            if(Template == null) { throw new TemplateInvalidException(); }
            return Template(null);
        }
    }

    public class Engine : ITemplateEngine<ViewModelOptions>
    {
        public ITemplate<ViewModelOptions> Compile(string source)
        {
            return new RenderTemplate { Template = HBS.Compile(source) };
        }

        public void Setup()
        {
            throw new System.NotImplementedException();
        }
    }
}