using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ServerAPI.Contracts;
using ServerAPI.Contracts.Enums;

namespace ServerAPI.Entities.Models
{
    public class Movie
    {
         [Key]
          [Column("MovieId")]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
         public MovieCategory MovieCategory { get; set; }


         //Relationships
        public List<Actor_Movie> Actors_Movies { get; set; }

        //Cinema]
        
    [ForeignKey(nameof(Cinema))]
    public Guid CinemaId { get; set; }
  public Cinema Cinemas { get; set; }




        //Producer

    [ForeignKey(nameof(Producer))]
    public Guid ProducerId { get; set; }
     public Producer Producers { get; set; }




    }
}