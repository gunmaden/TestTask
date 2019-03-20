using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Models.RequestModels
{
    [DataContract]
    public class ResponseModel<T>
    {
        [DataMember] public bool IsSuccess { get; set; }

        [DataMember] public List<string> Errors { get; set; }

        [DataMember] public T Result { get; set; }
    }
}