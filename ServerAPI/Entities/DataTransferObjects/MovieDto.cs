using System.ComponentModel.DataAnnotations.Schema;
using ServerAPI.Contracts.Enums;
using ServerAPI.Entities.Models;

namespace ServerAPI.Entities.DataTransferObjects
{
    public class MovieDto
    {
        
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
        public MovieCategory MovieCategory { get; set; }

          //Relationships
        public List<Actor_MovieDto> Actors_Movies { get; set; }

        //Cinema]
        
        public Guid CinemaId { get; set; }
        public Guid ProducerId { get; set; }



    }
}