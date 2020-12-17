using Abp.Application.Services;
using MyBlog.MultiTenancy.Dto;

namespace MyBlog.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

