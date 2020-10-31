using System;
using System.Collections.Generic;

namespace RentalKendaraan_20180140021.Models
{
    public partial class Peminjaman
    {
        public int IdPeminjaman { get; set; }
        public DateTime? TglPeminjaman { get; set; }
        public int? IdKendaraan { get; set; }
        public int? IdCustomer { get; set; }
        public int? IdJaminan { get; set; }
        public int? Biaya { get; set; }

        public Jaminan IdPeminjaman1 { get; set; }
        public Kendaraan IdPeminjaman2 { get; set; }
        public Customer IdPeminjamanNavigation { get; set; }
        public Pengembalian Pengembalian { get; set; }
    }
}
