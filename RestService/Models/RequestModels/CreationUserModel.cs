using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Runtime.Serialization;

namespace Models.RequestModels
{
    [DataContract]
    public class CreationUserModel
    {
        [DataMember]
        [Required]
        [StringLength(100)]
        public string DisplayName { get; set; }

        [DataMember] [Required] public string BirthDate { get; set; }

        [DataMember] [Required] public string WorkPeriodStartDate { get; set; }

        [DataMember] [Required] public string PositionId { get; set; }

        public DateTime GetBirthDateTime()
        {
            return DateTime.ParseExact(BirthDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        }

        public DateTime GetWorkPeriodStartDateTime()
        {
            return DateTime.ParseExact(WorkPeriodStartDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        }
    }
}