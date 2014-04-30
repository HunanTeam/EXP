using System;
using System.IO;

namespace ExpApp.Core.Plugins
{
    public static class PluginExtensions
    {
        public static string GetLogoUrl(this PluginDescriptor pluginDescriptor)
        {
            if (pluginDescriptor == null)
                throw new ArgumentNullException("pluginDescriptor");

          

            if (pluginDescriptor.OriginalAssemblyFile == null || pluginDescriptor.OriginalAssemblyFile.Directory == null)
            {
                return null;
            }

            var pluginDirectory = pluginDescriptor.OriginalAssemblyFile.Directory;
            var logoLocalPath = Path.Combine(pluginDirectory.FullName, "logo.jpg");
            if (!File.Exists(logoLocalPath))
            {
                return null;
            }

            string logoUrl = string.Format("plugins/{1}/logo.jpg", pluginDirectory.Name);
            return logoUrl;
        }
    }
}
