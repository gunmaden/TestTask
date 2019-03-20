using System;
using System.Runtime.Serialization;

namespace Models.EntityModels
{
    [DataContract]
    public class BaseIdModel
    {
        [DataMember] public Guid Id { get; set; }
    }
}