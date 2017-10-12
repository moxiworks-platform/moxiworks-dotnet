namespace MoxiWorks.Platform
{
    public interface IOfficeService
    {
        MoxiWorksClient Client { get; set; }
        Response<Office> GetOffice(string moxiWorksOfficeId, string moxiWorksCompanyId);
        Response<OfficeResults> GetCompanyOffices(string moxiWorksCompanyId, int pageNumber = 1);
    }
}