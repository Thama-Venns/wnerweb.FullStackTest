using enerweb.FullStackTest.Dto.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace enerweb.FullStackTest.Repository
{
    public interface IServicePointService: ICrudAppService<ServicePoint, int>
    {
    }
}
