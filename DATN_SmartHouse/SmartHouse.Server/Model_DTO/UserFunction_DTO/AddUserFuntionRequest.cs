using SmartHouse.Server.FileBase;

namespace SmartHouse.Server.Model_DTO.UserFunction_DTO
{
    public class AddUserFuntionRequest : BaseRequest
    {
        public Guid userGroupId { get; set; }
        public List<Guid> funtionForPermissionId { get; set; }
    }
}
