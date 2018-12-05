namespace MoxiWorks.Platform.Interfaces
{
    
    /// <summary>
    ///  Interface to all developers to implement there own credentials class.  
    /// </summary>
    public interface IMoxiWorksCredentials
    {
        string ToBase64();
    }
}