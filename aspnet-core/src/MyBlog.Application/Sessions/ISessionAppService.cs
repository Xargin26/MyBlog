using System.Threading.Tasks;
using Abp.Application.Services;
using MyBlog.Sessions.Dto;

namespace MyBlog.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
