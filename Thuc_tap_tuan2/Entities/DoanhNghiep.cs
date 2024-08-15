namespace Thuc_tap_tuan2.Entities
{
    public class DoanhNghiep
    {
        public int IdDN { get; set; }
        public string TenDN { get; set; }
        public string MST {  get; set; }
        public string DiaChi { get; set; }
        public ICollection<DoanhNghiepSanPham> DoanhNghiepSanPhams { get; set; }
        
    }
}
