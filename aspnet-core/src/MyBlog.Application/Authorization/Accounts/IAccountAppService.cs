using System.Threading.Tasks;
using Abp.Application.Services;
using MyBlog.Authorization.Accounts.Dto;

namespace MyBlog.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
