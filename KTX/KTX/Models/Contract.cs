using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTX.Models
{
    public class Contract
    {
        public int ContractID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long StudentID { get; set; }
        public int RoomID { get; set; }
        public decimal Price { get; set; }

        public bool IsNotified { get; set; } = false;

        // Khóa ngoại
        public Student Student { get; set; }
        public Room Room { get; set; }
    }
}
