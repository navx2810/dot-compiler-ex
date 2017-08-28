using DL = DotLiquid;

namespace Mojo.Features.TemplatingEngines.DotLiquid
{
    public struct ViewModelOptions
    {
        public DL.Hash Hash { get; set; }
        public System.IFormatProvider IFormatProvider { get; set; }
    }

    public class RenderTemplate : ITemplate<ViewModelOptions>
    {
        public DL.Template Template { get; set; }
        public string Render(ViewModelOptions options)
        {
            if(Template == null) { throw new TemplateInvalidException(); }
            if(options.Hash != null) { return Template.Render(options.Hash, options.IFormatProvider); }
            else if(options.IFormatProvider != null) { return Template.Render(options.IFormatProvider); }
            else { throw new TemplateInvalidViewModelException(); }
            throw new System.NotImplementedException();
        }

        public string Render()
        {
            if(Template == null) { throw new TemplateInvalidException(); }
            throw new System.NotImplementedException();
        }
    }

    public class Engine : ITemplateEngine<ViewModelOptions>
    {
        public ITemplate<ViewModelOptions> Compile(string source)
        {
            return new RenderTemplate { Template = DL.Template.Parse(source) };
        }

        public void Setup()
        {
            throw new System.NotImplementedException();
        }
    }
}