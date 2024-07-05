﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHouse.Server.FileBase;
using SmartHouse.Server.Model_DTO.Supplier;
using SmartHouse.Server.Entity;
namespace SmartHouse.Server.Controllers.Supplier
{
    [Route("api/CreateSupplier")]
    [ApiController]
    public class CreateSupplierController : ControllerBase//, IBaseController<CreateSupplierRequest, CreateSupplierResponse>
    {
        
        private  DBContext _context;
        private CreateSupplierRequest _request;
        private BaseResponse<CreateSupplierResponse> _res;
        private CreateSupplierResponse _response;
        private TbSupplier _Supplier;
        private string _apiCode = "CreateSupplier";
        public CreateSupplierController(DBContext context)
        {
            _context = context;
            _res = new BaseResponse<CreateSupplierResponse>()
            {
                Status = StatusCodes.Status200OK.ToString(),
                Data = null
            };
            _response = new CreateSupplierResponse();
        }
        private void AccessDatabase()
        {
            _context.TbSuppliers.Add(_Supplier);
            _context.SaveChanges();
            _response.Message = "Thêm mới thành công !!!";
            _res.Data = _response;
        }
        //public void CheckAuthorization()
        //{
        //    _request.Authorization(_context, _apiCode);
        //}

        private void GenerateObjects()
        {
            _Supplier = new TbSupplier()
            {
                Id = Guid.NewGuid(),
                Name = _request.Name,
                PhoneNumber = _request.PhoneNumber,
                Adress = _request.Adress,
                ProvideProducst = _request.ProvideProducst,
                CreateDate = DateTime.Now,
                CreateBy = _request.AdminId ?? Guid.Parse("9a8d99e6-cb67-4716-af99-1de3e35ba993"),
            };
        }

        private void PreValidation()
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        [Route("Process")]
        public BaseResponse<CreateSupplierResponse> Process(CreateSupplierRequest request)
        {
            try
            {
                _request = request;
                //CheckAuthorization();
                //PreValidation(); // validate dữ liệu 
                GenerateObjects(); // Gán dữ liệu 
                AccessDatabase(); // Lưu xuống DB 
            }
            catch (Exception)
            {
                _res.Status = StatusCodes.Status400BadRequest.ToString();
            }
            return _res;
        }
    }
}
