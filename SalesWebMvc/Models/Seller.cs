using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength (60, MinimumLength = 3, ErrorMessage = "{0} size should be betwen {2} or {1}")]
        [Display(Name = "Name")]
        public string name { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [EmailAddress(ErrorMessage ="Enter a valid E-mail")]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string email  { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime bitrhDate { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Range(100.0, 50000.0, ErrorMessage ="{0} must be from {1} or {2}")]
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
