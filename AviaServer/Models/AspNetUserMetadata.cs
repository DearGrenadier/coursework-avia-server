using System;
using System.ComponentModel.DataAnnotations;

namespace AviaServer.Database
{
    [MetadataType(typeof(AspNetUserMetadata))]
    public partial class AspNetUser
    {
    }

    public partial class AspNetUserMetadata
    {
        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "EmailConfirmed")]
        public bool EmailConfirmed { get; set; }

        [Display(Name = "PasswordHash")]
        public string PasswordHash { get; set; }

        [Display(Name = "SecurityStamp")]
        public string SecurityStamp { get; set; }

        [Display(Name = "PhoneNumber")]
        public string PhoneNumber { get; set; }

        [Display(Name = "PhoneNumberConfirmed")]
        public bool PhoneNumberConfirmed { get; set; }

        [Display(Name = "TwoFactorEnabled")]
        public bool TwoFactorEnabled { get; set; }

        [Display(Name = "LockoutEndDateUtc")]
        public DateTime LockoutEndDateUtc { get; set; }

        [Display(Name = "LockoutEnabled")]
        public bool LockoutEnabled { get; set; }

        [Display(Name = "AccessFailedCount")]
        public int AccessFailedCount { get; set; }

        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Display(Name = "AspNetUserClaims")]
        public AspNetUserClaim AspNetUserClaims { get; set; }

        [Display(Name = "AspNetUserLogins")]
        public AspNetUserLogin AspNetUserLogins { get; set; }

        [Display(Name = "Purchases")]
        public Purchase Purchases { get; set; }

        [Display(Name = "AspNetRoles")]
        public AspNetRole AspNetRoles { get; set; }

    }
}
