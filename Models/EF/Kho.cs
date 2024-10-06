using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyQuanBilliard.Models.EF
{
    public class Kho
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMatHang { get; set; }

        [Required]
        [StringLength(100)]
        public string TenMatHang { get; set; }

        public int SoLuong { get; set; }

        public long GiaNhap { get; set; }

        public long GiaBan { get; set; }

        public bool IsDelete { get; set; } = false;

        public DateTime NgayTao { get; set; } = DateTime.Now;

        public DateTime NgayCapNhap { get; set; } = DateTime.Now;

    }
}
