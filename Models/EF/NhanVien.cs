using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyQuanBilliard.Models.EF
{
    public class NhanVien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NhanVienId { get; set; }

        [Required]
        [StringLength(60)]
        public string TenNhanVien { get; set; }

        public DateTime NgaySinh { get; set; }
        [StringLength(10)]
        public string SoDienThoai { get; set; }

        [StringLength(255)]
        public string Email { get; set; }
        [Required]
        [StringLength(255)]
        public string ChucVu { get; set; }

        public long LuongCoBan { get; set; }

        public bool IsDelete { get; set; } = false;

        public DateTime NgayBatDauLam { get; set; }

        public DateTime NgayTao { get; set; } = DateTime.Now;

        public DateTime NgayCapNhap { get; set; } = DateTime.Now;
    }
}
