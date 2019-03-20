using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Models.RequestModels
{
    [DataContract]
    public class RequestUsersModel
    {
        [DataMember] public int Page { get; set; } = 1;
        [DataMember] public int PageSize { get; set; } = 100500;
        [DataMember] public MinMaxValueRequestModel Age { get; set; }
        [DataMember] public MinMaxValueRequestModel WorkingExperience { get; set; }
        [DataMember] public List<Guid> Positions { get; set; }
    }
}