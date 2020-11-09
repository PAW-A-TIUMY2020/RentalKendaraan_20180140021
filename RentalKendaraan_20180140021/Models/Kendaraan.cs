using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentalKendaraan_20180140021.Models
{
    public partial class Kendaraan
    {
        public int IdKendaraan { get; set; }
        [Required(ErrorMessage = "Nama Kendaraan tidak boleh kosong")]
        public string NamaKendaraan { get; set; }
        [MinLength(4, ErrorMessage = "No Polisi minimal 4 karakter yang terdiri dari huruf dan angka")]
        [MaxLength(8, ErrorMessage = "No Polisi maksimal 8 karakter yang terdiri dari huruf dan  angka")]
        public string NoPolisi { get; set; }
        [MinLength(4, ErrorMessage = "No STNK Minimal 4 angka")]
        [MaxLength(8, ErrorMessage = "No STNK maksimal 8 angka")]
        public string NoStnk { get; set; }
        public int? IdJenisKendaraan { get; set; }
        public string Ketersediaan { get; set; }

        public JenisKendaraan IdKendaraanNavigation { get; set; }
        public Peminjaman Peminjaman { get; set; }
    }
}
