namespace Thuc_tap_tuan2.Entities
{
    public class SanPham
    {
        public int IdSP { get; set; }
        public string TenSp {  get; set; }
        public string MaSp { get; set; }
        public DateTime NgayNhap { get; set; }
        public ICollection<DoanhNghiepSanPham> DoanhNghiepSanPhams { get; set; }    
        
    }
}
      