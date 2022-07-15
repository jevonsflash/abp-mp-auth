using Abp.Application.Services.Dto;

namespace WeChat.MiniProgram.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

