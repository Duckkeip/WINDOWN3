using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTX.Models
{
    public class Room
    {
        public int RoomID { get; set; }
        public string RoomType { get; set; }
        public int QuantityStudent { get; set; }
        public string Status { get; set; }
        public decimal Price { get; set; }

        // Danh sách hợp đồng của phòng
        public ICollection<Contract> Contracts { get; set; }
    }
}
