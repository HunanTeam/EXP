using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Exp.Services.Common
{
    public partial interface IMobileDeviceHelper
    {
        /// <summary>
        /// Returns a value indicating whether request is made by a mobile device
        /// </summary>
        /// <param name="httpContext">HTTP context</param>
        /// <returns>Result</returns>
        bool IsMobileDevice(HttpContextBase httpContext);

        /// <summary>
        /// Returns a value indicating whether mobile devices support is enabled
        /// </summary>
        bool MobileDevicesSupported();

        /// <summary>
        /// Returns a value indicating whether current customer prefer to use full desktop version (even request is made by a mobile device)
        /// </summary>
        bool CustomerDontUseMobileVersion();
    }
}
