using System;
using System.Globalization;


namespace TestProject.CustomExceptions
{
    /// <summary>
    /// When no resource is found
    /// </summary>
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException(string resource)
            : base(string.Format("{0} could not be found", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(resource.ToLower())))
        {
        }
    }
}
