using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Models.RequestModels
{
    [DataContract]
    public class MinMaxValueRequestModel : IValidatableObject
    {
        [DataMember] public int? MinValue { get; set; }
        [DataMember] public int? MaxValue { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            if (MaxValue == null && MinValue == null)
                results.Add(new ValidationResult("Please specify at least one of [MaxValue|MinValue]"));

            if (MaxValue < MinValue)
                results.Add(new ValidationResult("MaxValue should be greater or equals than MinValue"));

            return results;
        }
    }
}