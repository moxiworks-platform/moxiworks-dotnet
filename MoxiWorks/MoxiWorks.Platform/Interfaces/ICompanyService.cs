namespace MoxiWorks.Platform
{
    public interface ICompanyService
    {
        MoxiWorksClient Client { get; set; }
        Response<Company> GetCompany(string moxiWorksCompanyId);
    }
}