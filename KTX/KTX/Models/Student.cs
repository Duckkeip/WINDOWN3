using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTX.Models
{
    public class Student
    {
        [Key]
        public long StudentID { get; set; }

        public string Name { get; set; }
        public DateTime DoB { get; set; }
        public string Class { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }

        // Danh sách hợp đồng của sinh viên
        public ICollection<Contract> Contracts { get; set; }
    }
}
