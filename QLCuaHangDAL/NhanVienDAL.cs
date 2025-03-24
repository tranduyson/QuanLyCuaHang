using QLCuaHangDAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCuaHangDAL
{
    public class NhanVienDAL
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();

        // 1. Lấy danh sách nhân viên
        public List<NhanVien> GetAllNhanVien()
        {
            List<NhanVien> danhSachNhanVien = new List<NhanVien>();
            string query = "SELECT MaNV, HoTen, GioiTinh, DiaChi, SoDienThoai, Email, ChucVu, Luong, NgayVaoLam FROM NhanVien";
            DataTable dt = dbHelper.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                danhSachNhanVien.Add(new NhanVien
                {
                    MaNV = Convert.ToInt32(row["MaNV"]),
                    HoTen = row["HoTen"].ToString(),
                    GioiTinh = row["GioiTinh"].ToString(),
                    DiaChi = row["DiaChi"].ToString(),
                    SoDienThoai = row["SoDienThoai"].ToString(),
                    Email = row["Email"].ToString(),
                    ChucVu = row["ChucVu"].ToString(),
                    Luong = Convert.ToDecimal(row["Luong"]),
                    NgayVaoLam = Convert.ToDateTime(row["NgayVaoLam"])
                });
            }

            return danhSachNhanVien;
        }

        // 2. Thêm nhân viên
        public bool AddNhanVien(NhanVien nv)
        {
            string query = "INSERT INTO NhanVien (HoTen, GioiTinh, DiaChi, SoDienThoai, Email, ChucVu, Luong, NgayVaoLam) " +
                           "VALUES (@HoTen, @GioiTinh, @DiaChi, @SoDienThoai, @Email, @ChucVu, @Luong, @NgayVaoLam)";

            var parameters = new Dictionary<string, object>
            {
                {"@HoTen", nv.HoTen},
                {"@GioiTinh", nv.GioiTinh},
                {"@DiaChi", nv.DiaChi},
                {"@SoDienThoai", nv.SoDienThoai},
                {"@Email", nv.Email},
                {"@ChucVu", nv.ChucVu},
                {"@Luong", nv.Luong},
                {"@NgayVaoLam", nv.NgayVaoLam}
            };

            return dbHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        // 3. Cập nhật nhân viên
        public bool UpdateNhanVien(NhanVien nv)
        {
            string query = "UPDATE NhanVien SET HoTen=@HoTen, GioiTinh=@GioiTinh, DiaChi=@DiaChi, SoDienThoai=@SoDienThoai, " +
                           "Email=@Email, ChucVu=@ChucVu, Luong=@Luong, NgayVaoLam=@NgayVaoLam WHERE MaNV=@MaNV";

            var parameters = new Dictionary<string, object>
            {
                {"@MaNV", nv.MaNV},
                {"@HoTen", nv.HoTen},
                {"@GioiTinh", nv.GioiTinh},
                {"@DiaChi", nv.DiaChi},
                {"@SoDienThoai", nv.SoDienThoai},
                {"@Email", nv.Email},
                {"@ChucVu", nv.ChucVu},
                {"@Luong", nv.Luong},
                {"@NgayVaoLam", nv.NgayVaoLam}
            };

            return dbHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        // 4. Xóa nhân viên
        public bool DeleteNhanVien(int maNV)
        {
            string query = "DELETE FROM NhanVien WHERE MaNV=@MaNV";
            var parameters = new Dictionary<string, object> { { "@MaNV", maNV } };

            return dbHelper.ExecuteNonQuery(query, parameters) > 0;
        }
    }
}
