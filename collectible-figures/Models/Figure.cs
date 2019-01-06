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
        [DisplayName("Nazwa figurki")]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        [RegularExpression("^1:[0-9]*$", ErrorMessage = "Scale must contain 1:[number].")]
        [DisplayName("Skala")]
        public string Scale { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Data wydania")]
        public DateTime ReleaseDate { get; set; }

        [DataType(DataType.Currency)]
        [Required]
        [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
        [DisplayName("Cena")]
        public decimal Price { get; set; }

        [ForeignKey("Classification")]
        public int ClassificationID { get; set; }

        [DisplayName("Typ")]
        public virtual Classification Classification { get; set; }

        [ForeignKey("Series")]
        public int SeriesID { get; set; }

        [DisplayName("Seria")]
        public virtual Series Series { get; set; }     
    }
}