using enerweb.FullStackTest.Dto.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace enerweb.FullStackTest.Repository
{
    public interface IFullStackTestService: IApplicationService
    {
        Task<object> SaveFileContentAsync(IFormFile formFile);
        Task<Record> GetDocAsync(int id);
        Task<List<File>> GetFiles();
    }
}
