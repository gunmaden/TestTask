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
    /// MinMaxValueRequestModel
    /// </summary>
    [DataContract]
    public partial class MinMaxValueRequestModel :  IEquatable<MinMaxValueRequestModel>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MinMaxValueRequestModel" /> class.
        /// </summary>
        /// <param name="MinValue">MinValue.</param>
        /// <param name="MaxValue">MaxValue.</param>
        public MinMaxValueRequestModel(int? MinValue = default(int?), int? MaxValue = default(int?))
        {
            this.MinValue = MinValue;
            this.MaxValue = MaxValue;
        }
        
        /// <summary>
        /// Gets or Sets MinValue
        /// </summary>
        [DataMember(Name="minValue", EmitDefaultValue=false)]
        public int? MinValue { get; set; }

        /// <summary>
        /// Gets or Sets MaxValue
        /// </summary>
        [DataMember(Name="maxValue", EmitDefaultValue=false)]
        public int? MaxValue { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class MinMaxValueRequestModel {\n");
            sb.Append("  MinValue: ").Append(MinValue).Append("\n");
            sb.Append("  MaxValue: ").Append(MaxValue).Append("\n");
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
            return this.Equals(input as MinMaxValueRequestModel);
        }

        /// <summary>
        /// Returns true if MinMaxValueRequestModel instances are equal
        /// </summary>
        /// <param name="input">Instance of MinMaxValueRequestModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MinMaxValueRequestModel input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.MinValue == input.MinValue ||
                    (this.MinValue != null &&
                    this.MinValue.Equals(input.MinValue))
                ) && 
                (
                    this.MaxValue == input.MaxValue ||
                    (this.MaxValue != null &&
                    this.MaxValue.Equals(input.MaxValue))
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
                if (this.MinValue != null)
                    hashCode = hashCode * 59 + this.MinValue.GetHashCode();
                if (this.MaxValue != null)
                    hashCode = hashCode * 59 + this.MaxValue.GetHashCode();
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