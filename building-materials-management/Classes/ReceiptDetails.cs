using Postgrest.Attributes;
using Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace building_materials_management.Classes
{
    [Table("chitietnhapkho")]
    public class ChiTietNhapKho : BaseModel
    {
        [PrimaryKey("id", true)]
        public long Id { get; set; }

        [Column("id_phieu_nhap")]
        public long? IdPhieuNhap { get; set; }

        [Column("id_vat_tu")]
        public long? IdVatTu { get; set; }

        [Column("so_luong")]
        public int? SoLuong { get; set; }

        [Column("don_gia_nhap")]
        public decimal? DonGiaNhap { get; set; }

        [Column("thanh_tien")]
        public decimal? ThanhTien { get; set; }
    }
}
