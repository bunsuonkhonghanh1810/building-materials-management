using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System;
using Newtonsoft.Json;  // ✅ dùng thư viện này

namespace building_materials_management.Classes
{
    [Table("vattu")]
    public class Material : BaseModel
    {
        [PrimaryKey("id", false)]
        public long Id { get; set; }

        [Column("ma_vat_tu")]
        public string MaVatTu { get; set; }

        [Column("ten_vat_tu")]
        public string TenVatTu { get; set; }

        [Column("don_vi_tinh")]
        public string DonViTinh { get; set; }

        [Column("ton_kho")]
        public int TonKho { get; set; }

        [Column("id_danh_muc")]
        public long IdDanhMuc { get; set; }

        [Column("link_anh")]
        public string LinkAnh { get; set; }

        [Column("is_deleted")]
        public bool IsDeleted { get; set; } = false;

        // ✅ Dùng JsonIgnore của Newtonsoft.Json (đúng với SDK Supabase hiện nay)
        [Reference(typeof(Category), foreignKey: "id_danh_muc")]
        [JsonProperty("danhmucvattu")]   // tên bảng join trong query
        public Category Categories { get; set; }
    }
}
