using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentalKendaraan_20180140021.Models
{
    public partial class Gender
    {
        public int IdGender { get; set; }
        [Required(ErrorMessage = "Jenis Gender tidak boleh kosong")]
        public string NamaGender { get; set; }

        public Customer Customer { get; set; }
    }
}
