using IndWalks.API.Model.Domain;
using System.ComponentModel.DataAnnotations;

namespace IndWalks.API.Model.DTO.Walks
{
    public class AddWalkRequestDTO
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Walk Name Cannot Be Greater Than 100 Char!")]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Range(0,50)]
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        [Required]
        public Guid DifficultyId { get; set; }
        [Required]
        public Guid RegionId { get; set; }

       
    }
}
