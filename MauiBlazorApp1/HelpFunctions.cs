using MauiBlazorApp1.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBlazorApp1
{
    public class HelpFunctions
    {
        public static ServerModeSetting GetConfigurationMode()
        {
          
            var serverMode = ServerModeSetting.Prod;
#if DEBUGDEV
            serverMode = ServerModeSetting.Dev;
#endif
#if RELEASEDEV
            serverMode = ServerModeSetting.Dev;
#endif

            return serverMode;
        }

        public static string GetApplicationName()
        {
            var x = 1;
            var platformService = new MauiBlazorApp1.Platforms.PartialMethods.FileAccessIntegration();
            var name = platformService.GetApplicationName();
            return name;
        }


    }
}
