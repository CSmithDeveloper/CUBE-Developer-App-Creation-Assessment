// <copyright file = "ConvertModel.cs" company="Cube Global">
//     Copyright © 2022 Cube Global. All rights reserved.
// </copyright>
// <author>Christopher Smith - Senior Developer</author>

namespace CubeGlobal.TemperatureConverter.UI.Models
{
    using System.ComponentModel.DataAnnotations;
    using CubeGlobal.TemperatureConverter.Common;

    /// <summary>
    /// The conversion form model.
    /// </summary>
    public class ConvertModel
    {
        /// <summary>
        /// Gets or sets the converted from scale.
        /// </summary>
        /// <value>
        /// The converted from scale.
        /// </value>  
        [Required]
        [Display(Name = "Convert From")]
        public TemperatureScale From { get; set; }

        /// <summary>
        /// Gets or sets the converted to scale.
        /// </summary>
        /// <value>
        /// The converted to scale.
        /// </value>
        [Required]
        [Display(Name = "Convert To")]
        public TemperatureScale To { get; set; }

        /// <summary>
        /// Gets or sets the value to convert.
        /// </summary>
        /// <value>
        /// The value to convert.
        /// </value>
        [Required]
        [Display(Name = "Value to Convert")]
        public decimal Value { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the converted value.
        /// </summary>
        /// <value>
        /// The converted value.
        /// </value>
        public decimal ConvertedValue { get; set; }

        /// <summary>
        /// Gets the converted display value.
        /// </summary>
        /// <value>
        /// The converted display value.
        /// </value>
        [Display(Name = "Converted Value")]
        public string ConvertedDisplayValue
        {
            get
            {
                return HomeViewModel.FormatTemperatureValue(this.To, this.ConvertedValue);
            }
        }
    }
}