using System.ComponentModel.DataAnnotations;

namespace IndWalks.API.Model.DTO
{
    public class AddRegionReqDTO
    {
        [Required]
        [MinLength(3, ErrorMessage = "Code has to be Minimum 3 Char!")]
        [MaxLength(3, ErrorMessage = "Code has to be Maximum 3 Char!")]
        public string Code { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Name Cannot Be More Than 100 Char!")]
        public string Name { get; set; }

        public string? RegionImageUrl { get; set; }
    }
}
