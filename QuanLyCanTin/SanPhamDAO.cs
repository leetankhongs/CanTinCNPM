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

            return list;
        }
    }
}
