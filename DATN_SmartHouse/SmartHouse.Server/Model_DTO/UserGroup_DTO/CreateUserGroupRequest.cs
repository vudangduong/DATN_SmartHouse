﻿using SmartHouse.Server.FileBase;

namespace SmartHouse.Server.Model_DTO.UserGroup_DTO
{
    public class CreateUserGroupRequest : BaseRequest
    {
        public string name { get; set; }
        public string code { get; set; }
        public string? description { get; set; }
    }
}
