using Thuc_tap_tuan2.DbContexts;
using Thuc_tap_tuan2.Dtos;
using Thuc_tap_tuan2.Entities;
using Thuc_tap_tuan2.Services.Interfaces;

namespace Thuc_tap_tuan2.Services.Implements
{
    public class DoanhNghiepService : IDoanhNghiepService
    {
        private readonly Data _context; 
        public DoanhNghiepService (Data context)
        {
            _context = context;
        }

        public void Create(CreateDoanhNghiepDto input)
        {
            var dn = new DoanhNghiep
            {

                TenDN = input.TenDN,
                DiaChi = input.DiaChi,
                MST = input.MST,
            };
            _context.Add(dn);
            _context.SaveChanges();
        }

        public DoanhNghiepDto Getbyid(int Id)
        {
            var dn = _context.DoanhNghieps.SingleOrDefault(e=>e.IdDN == Id);
            
            if (dn == null)
            {
                return null;
            }
            var dndto = new DoanhNghiepDto
            {
                IdDN = dn.IdDN,
                TenDN = dn.TenDN,
                DiaChi = dn.DiaChi,
                MST = dn.MST,
               
            };
            return dndto;
        }
        public void Delete(int id)
        {
            var dn=_context.DoanhNghieps.SingleOrDefault(e=>e.IdDN==id);
            _context.Remove(dn);
        }
        public void Update(UpdateDoangNghiepDto input)
        {
            var dn = _context.DoanhNghieps.SingleOrDefault(e => e.IdDN == input.IdDN);
            if (dn == null)
            {
                throw new Exception("doanh nghieo not found");
            }
            dn.TenDN = input.TenDN;
            dn.MST = input.MST;
            dn.DiaChi =input.DiaChi;
            _context.DoanhNghieps.Update(dn);    
            _context.SaveChanges();
        }
        public List<DoanhNghiep> GetAll()
        {
            return _context.DoanhNghieps.ToList();
        }
    }
}
