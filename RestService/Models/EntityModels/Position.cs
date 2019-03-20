using System.Runtime.Serialization;

namespace Models.EntityModels
{
    [DataContract]
    public class Position : BaseIdModel
    {
        [DataMember] public string Name { get; set; }
    }
}