using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCanTin
{
    public class SanPham
    {
        private int gia;

        public int Gia
        {
            get { return gia; }
            set { gia = value; }
        }

        private string loaiSanPham;

        public string LoaiSanPham
        {
            get { return loaiSanPham; }
            set { loaiSanPham = value; }
        }

        private string tenSanPham;

        public string TenSanPham
        {
            get { return tenSanPham; }
            set { tenSanPham = value; }
        }

        private string imgUrl;

        public string ImgUrl
        {
            get { return imgUrl; }
            set { imgUrl = value; }
        }

        private bool yeuThich;

        public bool YeuThich
        {
            get { return yeuThich; }
            set { yeuThich = value; }
        }

        private bool isDelete;

        public bool IsDelete
        {
            get { return isDelete; }
            set { isDelete = value; }
        }

        private string maSanPham;

        public string MaSanPham
        {
            get { return maSanPham; }
            set { maSanPham = value; }
        }

        public SanPham() { }

        public SanPham(string id, string name, string categoryID, int price, string imgUrl, bool isFavourite, bool isDelete)
        {
            this.MaSanPham = id;
            this.TenSanPham = name;
            this.LoaiSanPham = categoryID;
            this.Gia = price;
            this.ImgUrl = imgUrl;
            this.YeuThich = isFavourite;
            this.IsDelete = isDelete;
        }

        public SanPham(DataRow row)
        {
            this.MaSanPham = row["MaSanPham"].ToString();
            this.TenSanPham = row["TenSanPham"].ToString();
            this.LoaiSanPham = row["LoaiSanPham"].ToString();
            this.Gia = (int)row["Gia"];
            this.ImgUrl = row["ImgUrl"].ToString();
            this.YeuThich = (bool)row["YeuThich"];
            this.IsDelete = (bool)row["isDelete"];
        }
    }
}
