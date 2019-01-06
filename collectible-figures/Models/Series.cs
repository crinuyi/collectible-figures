using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace collectible_figures.Models {
    public class Series {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SeriesID { get; set; }

        [DataType(DataType.Text)]
        [Required]
        [DisplayName("Nazwa serii")]
        public string Name { get; set; }

        public virtual ICollection<Figure> Figures { get; set; }

    }
}