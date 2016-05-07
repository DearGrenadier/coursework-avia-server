using System;
using System.ComponentModel.DataAnnotations;

namespace AviaServer.Database
{
    [MetadataType(typeof(AspNetRoleMetadata))]
    public partial class AspNetRole
    {
    }

    public partial class AspNetRoleMetadata
    {
        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "AspNetUsers")]
        public AspNetUser AspNetUsers { get; set; }

    }
}
