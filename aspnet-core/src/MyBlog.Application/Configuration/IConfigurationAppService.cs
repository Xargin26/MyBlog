using System.Threading.Tasks;
using MyBlog.Configuration.Dto;

namespace MyBlog.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
