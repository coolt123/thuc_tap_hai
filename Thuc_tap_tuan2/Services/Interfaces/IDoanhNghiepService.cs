using Thuc_tap_tuan2.Dtos;
using Thuc_tap_tuan2.Entities;

namespace Thuc_tap_tuan2.Services.Interfaces
{
    public interface IDoanhNghiepService
    {
       void Create(CreateDoanhNghiepDto input);
        DoanhNghiepDto Getbyid(int Id);
       void Update(UpdateDoangNghiepDto input); 
       void Delete(int id);
        List<DoanhNghiep> GetAll();
    }
}
