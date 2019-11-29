using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuanLyCanTin
{
    public class ComBoDAO
    {
        private static ComBoDAO instance;

        public static ComBoDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ComBoDAO();
                }
                return ComBoDAO.instance;
            }
            private set
            {
                ComBoDAO.instance = value;
            }
        }

        private ComBoDAO() { }

        public List<ComBo> GetListComBo()
        {
            List<ComBo> list = new List<ComBo>();

            string query = "SELECT * FROM ComBo";

            DataTable data = DBConnect.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                ComBo combo = new ComBo(item);
                list.Add(combo);
            }

            MessageBox.Show("Get COMBO data successfully!!!");

            return list;
        }
    }
}
