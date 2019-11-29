using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuanLyCanTin
{
    public class SanPhamDAO
    {
        private static SanPhamDAO instance;

        public static SanPhamDAO Instance
        {
            get {
                if (instance == null)
                {
                    instance = new SanPhamDAO();
                }
                return SanPhamDAO.instance;
            }
            private set {
                SanPhamDAO.instance = value;
            }
        }

        private SanPhamDAO() { }

        public List<SanPham> GetListFood()
        {
            List<SanPham> list = new List<SanPham>();

            string query = "SELECT * FROM SanPham";

            DataTable data = DBConnect.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                SanPham sp = new SanPham(item);
                list.Add(sp);
            }

            MessageBox.Show("Get SANPHAM data successfully!!!");

            return list;
        }

        public List<SanPham> SearchFoodByName(string name)
        {
            List<SanPham> list = new List<SanPham>();

            //string query = string.Format("SELECT * FROM SanPham WHERE dbo.fuConvertToUnsign1(TenSanPham) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", name);

            //DataTable data = DBConnect.Instance.ExecuteQuery(query);

            //foreach (DataRow item in data.Rows)
            //{
            //    SanPham sp = new SanPham(item);
            //    list.Add(sp);
            //}

            return list;
        }

        public bool InsertFood(string id, string name, string categoryID, int price, string imgUrl, bool isFavourite, bool isDelete)
        {
            string query = string.Format("INSERT INTO SanPham (MaSanPham, TenSanPham, LoaiSanPham, ImgUrl, Gia, YeuThich, isDelete)VALUES({0}, N'{1}', {2}, {3}, {4}, {5}, {6})", id, name, categoryID, imgUrl, price, isFavourite, isDelete);
            int result = DBConnect.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateFood(string id, string name, string categoryID, int price, string imgUrl, bool isFavourite, bool isDelete)
        {
            string query = string.Format("UPDATE SanPham SET TenSanPham = N'{0}', LoaiSanPham = {1}, ImgUrl = {2}, Gia = {3}, YeuThich = {4}, isDelete = {5} WHERE MaSanPham = {6}", name, categoryID, imgUrl, price, isFavourite, isDelete, id);
            int result = DBConnect.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteFood(int id)
        {
            string query = string.Format("DELETE FROM SanPham WHERE MaSanPham = {0}", id);
            int result = DBConnect.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
