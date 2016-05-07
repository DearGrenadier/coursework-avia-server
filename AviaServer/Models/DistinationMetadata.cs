using System;
using System.ComponentModel.DataAnnotations;

namespace AviaServer.Database
{
    [MetadataType(typeof(DistinationMetadata))]
    public partial class Distination
    {
    }

    public partial class DistinationMetadata
    {
        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Price")]
        public int Price { get; set; }

        [Display(Name = "Departure")]
        public string Departure { get; set; }

        [Display(Name = "Arrive")]
        public string Arrive { get; set; }

        [Display(Name = "Distance")]
        public double Distance { get; set; }

        [Display(Name = "Routes")]
        public Route Routes { get; set; }

    }
}
