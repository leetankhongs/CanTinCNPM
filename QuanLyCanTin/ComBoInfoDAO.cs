using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuanLyCanTin
{
    class ComBoInfoDAO
    {
        private static ComBoInfoDAO instance;

        public static ComBoInfoDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ComBoInfoDAO();
                }
                return ComBoInfoDAO.instance;
            }
            private set
            {
                ComBoInfoDAO.instance = value;
            }
        }

        private ComBoInfoDAO() { }

        public List<ComBoInfo> GetListComBoInfo()
        {
            List<ComBoInfo> list = new List<ComBoInfo>();

            string query = "SELECT * FROM ChiTietComBo";

            DataTable data = DBConnect.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                ComBoInfo comboInfo = new ComBoInfo(item);
                list.Add(comboInfo);
            }

            MessageBox.Show("Get COMBO INFO data successfully!!!");

            return list;
        }
    }
}
