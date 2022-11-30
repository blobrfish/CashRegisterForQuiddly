using System;
using System.Collections.Generic;
using System.IO;
using TestProject.CustomExceptions;
namespace TestProject.BaseTypes
{
    /// <summary>
    /// A base class for file-based resources 
    /// </summary>
   
    public abstract class ResourceServiceBase
    {
        protected string Path;
        protected ResourceServiceBase(string path, string resource, bool isCritical)
        {
            this.Path = path;
            if(isCritical)
            {
                bool fileExist = File.Exists(path);
                if(!fileExist)
                    throw new ResourceNotFoundException(resource);
            }
        }
    }
}
