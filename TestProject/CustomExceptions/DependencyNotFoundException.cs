using System;
using System.Globalization;

namespace TestProject.CustomExceptions
{
    /// <summary>
    /// When a dependecy is not found
    /// </summary>
    public class DependencyNotFoundException : Exception
    {
        public DependencyNotFoundException(string dependency)
            : base(string.Format("{0} could not be found", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dependency.ToLower())))
        {
        }
    }
}
