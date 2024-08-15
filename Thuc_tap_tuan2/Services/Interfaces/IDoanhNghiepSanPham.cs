using Thuc_tap_tuan2.Entities;

namespace Thuc_tap_tuan2.Services.Interfaces
{
    public interface IDoanhNghiepSanPham
    {
        void getbbyid(int Id);
        void  DoanhNghiepSanPham (DoanhNghiepSanPham input);
    }
}
