namespace MoxiWorks.Platform
{
    /// <summary>
    /// Designates what type of agent ID we are using 
    /// AgentUuid - GUID id that represents an agent in the Moxi Works platform.
    /// MoxiWorksagentId unique value email/GUID mapped to an Agent on the Moxi Works Platform.
    /// </summary>
    public enum AgentIdType
    {
        AgentUuid = 0,
        MoxiWorksagentId = 1 
    }
}