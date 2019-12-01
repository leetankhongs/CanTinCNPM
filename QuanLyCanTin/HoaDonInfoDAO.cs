using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuanLyCanTin
{
    public class HoaDonInfoDAO
    {
        private static HoaDonInfoDAO instance;

        public static HoaDonInfoDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HoaDonInfoDAO();
                }
                return HoaDonInfoDAO.instance;
            }
            private set
            {
                HoaDonInfoDAO.instance = value;
            }
        }

        private HoaDonInfoDAO() { }

        public List<HoaDonInfo> GetListBillInfo()
        {
            List<HoaDonInfo> list = new List<HoaDonInfo>();

            string query = "SELECT * FROM ChiTietHoaDon";

            DataTable data = DBConnect.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                HoaDonInfo cthd = new HoaDonInfo(item);
                list.Add(cthd);
            }

            return list;
        }

        public bool InsertBillInfo(string id, List<string> productID, List<int> count)
        {
            int result = 0;
            for (int i = 0; i < productID.Count; i++)
            {
                string query = "EXEC insertBillInfo @id , @productID , @count";
                result = DBConnect.Instance.ExecuteNonQuery(query, new object[] { id, productID[i], count[i]});
            }

            return result > 0;
        }
    }
}
