using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCanTin
{
    public class NhanVien
    {
        private string maNV;

        public string MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }

        private string hoTen;

        public string HoTen
        {
            get { return HoTen; }
            set { HoTen = value; }
        }

        private string sdt;

        public string SDT
        {
            get { return sdt; }
            set { sdt = value; }
        }

        private string diaChi;

        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }

        private int luong;

        public int Luong
        {
            get { return luong; }
            set { luong = value; }
        }

        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public NhanVien() { }

        public NhanVien(string id, string name, string phoneNum, string address, int salary, string username, string password)
        {
            this.MaNV = id;
            this.HoTen = name;
            this.SDT = phoneNum;
            this.DiaChi = address;
            this.Luong = salary;
            this.Username = username;
            this.Password = password;
        }

        public NhanVien(DataRow row)
        {
            this.MaNV = row["MaNV"].ToString();
            this.HoTen = row["HoTen"].ToString();
            this.SDT = row["SDT"].ToString();
            this.DiaChi = row["DiaChi"].ToString();
            this.Luong = (int)row["Luong"];
            this.Username = row["Username"].ToString();
            this.Password = row["Password"].ToString();
        }
    }
}
