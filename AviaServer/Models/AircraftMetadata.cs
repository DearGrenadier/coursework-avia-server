using System;
using System.ComponentModel.DataAnnotations;

namespace AviaServer.Database
{
    [MetadataType(typeof(AircraftMetadata))]
    public partial class Aircraft
    {
    }

    public partial class AircraftMetadata
    {
        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "AircraftNumber")]
        public string GovId { get; set; }

        [Display(Name = "Capacity")]
        public int Capacity { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Routes")]
        public Route Routes { get; set; }

    }
}
