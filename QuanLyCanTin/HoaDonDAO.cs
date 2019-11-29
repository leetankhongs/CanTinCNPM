using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuanLyCanTin
{
    public class HoaDonDAO
    {
        private static HoaDonDAO instance;

        public static HoaDonDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HoaDonDAO();
                }
                return HoaDonDAO.instance;
            }
            private set
            {
                HoaDonDAO.instance = value;
            }
        }

        private HoaDonDAO() { }

        public List<HoaDon> GetListBill()
        {
            List<HoaDon> list = new List<HoaDon>();

            string query = "SELECT * FROM HoaDon";

            DataTable data = DBConnect.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                HoaDon hd = new HoaDon(item);
                list.Add(hd);
            }

            MessageBox.Show("Get HOADON data successfully!!!");

            return list;
        }

        public bool InsertBill(string id, int stt, DateTime dateTime, int totalCost, string accountID)
        {
            string query = "EXEC insertBill @id , @stt , @dateTime , @totalCost , @accountID";
            int result = DBConnect.Instance.ExecuteNonQuery(query, new object[]{ id, stt, dateTime, totalCost, accountID });

            return result > 0;
        }

        public string getNextID()
        {
            string query = "SELECT 'HD' + REPLICATE('0', 6 - LEN(CAST(MAX(STT) + 1 AS char))) + CAST(MAX(STT) + 1 AS char) FROM HoaDon";
            string result = (string)DBConnect.Instance.ExecuteScalar(query);

            return result;
        }

        public int getNextSTT()
        {
            string query = "SELECT MAX(STT) + 1 FROM HoaDon";
            int result = (int)DBConnect.Instance.ExecuteScalar(query);

            return result;
        }
    }
}
