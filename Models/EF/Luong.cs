using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyQuanBilliard.Models.EF
{
    public class Luong
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LuongId { get; set; }

        [ForeignKey("NhanVien")]
        public int NhanVienId { get; set; }

        public DateTime Thang { get; set; }

        public long LuongCoBan { get; set; }

        public long Thuong { get; set; }
        public long ThanhTien => LuongCoBan + Thuong;

        public bool IsDelete { get; set; } = false;

        public NhanVien? NhanVien { get; set; }

        public DateTime NgayTao { get; set; } = DateTime.Now;

        public DateTime NgayCapNhap { get; set; } = DateTime.Now;
    }
}