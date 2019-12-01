using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCanTin
{
    class ComBoInfo
    {
        private string maComBo;

        public string MaComBo
        {
            get { return maComBo; }
            set { maComBo = value; }
        }

        private string maSanPham;

        public string MaSanPham
        {
            get { return maSanPham; }
            set { maSanPham = value; }
        }

        public ComBoInfo() { }

        public ComBoInfo(string idComBo, string idProduct)
        {
            this.MaComBo = idComBo;
            this.MaSanPham = idProduct;
        }

        public ComBoInfo(DataRow row)
        {
            this.MaComBo = row["MaComBo"].ToString();
            this.MaSanPham = row["MaSanPham"].ToString();
        }
    }
}
