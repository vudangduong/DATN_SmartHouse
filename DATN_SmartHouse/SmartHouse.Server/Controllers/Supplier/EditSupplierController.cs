using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHouse.Entity;
using SmartHouse.Server.FileBase;
using SmartHouse.Server.Model_DTO.Supplier;

namespace SmartHouse.Server.Controllers.Supplier
{
    [Route("api/EditSupplier")]
    [ApiController]
    public class EditSupplierController : ControllerBase//, IBaseController<EditSupplierRequest, EditSupplierResponse>
    {
        private readonly DBContext context;

        
        private readonly DBContext _context;

        private EditSupplierRequest _request;
        private BaseResponse<EditSupplierResponse> _res;
        private EditSupplierResponse _response;
        private TbSupplier _Supplier;
        private string _apiCode = "EditSupplier";
        public EditSupplierController(DBContext context)
        {
            _context = context;
            _res = new BaseResponse<EditSupplierResponse>()
            {
                Status = StatusCodes.Status200OK.ToString(),
                Data = null
            };
            _response = new EditSupplierResponse();
        }
        public void AccessDatabase()
        {
            _context.SaveChanges();
            _response.ID = _Supplier.Id;
            _response.Message = "Chỉnh sửa thành công !!!";
            _res.Data = _response;
        }
        //public void CheckAuthorization()
        //{
        //    _request.Authorization(_context, _apiCode);
        //}

        public void GenerateObjects()
        {
            try
            {
                _Supplier = _context.TbSuppliers.Where(p => p.Id == _request.ID).FirstOrDefault();
                if (_Supplier != null)
                {

                    _Supplier.Name = _request.Name;
                    _Supplier.PhoneNumber = _request.PhoneNumber;
                    _Supplier.Adress = _request.Adress;
                    _Supplier.ProvideProducst = _request.ProvideProducst;
                    _Supplier.UpdateDate = DateTime.Now;
                    _Supplier.UpdateBy = _request.AdminId;
                };
            }
            catch (Exception)
            {
                _res.Status = StatusCodes.Status400BadRequest.ToString();
            }
        }

        public void PreValidation()
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        [Route("Process")]
        public BaseResponse<EditSupplierResponse> Process(EditSupplierRequest request)
        {
            try
            {
                _request = request;
                //CheckAuthorization();
                //PreValidation();
                GenerateObjects();
                //PostValidation();
                AccessDatabase();
            }
            catch (Exception)
            {
                _res.Status = StatusCodes.Status400BadRequest.ToString();
            }
            return _res;
        }
    }
}
