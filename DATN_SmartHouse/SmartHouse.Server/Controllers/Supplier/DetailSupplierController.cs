using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartHouse.Server.Entity;
using SmartHouse.Server.FileBase;
using SmartHouse.Server.Model_DTO.Supplier;

namespace SmartHouse.Server.Controllers.Supplier
{

    public class DetailSupplierController : ControllerBase//, IBaseController<DetailSupplierRequest, DetailSupplierResponse>
    {
        
        private  DBContext _context;
        private DetailSupplierRequest _request;
        private BaseResponse<DetailSupplierResponse> _res;
        private DetailSupplierResponse _response;
        private string _apiCode = "DetailCustomer";
        private TbSupplier _Supplier;
        public DetailSupplierController(DBContext context)
        {
            _context = context;
            _res = new BaseResponse<DetailSupplierResponse>()
            {
                Status = StatusCodes.Status200OK.ToString(),
                Data = null
            };
            _Supplier = new TbSupplier();
            _response = new DetailSupplierResponse();
        }

        private void AccessDatabase()
        {
            try
            {
                _Supplier = _context.TbSuppliers.Where(p => p.Id == _request.Id).FirstOrDefault();
                if (_Supplier != null)
                {
                    _response.Id = _Supplier.Id;
                    _response.PhoneNumber = _Supplier.PhoneNumber;
                    _response.ProvideProducst = _Supplier.ProvideProducst;
                    _response.Name = _Supplier.Name;
                    _response.Adress = _Supplier.Adress;
                }
            }
            catch (Exception)
            {
                _res.Status = StatusCodes.Status400BadRequest.ToString();
            }
            _res.Data = _response;
        }
        //public void CheckAuthorization()
        //{
        //    throw new NotImplementedException();
        //}
        private void GenerateObjects()
        {
            throw new NotImplementedException();
        }

        private void PreValidation()
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        [Route("Process")]
        public BaseResponse<DetailSupplierResponse> Process(DetailSupplierRequest request)
        {
            try
            {
                _request = request;
                //CheckAuthorization();
                //PreValidation();
                //GenerateObjects();
                //PostValidation();
                AccessDatabase();
            }
            catch (ACV_Exception ex)
            {
                _res.Status = StatusCodes.Status400BadRequest.ToString();
                _res.Messages = ex.Messages;
            }
            catch (System.Exception ex)
            {
                _res.Status = StatusCodes.Status500InternalServerError.ToString();
                _res.Messages.Add(Message.CreateErrorMessage(_apiCode, _res.Status, ex.Message, string.Empty));
            }
            return _res;
        }
    }
}
