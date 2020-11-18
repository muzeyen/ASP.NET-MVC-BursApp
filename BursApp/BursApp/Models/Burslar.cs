using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BursApp.Models
{
    [Table("Burslar")]
    public class Burslar
    {
        [Key]
        public int BursID { get; set; }
        [Required, StringLength(150, ErrorMessage = "150 karakter olmalıdır")]
        [DisplayName("Burs Başlık")]
        public string BursBaslik { get; set; }
        [DisplayName("Burs Açıklama")]
        public string BursAciklama { get; set; }
        [DisplayName("Burs Miktarı")]
        public int BursMiktari { get; set; }
    }
}