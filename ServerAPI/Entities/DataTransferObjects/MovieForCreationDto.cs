using System.ComponentModel.DataAnnotations.Schema;
using ServerAPI.Contracts.Enums;
using ServerAPI.Entities.Models;

namespace ServerAPI.Entities.DataTransferObjects
{
    public class MovieForCreationDto
    {
         public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
         public MovieCategory MovieCategory { get; set; }

        public Guid CinemaId { get; set; }

        public Guid ProducerId { get; set; }

    }
}