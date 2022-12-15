using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ServerAPI.Contracts;

namespace ServerAPI.Entities.Models
{
     public class Cinema
    {
        [Key]
        [Column("CinemaId")]
        public Guid Id { get; set; }
[Display(Name = "Cinema Logo")]
        [Required(ErrorMessage = "Cinema logo is required")]
        public string Logo { get; set; }

        [Display(Name = "Cinema Name")]
        [Required(ErrorMessage = "Cinema name is required")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Cinema description is required")]
        public string Description { get; set; }

        //Relationships
          public ICollection<Movie> Movies { get; set; }
    }
}