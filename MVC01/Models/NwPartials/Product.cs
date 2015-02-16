using MVC01.Models.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC01.Models.Northwind
{
    [MetadataType(typeof(ProductMetaData))]
    public partial class Product { }

    public class ProductMetaData
    {
        [HiddenInput(DisplayValue = false)]
        public object ProductID { get; set; }

        [Required (ErrorMessage="Product name is required.")]
        [Display(Name = "Product Name")]
        [StringLength(30, ErrorMessage = "The {0} must be between {2} and {1} characters.", MinimumLength = 5)]
        [ExcludeChar("/.,!@#$%", ErrorMessage = "Name contains invalid character.")]
        [RegularExpression(@"^([a-zA-Z0-9]+[^a-zA-Z0-9]*){1,8}$", ErrorMessage = "Maximum 3 words")]
        public object ProductName { get; set; }

        [Required(ErrorMessage = "Unit price is required.")]
        [DataType(DataType.Currency)]
        public object UnitPrice { get; set; }

        [ScaffoldColumn(false)]
        public object ReorderLevel { get; set; }

        [UIHint("_CategoryDropDown")]
        public object CategoryID { get; set; }

        [UIHint("_SupplierDropDown")]
        public object SupplierID { get; set; }
    }
}