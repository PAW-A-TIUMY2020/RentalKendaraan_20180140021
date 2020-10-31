using System;
using System.Collections.Generic;

namespace RentalKendaraan_20180140021.Models
{
    public partial class Customer
    {
        public int IdCustomer { get; set; }
        public string NamaCostumer { get; set; }
        public string Nik { get; set; }
        public string Alamat { get; set; }
        public string NoHp { get; set; }
        public int? IdGender { get; set; }

        public Gender IdCustomerNavigation { get; set; }
        public Peminjaman Peminjaman { get; set; }
    }
}
