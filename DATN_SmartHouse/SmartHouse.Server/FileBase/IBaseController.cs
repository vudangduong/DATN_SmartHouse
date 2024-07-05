namespace SmartHouse.Server.FileBase
{
    public interface IBaseController<Req, Res>
    {
        BaseResponse<Res> Process(Req request);
        void CheckAuthorization();
        void PreValidation();
        void GenerateObjects();
        void AccessDatabase();
    }
}
