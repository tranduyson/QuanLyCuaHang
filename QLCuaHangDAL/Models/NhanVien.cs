using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCuaHangDAL.Models
{
    public class NhanVien
    {
        public int MaNV { get; set; }          // Mã nhân viên
        public string HoTen { get; set; }      // Họ và tên
        public string GioiTinh { get; set; }   // Giới tính
        public string DiaChi { get; set; }     // Địa chỉ
        public string SoDienThoai { get; set; } // Số điện thoại
        public string Email { get; set; }      // Email
        public string ChucVu { get; set; }     // Chức vụ
        public decimal Luong { get; set; }     // Lương
        public DateTime NgayVaoLam { get; set; } // Ngày vào làm
    }
}
