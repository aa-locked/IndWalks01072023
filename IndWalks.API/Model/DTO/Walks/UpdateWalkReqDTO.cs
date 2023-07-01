using System.ComponentModel.DataAnnotations;

namespace IndWalks.API.Model.DTO.Walks
{
    public class UpdateWalkReqDTO
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Walk Name Cannot Be Greater Than 100 Char!")]
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }

        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }
    }
}
