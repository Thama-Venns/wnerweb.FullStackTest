using enerweb.FullStackTest.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace enerweb.FullStackTest.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class FullStackTestController : AbpController
    {
        protected FullStackTestController()
        {
            LocalizationResource = typeof(FullStackTestResource);
        }
    }
}