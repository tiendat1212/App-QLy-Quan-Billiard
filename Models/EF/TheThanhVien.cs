using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyQuanBilliard.Models.EF
{
    public class TheThanhVien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TheThanhVienId { get; set; }

        [Required]
        [StringLength(255)]
        public string TenKhachHang { get; set; }

        [Required]
        [StringLength(10)]
        public string SoDienThoai { get; set; }
        public bool IsDelete { get; set; } = false;

        public DateTime NgayDangKy { get; set; }

        public DateTime NgayTao { get; set; } = DateTime.Now;

        public DateTime NgayCapNhap { get; set; } = DateTime.Now;

        public ICollection<HoaDon> HoaDons { get; set; }
    }
}
