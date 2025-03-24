using QLCuaHangDAL;
using QLCuaHangDAL.Models;
using System.Text.RegularExpressions;

namespace QLCuaHangBLL
{
    public class NhanVienBLL
    {
        private NhanVienDAL nhanVienDAL = new NhanVienDAL();

        // 1. Lấy danh sách nhân viên
        public List<NhanVien> GetAllNhanVien()
        {
            return nhanVienDAL.GetAllNhanVien();
        }

        // 2. Thêm nhân viên (có kiểm tra dữ liệu đầu vào)
        public string AddNhanVien(NhanVien nv)
        {
            string validationMessage = ValidateNhanVien(nv);
            if (validationMessage != "OK")
            {
                return validationMessage; // Trả về lỗi nếu dữ liệu không hợp lệ
            }

            bool result = nhanVienDAL.AddNhanVien(nv);
            return result ? "Thêm nhân viên thành công!" : "Thêm nhân viên thất bại!";
        }

        // 3. Cập nhật nhân viên (có kiểm tra dữ liệu đầu vào)
        public string UpdateNhanVien(NhanVien nv)
        {
            if (nv.MaNV <= 0)
                return "Mã nhân viên không hợp lệ!";

            string validationMessage = ValidateNhanVien(nv);
            if (validationMessage != "OK")
            {
                return validationMessage;
            }

            bool result = nhanVienDAL.UpdateNhanVien(nv);
            return result ? "Cập nhật nhân viên thành công!" : "Cập nhật thất bại!";
        }

        // 4. Xóa nhân viên
        public string DeleteNhanVien(int maNV)
        {
            if (maNV <= 0)
                return "Mã nhân viên không hợp lệ!";

            bool result = nhanVienDAL.DeleteNhanVien(maNV);
            return result ? "Xóa nhân viên thành công!" : "Xóa thất bại!";
        }

        // 5. Hàm kiểm tra dữ liệu đầu vào
        private string ValidateNhanVien(NhanVien nv)
        {
            if (string.IsNullOrWhiteSpace(nv.HoTen))
                return "Họ tên không được để trống!";

            if (!Regex.IsMatch(nv.SoDienThoai, @"^(0[1-9][0-9]{8})$"))
                return "Số điện thoại không hợp lệ!";

            if (!Regex.IsMatch(nv.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return "Email không hợp lệ!";

            if (nv.Luong < 0)
                return "Lương không thể âm!";

            return "OK"; // Dữ liệu hợp lệ
        }
    }
}
