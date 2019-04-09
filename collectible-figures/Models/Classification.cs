using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace collectible_figures.Models {
    public class Classification {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClassificationID { get; set; }

        [DataType(DataType.Text)]
        [Required]
        [DisplayName("Nazwa typu")]
        [RegularExpression("^[A-Z][A-Za-ząęółćżźśĄĘÓŚŻŹĆŁ '-]+$", ErrorMessage = "Nazwa typu musi zaczynać się z wielkiej litery, nie zawierać znaków specjalnych i cyfr.")]
        [Remote(
            action: "DoesNameExists", 
            controller: "Classifications",
            ErrorMessage = "Podany typ już istnieje!"
        )]
        public string Name { get; set; }

        public virtual ICollection<Figure> Figures { get; set; }
    }
}