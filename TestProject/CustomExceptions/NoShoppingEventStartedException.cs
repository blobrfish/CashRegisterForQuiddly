using System;

namespace TestProject.CustomExceptions
{
    /// <summary>
    /// When no shopping event has been created
    /// </summary>
    public class NoShoppingEventStartedException : Exception
    {
        public NoShoppingEventStartedException()
            : base(string.Format("No shopping event has been started"))
        {
        }
    }
}
