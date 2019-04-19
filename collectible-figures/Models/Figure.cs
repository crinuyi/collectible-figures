using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace collectible_figures.Models {
    public class Figure {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FigureID { get; set; }

        [DataType(DataType.Text)]
        [Required]
        [StringLength(1000)]
        [DisplayName("Nazwa figurki")]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        [RegularExpression("^1:[0-9]*$", ErrorMessage = "Skala musi zostać przedstawiona jako 1:[liczba].")]
        [DisplayName("Skala")]
        [Required]
        public string Scale { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Data wydania")]
        [Required]
        public DateTime ReleaseDate { get; set; }

        [DataType(DataType.Currency)]
        [Required]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        [DisplayName("Cena")]
        public decimal Price { get; set; }

        [ForeignKey("Classification")]
        [DisplayName("Typ")]
        public int ClassificationID { get; set; }
        
        public virtual Classification Classification { get; set; }

        [ForeignKey("Series")]
        [DisplayName("Seria")]
        public int SeriesID { get; set; }
        
        public virtual Series Series { get; set; }     
    }
}