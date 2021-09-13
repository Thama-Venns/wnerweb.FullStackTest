using System;
using System.Collections.Generic;
using System.Text;
using enerweb.FullStackTest.Localization;
using Volo.Abp.Application.Services;

namespace enerweb.FullStackTest
{
    /* Inherit your application services from this class.
     */
    public abstract class FullStackTestAppService : ApplicationService
    {
        protected FullStackTestAppService()
        {
            LocalizationResource = typeof(FullStackTestResource);
        }
    }
}
