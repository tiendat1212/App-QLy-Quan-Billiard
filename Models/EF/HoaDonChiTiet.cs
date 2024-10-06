using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyQuanBilliard.Models.EF
{
    public class HoaDonChiTiet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HoaDonChiTietId { get; set; }

        [ForeignKey("HoaDon")]
        public int HoaDonId { get; set; }

        [ForeignKey("Kho")]
        public int IdKho { get; set; }

        public int SoLuong { get; set; }

        public long GiaNhap { get; set; }
        public long GiaBan { get; set; }

        public long ThanhTien => SoLuong * GiaBan;

        public HoaDon? HoaDon { get; set; }

        public Kho? Kho { get; set; }
    }
}
