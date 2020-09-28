using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FinderDisc.Models
{
    public class Disc
    {
        public int DiscId { get; set; }
        public string DiscName { get; set; }
        
        public int MusicId { get; set; }   
        [Display(Name = "Music")] 
        public Music Music { get; set; }
        
        public int DispenserId { get; set; }
        public Dispenser Dispenser { get; set; }
    }
}