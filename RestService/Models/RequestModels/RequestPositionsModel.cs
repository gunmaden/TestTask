using System.Runtime.Serialization;

namespace Models.RequestModels
{
    [DataContract]
    public class RequestPositionsModel
    {
        [DataMember] public int Page { get; set; }
        [DataMember] public int PageSize { get; set; }
    }
}