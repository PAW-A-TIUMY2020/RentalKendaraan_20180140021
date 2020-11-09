using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentalKendaraan_20180140021.Models
{
    public partial class Pengembalian
    {
        public int IdPengembalian { get; set; }
        public DateTime? TglPengembalian { get; set; }
        public int? IdPeminjaman { get; set; }
        [Required(ErrorMessage = "Kondisi tidak boleh kosong")]
        public int? IdKondisi { get; set; }
        [Required(ErrorMessage = "Denda tidak boleh kosong")]
        public int? Denda { get; set; }

        public Peminjaman IdPengembalian1 { get; set; }
        public KondisiKendaraan IdPengembalianNavigation { get; set; }
    }
}
