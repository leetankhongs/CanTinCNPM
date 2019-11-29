using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCanTin
{
    public class HoaDonInfo
    {
        private string maHoaDon;

        public string MaHoaDon
        {
            get { return maHoaDon; }
            set { maHoaDon = value; }
        }

        private string maSanPham;

        public string MaSanPham
        {
            get { return maSanPham; }
            set { maSanPham = value; }
        }

        private int sl;
        
        public int SL
        {
            get { return sl; }
            set { sl = value; }
        }

        public HoaDonInfo() { }

        public HoaDonInfo(string id, string productID, int count)
        {
            this.MaHoaDon = id;
            this.MaSanPham = productID;
            this.SL = count;
        }

        public HoaDonInfo(DataRow row)
        {
            this.MaHoaDon = row["MaHoaDon"].ToString();
            this.MaSanPham = row["MaSanPham"].ToString();
            this.SL = (int)row["SL"];
        }
    }
}
