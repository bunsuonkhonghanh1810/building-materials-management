using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace building_materials_management.Classes
{
    [Table("phieunhapkho")]
    public class Receipt : BaseModel
    {
        [PrimaryKey("id", true)]
        public int Id { get; set; }
        [Column("ma_phieu")]
        public string MaPhieu { get; set; }
        [Column("id_ncc")]
        public int IdNCC { get; set; }
        [Column("id_nguoi_tao")]
        public Guid IdNguoiTao { get; set; }
        [Column("ngay_nhap")]
        public DateTime NgayNhap { get; set; }
        [Column("tong_tien")]
        public decimal TongTien { get; set; }
        [Column("trang_thai")]
        public string TrangThai { get; set; }
        [Column("ghi_chu")]
        public string GhiChu { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Column("is_deleted")]
        public bool IsDeleted { get; set; } = false;
    }
}
