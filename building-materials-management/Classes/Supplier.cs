using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace building_materials_management.Classes
{
    [Table("nhacungcap")]
    public  class Supplier : BaseModel
    {
        [PrimaryKey("id", true)]
        public int Id { get; set; }
        [Column("ten_ncc")]
        public string TenNCC { get; set; }
        [Column("dia_chi")]
        public string DiaChi { get; set; }
        [Column("so_dien_thoai")]
        public string SoDienThoai { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("ma_so_thue")]
        public string MaSoThue { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
