using Postgrest.Attributes;
using Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace building_materials_management.Classes
{
    [Table("danhmucvattu")]
    public class Category : BaseModel
    {
        [PrimaryKey("id", true)]
        public long Id { get; set; }

        [Column("ten_danh_muc")]
        public string TenDanhMuc { get; set; }

        [Column("mo_ta")]
        public string MoTa { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
