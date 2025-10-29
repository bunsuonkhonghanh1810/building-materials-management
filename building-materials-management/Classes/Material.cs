using Postgrest.Attributes;
using Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace building_materials_management.Classes
{
    [Table("vattu")]
    public class VatTu : BaseModel
    {
        [PrimaryKey("id", true)]
        public long Id { get; set; }

        [Column("ma_vat_tu")]
        public string MaVatTu { get; set; }

        [Column("ten_vat_tu")]
        public string TenVatTu { get; set; }

        [Column("don_vi_tinh")]
        public string DonViTinh { get; set; }

        [Column("ton_kho")]
        public int? TonKho { get; set; }

        [Column("id_danh_muc")]
        public long? IdDanhMuc { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
}
