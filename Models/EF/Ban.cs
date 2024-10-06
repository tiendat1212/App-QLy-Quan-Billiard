using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyQuanBilliard.Models.EF
{
    public class Ban
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BanId { get; set; }

        [Required]
        [StringLength(100)]
        public string TenBan { get; set; }

        [Required]
        public string TrangThai { get; set; }

        [Required]
        public long GiaGio { get; set; }
        public bool IsDelete { get; set; } = false;

        public DateTime NgayTao { get; set; } = DateTime.Now;

        public DateTime NgayCapNhap { get; set; } = DateTime.Now;
    }
}
