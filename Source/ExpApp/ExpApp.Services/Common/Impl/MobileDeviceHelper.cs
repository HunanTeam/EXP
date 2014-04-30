using System.Web;
using ExpApp.Core;

namespace ExpApp.Services.Common.Impl
{
    public partial class MobileDeviceHelper : IMobileDeviceHelper
    {
        #region Fields


        private readonly IWorkContext _workContext;


        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="storeInformationSettings">Store information settings</param>
        /// <param name="workContext">Work context</param>
        /// <param name="storeContext">Store context</param>
        public MobileDeviceHelper(
            IWorkContext workContext)
        {

            this._workContext = workContext;

        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a value indicating whether request is made by a mobile device
        /// </summary>
        /// <param name="httpContext">HTTP context</param>
        /// <returns>Result</returns>
        public virtual bool IsMobileDevice(HttpContextBase httpContext)
        {

            bool isTablet = false;
            if (bool.TryParse(httpContext.Request.Browser["IsTablet"], out isTablet) && isTablet)
                return false;

            if (httpContext.Request.Browser.IsMobileDevice)
                return true;

            return false;
        }

        /// <summary>
        /// Returns a value indicating whether mobile devices support is enabled
        /// </summary>
        public virtual bool MobileDevicesSupported()
        {
            return false;
        }

        /// <summary>
        /// Returns a value indicating whether current customer prefer to use full desktop version (even request is made by a mobile device)
        /// </summary>
        public virtual bool CustomerDontUseMobileVersion()
        {
            return true;
        }

        #endregion
    }
}
