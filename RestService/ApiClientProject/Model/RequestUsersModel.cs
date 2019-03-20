/* 
 * My API
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: v1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = ApiClientProject.Client.SwaggerDateConverter;

namespace ApiClientProject.Model
{
    /// <summary>
    /// RequestUsersModel
    /// </summary>
    [DataContract]
    public partial class RequestUsersModel :  IEquatable<RequestUsersModel>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestUsersModel" /> class.
        /// </summary>
        /// <param name="Page">Page.</param>
        /// <param name="PageSize">PageSize.</param>
        /// <param name="Age">Age.</param>
        /// <param name="WorkingExperience">WorkingExperience.</param>
        /// <param name="Positions">Positions.</param>
        public RequestUsersModel(int? Page = default(int?), int? PageSize = default(int?), MinMaxValueRequestModel Age = default(MinMaxValueRequestModel), MinMaxValueRequestModel WorkingExperience = default(MinMaxValueRequestModel), List<Guid?> Positions = default(List<Guid?>))
        {
            this.Page = Page;
            this.PageSize = PageSize;
            this.Age = Age;
            this.WorkingExperience = WorkingExperience;
            this.Positions = Positions;
        }
        
        /// <summary>
        /// Gets or Sets Page
        /// </summary>
        [DataMember(Name="page", EmitDefaultValue=false)]
        public int? Page { get; set; }

        /// <summary>
        /// Gets or Sets PageSize
        /// </summary>
        [DataMember(Name="pageSize", EmitDefaultValue=false)]
        public int? PageSize { get; set; }

        /// <summary>
        /// Gets or Sets Age
        /// </summary>
        [DataMember(Name="age", EmitDefaultValue=false)]
        public MinMaxValueRequestModel Age { get; set; }

        /// <summary>
        /// Gets or Sets WorkingExperience
        /// </summary>
        [DataMember(Name="workingExperience", EmitDefaultValue=false)]
        public MinMaxValueRequestModel WorkingExperience { get; set; }

        /// <summary>
        /// Gets or Sets Positions
        /// </summary>
        [DataMember(Name="positions", EmitDefaultValue=false)]
        public List<Guid?> Positions { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class RequestUsersModel {\n");
            sb.Append("  Page: ").Append(Page).Append("\n");
            sb.Append("  PageSize: ").Append(PageSize).Append("\n");
            sb.Append("  Age: ").Append(Age).Append("\n");
            sb.Append("  WorkingExperience: ").Append(WorkingExperience).Append("\n");
            sb.Append("  Positions: ").Append(Positions).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as RequestUsersModel);
        }

        /// <summary>
        /// Returns true if RequestUsersModel instances are equal
        /// </summary>
        /// <param name="input">Instance of RequestUsersModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RequestUsersModel input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Page == input.Page ||
                    (this.Page != null &&
                    this.Page.Equals(input.Page))
                ) && 
                (
                    this.PageSize == input.PageSize ||
                    (this.PageSize != null &&
                    this.PageSize.Equals(input.PageSize))
                ) && 
                (
                    this.Age == input.Age ||
                    (this.Age != null &&
                    this.Age.Equals(input.Age))
                ) && 
                (
                    this.WorkingExperience == input.WorkingExperience ||
                    (this.WorkingExperience != null &&
                    this.WorkingExperience.Equals(input.WorkingExperience))
                ) && 
                (
                    this.Positions == input.Positions ||
                    this.Positions != null &&
                    this.Positions.SequenceEqual(input.Positions)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Page != null)
                    hashCode = hashCode * 59 + this.Page.GetHashCode();
                if (this.PageSize != null)
                    hashCode = hashCode * 59 + this.PageSize.GetHashCode();
                if (this.Age != null)
                    hashCode = hashCode * 59 + this.Age.GetHashCode();
                if (this.WorkingExperience != null)
                    hashCode = hashCode * 59 + this.WorkingExperience.GetHashCode();
                if (this.Positions != null)
                    hashCode = hashCode * 59 + this.Positions.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}