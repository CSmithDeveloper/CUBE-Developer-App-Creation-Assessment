// <copyright file = "AuditModel.cs" company="Cube Global">
//     Copyright © 2022 Cube Global. All rights reserved.
// </copyright>
// <author>Christopher Smith - Senior Developer</author>

namespace CubeGlobal.TemperatureConverter.UI.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using CubeGlobal.TemperatureConverter.Common;

    /// <summary>
    /// The audit grid model.
    /// </summary>
    public class AuditModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the converted from scale.
        /// </summary>
        /// <value>
        /// The converted from scale.
        /// </value>     
        [Display(Name = "Converted From")]
        public TemperatureScale ConvertedFromScale { get; set; }

        /// <summary>
        /// Gets or sets the converted from value.
        /// </summary>
        /// <value>
        /// The converted from value.
        /// </value>  
        public decimal ConvertedFromValue { get; set; }

        /// <summary>
        /// Gets the converted from display value.
        /// </summary>
        /// <value>
        /// The converted from display value.
        /// </value>
        [Display(Name = "Convert Value")]
        public string ConvertedFromDisplayValue
        {
            get
            {
                return HomeViewModel.FormatTemperatureValue(this.ConvertedFromScale, this.ConvertedFromValue);
            }
        }

        /// <summary>
        /// Gets or sets the converted to scale.
        /// </summary>
        /// <value>
        /// The converted to scale.
        /// </value>
        [Display(Name = "Converted To")]
        public TemperatureScale ConvertedToScale { get; set; }

        /// <summary>
        /// Gets or sets the converted to value.
        /// </summary>
        /// <value>
        /// The converted to value.
        /// </value>
        [Display(Name = "Converted Value")]
        public decimal ConvertedToValue { get; set; }

        /// <summary>
        /// Gets the converted to display value.
        /// </summary>
        /// <value>
        /// The converted to display value.
        /// </value>
        [Display(Name = "Converted Value")]
        public string ConvertedToDisplayValue
        {
            get
            {
                return HomeViewModel.FormatTemperatureValue(this.ConvertedToScale, this.ConvertedToValue);
            }
        }

        /// <summary>
        /// Gets or sets the converted by.
        /// </summary>
        /// <value>
        /// The converted by.
        /// </value>
        [Display(Name = "Converted By")]
        public string ConvertedBy { get; set; }

        /// <summary>
        /// Gets or sets the converted at.
        /// </summary>
        /// <value>
        /// The converted at.
        /// </value>
        [Display(Name = "Converted At")]
        public DateTime ConvertedAt { get; set; }
    }
}