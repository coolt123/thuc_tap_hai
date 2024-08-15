using System.ComponentModel.DataAnnotations;

namespace Thuc_tap_tuan2.Dtos
{
    public class CreateDoanhNghiepDto
    {
        private string _tenDN;
        [Required(AllowEmptyStrings = false, ErrorMessage = " không được bỏ trống")]
        public string TenDN
        {
            get => _tenDN; set => _tenDN = value?.Trim();
        }
        private string _mst; 
        [Required(AllowEmptyStrings = false, ErrorMessage = " không được bỏ trống")]
        public string MST 
        {
            get=>_mst; set=>_mst=value?.Trim(); 
        }
        private string _diachi;
        [Required(AllowEmptyStrings = false, ErrorMessage = " không được bỏ trống")]
        public string DiaChi { get=>_diachi; set=>_diachi=value?.Trim(); }
    }
}
