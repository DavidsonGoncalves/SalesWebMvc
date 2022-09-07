using System;
using SalesWebMvc.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Services.Exceptions;


namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _context;

        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert (Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
        
        public void Remove(int Id)
        {
            var obj = _context.Seller.Find(Id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public Seller FindByID(int Id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.id == Id);

        }

        public void Update(Seller obj)
        {
            if (!_context.Seller.Any(x => x.id == obj.id))
            {
                throw new NotFoundException("ID not found");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();

            }catch(DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
            
        }
    }
}
