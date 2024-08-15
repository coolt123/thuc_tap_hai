namespace Thuc_tap_tuan2.Entities
{
    public class DoanhNghiepSanPham
    {
        public int IdSP { get; set; }
        public int IdDN { get; set; }
        public int  Soluong {  get; set; }
        public DoanhNghiep DoanhNghiep { get; set; }
        public SanPham SanPham { get; set; } 

    }
}
