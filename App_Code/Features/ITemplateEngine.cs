using System;

namespace Mojo.Features
{
    #region Exceptions
    /// <summary>
    /// The exception that occurs when the View Model does not contain any objects that fit the signature of the templates native render function.
    /// </summary>
    public class TemplateInvalidViewModelException : Exception
    {
        public TemplateInvalidViewModelException() : base("The view model did not contain a logical path to rendering the template.") {}
    }
    /// <summary>
    /// The exception that occurs when the template has failed to be initialized properly from the template.
    /// </summary>
    public class TemplateInvalidException : Exception
    {
        public TemplateInvalidException() : base("The template provided by the engine can not be null or invalid.") {}
    }
    #endregion
    
    /// <summary>
    /// The template that is returned by the engine.
    /// </summary>
    /// <typeparam name="T">The type of View Model Options object that the Render method takes.</typeparam>
    public interface ITemplate<T>
    {
        /// <summary>
        /// The method that renders the template with a view model options.
        /// </summary>
        /// <param name="options">The different types of objects that can be passed to the native engine's render method.</param>
        /// <returns>The parsed HTML.</returns>
        string Render(T options);

        /// <summary>
        /// The method that renders the template without a view model.
        /// </summary>
        /// <returns>The parsed HTML.</returns>
        string Render();
    }

    /// <summary>
    /// The templating engine that compiles a source and returns a template.
    /// </summary>
    /// <typeparam name="T">The type of View Model Options object that the Template's Render method takes.</typeparam>
    public interface ITemplateEngine<T>
    {
        /// <summary>
        /// The method that takes in a raw string and returns the template.
        /// </summary>
        /// <param name="source">The raw string to be compiled by the template.</param>
        /// <returns>The template object containing the native template.</returns>
        ITemplate<T> Compile(string source);

        /// <summary>
        /// The method that is used by the engine to initialize variables such as global templates, filters, helpers, partials...
        /// </summary>
        void Setup();
    }
}