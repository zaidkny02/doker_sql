using System.ComponentModel.DataAnnotations;

namespace docker_sql.Models
{
    public class KhachHangModel
    {
        [Key]
        public int iMaKH { get; set; }
        public string? sTenKH { get; set; }
        public string? sDiachi { get; set; }
        public string? sDienthoai { get; set; }
        public bool bGioitinh { get; set; }

        public KhachHangModel(int iMaKH,string? sTenKH, string? sDiachi, string? sDienthoai, bool bGioitinh)
        {
            this.iMaKH = iMaKH;
            this.sTenKH = sTenKH;
            this.sDiachi = sDiachi;
            this.sDienthoai = sDienthoai;
            this.bGioitinh = bGioitinh;
        }
    }
}
