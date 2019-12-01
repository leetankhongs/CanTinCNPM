using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCanTin
{
    public class HoaDon
    {
        private string maHoaDon;

        public string MaHoaDon
        {
            get { return maHoaDon; }
            set { maHoaDon = value; }
        }

        private int stt;

        public int STT
        {
            get { return stt; }
            set { stt = value; }
        }

        private DateTime thoiGian;
        
        public DateTime ThoiGian
        {
            get { return thoiGian; }
            set { thoiGian = value; }
        }

        private int tongTien;

        public int TongTien
        {
            get { return tongTien; }
            set { tongTien = value; }
        }

        private string nhanVien;

        public string NhanVien
        {
            get { return nhanVien; }
            set { nhanVien = value; }
        }

        public HoaDon() { }

        public HoaDon(string id, int stt, DateTime dateTime, int totalCost, string accountID)
        {
            this.MaHoaDon = id;
            this.STT = stt;
            this.ThoiGian = dateTime;
            this.TongTien = totalCost;
            this.NhanVien = accountID;
        }

        public HoaDon(DataRow row)
        {
            this.MaHoaDon = row["MaHoaDon"].ToString();
            this.STT = (int)row["STT"];
            this.ThoiGian = (DateTime)row["ThoiGian"];
            this.TongTien = (int)row["TongTien"];
            this.NhanVien = row["NhanVien"].ToString();
        }
    }
}
