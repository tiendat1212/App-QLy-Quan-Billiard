using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace QuanLyQuanBilliard.Models.EF
{
    public class TaiKhoan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaiKhoanId { get; set; }

        [ForeignKey("NhanVien")]
        public int NhanVienId { get; set; }

        [Required]
        [StringLength(100)]
        public string TenDangNhap { get; set; }

        [Required]
        [StringLength(255)]
        public string MatKhau { get; set; }
        [Required]
        [StringLength(255)]
        public string TenQuyen { get; set; }
        public bool IsDelete { get; set; } = false;

        public NhanVien? NhanVien { get; set; }

        public DateTime NgayTao { get; set; } = DateTime.Now;

        public DateTime NgayCapNhap { get; set; } = DateTime.Now;

    }
}