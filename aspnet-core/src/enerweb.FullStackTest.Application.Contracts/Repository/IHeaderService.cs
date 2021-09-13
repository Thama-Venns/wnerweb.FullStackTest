using enerweb.FullStackTest.Dto.Models;
using Volo.Abp.Application.Services;

namespace enerweb.FullStackTest.Repository
{
    public interface IHeaderService: ICrudAppService<Header, int>
    {
    }
}
