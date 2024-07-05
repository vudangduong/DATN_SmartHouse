﻿using SmartHouse.Server.FileBase;

namespace SmartHouse.Server.Model_DTO.User_DTO
{
    public class CreateUserRequest : BaseRequest
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Position { get; set; }
        public string UserCode { get; set; }
        public string FullName { get; set; }
        public bool? InActive { get; set; }
    }
}
