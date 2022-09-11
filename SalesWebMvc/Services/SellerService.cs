using System;
using SalesWebMvc.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Services.Exceptions;
using System.Threading.Tasks;


namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _context;

        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task InsertAsync (Seller obj)
        {
            _context.Add(obj);
           await _context.SaveChangesAsync();
        }
        
        public async Task RemoveAsync(int Id)
        {
            try { 
            var obj = await _context.Seller.FindAsync(Id);
            _context.Seller.Remove(obj);
          await  _context.SaveChangesAsync();
            }catch(DbUpdateException)
            {
                throw new IntegrityException("Cannot delete because this seller has seles");
            }
        }

        public async Task<Seller> FindByIDAsync(int Id)
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.id == Id);

        }

        public async Task UpdateAsync(Seller obj)
        {
            bool hasAny = await _context.Seller.AnyAsync(x => x.id == obj.id);
            if (!hasAny)
            {
                throw new NotFoundException("ID not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();

            }catch(DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
            
        }
    }
}
