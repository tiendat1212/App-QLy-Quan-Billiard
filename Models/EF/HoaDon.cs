using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyQuanBilliard.Models.EF
{
    public class HoaDon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HoaDonId { get; set; }

        [ForeignKey("Ban")]
        public int BanId { get; set; }

        [ForeignKey("NhanVien")]
        public int NhanVienId { get; set; }

        [ForeignKey("TheThanhVien")]
        public int? TheThanhVienId { get; set; }

        public DateTime NgayLap { get; set; } = DateTime.Now;

        public TimeSpan GioBatDau { get; set; }

        public TimeSpan GioKetThuc { get; set; }
        public long GiaGio { get; set; }

        public long TongTien { get; set; }

        public string TrangThai { get; set; } = "Chưa thanh toán";
        public Ban? Ban { get; set; }

        public NhanVien? NhanVien { get; set; }

        public TheThanhVien? TheThanhVien { get; set; }

        public ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; } = new List<HoaDonChiTiet>();
    }
}
