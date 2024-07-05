using SmartHouse.Server.FileBase;

namespace SmartHouse.Server.Model_DTO.UserGroup_DTO
{
    public class GetListUserGroupRequest : BaseRequest
    {
        public string? searchKey { get; set; }
    }
}
