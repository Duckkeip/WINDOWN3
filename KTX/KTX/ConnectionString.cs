using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class ConnectionString
    {
        // Thêm @ để lấy giá trị chuỗi tuyệt đối, không format lại chuỗi.
        public static string connectionString = @"Server=DESKTOP-DGCSRGJ;Database=KTXVAA;Trusted_Connection=True;TrustServerCertificate=True;";
        public ConnectionString() { }
    }
}
