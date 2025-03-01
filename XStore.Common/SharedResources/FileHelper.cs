using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace XStore.Common.SharedResources
{
    public static class FileHelper
    {
        private static string ResourcesPath = Directory.GetCurrentDirectory();

        public static string GetResourcesPath()
        {
            return ResourcesPath;
        }
    }
}
