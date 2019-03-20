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
    /// ResponseModelObject
    /// </summary>
    [DataContract]
    public partial class ResponseModelObject :  IEquatable<ResponseModelObject>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseModelObject" /> class.
        /// </summary>
        /// <param name="IsSuccess">IsSuccess.</param>
        /// <param name="Errors">Errors.</param>
        /// <param name="Result">Result.</param>
        public ResponseModelObject(bool? IsSuccess = default(bool?), List<string> Errors = default(List<string>), Object Result = default(Object))
        {
            this.IsSuccess = IsSuccess;
            this.Errors = Errors;
            this.Result = Result;
        }
        
        /// <summary>
        /// Gets or Sets IsSuccess
        /// </summary>
        [DataMember(Name="isSuccess", EmitDefaultValue=false)]
        public bool? IsSuccess { get; set; }

        /// <summary>
        /// Gets or Sets Errors
        /// </summary>
        [DataMember(Name="errors", EmitDefaultValue=false)]
        public List<string> Errors { get; set; }

        /// <summary>
        /// Gets or Sets Result
        /// </summary>
        [DataMember(Name="result", EmitDefaultValue=false)]
        public Object Result { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ResponseModelObject {\n");
            sb.Append("  IsSuccess: ").Append(IsSuccess).Append("\n");
            sb.Append("  Errors: ").Append(Errors).Append("\n");
            sb.Append("  Result: ").Append(Result).Append("\n");
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
            return this.Equals(input as ResponseModelObject);
        }

        /// <summary>
        /// Returns true if ResponseModelObject instances are equal
        /// </summary>
        /// <param name="input">Instance of ResponseModelObject to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ResponseModelObject input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.IsSuccess == input.IsSuccess ||
                    (this.IsSuccess != null &&
                    this.IsSuccess.Equals(input.IsSuccess))
                ) && 
                (
                    this.Errors == input.Errors ||
                    this.Errors != null &&
                    this.Errors.SequenceEqual(input.Errors)
                ) && 
                (
                    this.Result == input.Result ||
                    (this.Result != null &&
                    this.Result.Equals(input.Result))
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
                if (this.IsSuccess != null)
                    hashCode = hashCode * 59 + this.IsSuccess.GetHashCode();
                if (this.Errors != null)
                    hashCode = hashCode * 59 + this.Errors.GetHashCode();
                if (this.Result != null)
                    hashCode = hashCode * 59 + this.Result.GetHashCode();
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
