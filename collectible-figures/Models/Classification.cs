using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace collectible_figures.Models {
    public class Classification {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClassificationID { get; set; }

        [DataType(DataType.Text)]
        [Required]
        [DisplayName("Nazwa typu")]
        public string Name { get; set; }

        public virtual ICollection<Figure> Figures { get; set; }
    }
}