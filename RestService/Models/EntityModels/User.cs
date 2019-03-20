using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Models.EntityModels
{
    [DataContract]
    public class User : BaseIdModel
    {
        [DataMember]
        [Required]
        [StringLength(100)]
        public string DisplayName { get; set; }

        [DataMember]
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [DataMember]
        [Required]
        [DataType(DataType.Date)]
        public DateTime WorkPeriodStartDate { get; set; }

        [DataMember] [Required] public Position Position { get; set; }

        public int GetAge()
        {
            return GetYearsFromToday(BirthDate);
        }

        public int GetYearsOfExperience()
        {
            return GetYearsFromToday(WorkPeriodStartDate);
        }

        private int GetYearsFromToday(DateTime dateTime)
        {
            var today = DateTime.Today;
            var a = (today.Year * 100 + today.Month) * 100 + today.Day;
            var b = (dateTime.Year * 100 + dateTime.Month) * 100 + dateTime.Day;
            return (a - b) / 10000;
        }
    }
}