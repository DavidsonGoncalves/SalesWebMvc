using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int id { get; set; }

        [Display(Name = "Name")]
        public string name { get; set; }

        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string email  { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime bitrhDate { get; set; }

        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString ="$ {0:F2}")]
        
        public double baseSalary { get; set; }

        
        public Department Department { get; set; }
        public int DepartmentID { get; set; }

        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();


        public Seller()
        {

        }
        public Seller(int id, string name, string email, DateTime bitrhDate, double baseSalary, Department department)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.bitrhDate = bitrhDate;
            this.baseSalary = baseSalary;
            Department = department;
           
        }

        public void AddSales (SalesRecord sr)
        {
            Sales.Add(sr);
        }
        public void SalesRemove(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
