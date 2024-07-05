using SmartHouse.Server.FileBase;

namespace SmartHouse.Server.Model_DTO.UserGroup_DTO
{
    public class DeleteUserGroupRequest : BaseRequest
    {
        public Guid id { get; set; }
    }
}
