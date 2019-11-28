using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCanTin
{
    class NhanVienDAO
    {
        private static NhanVienDAO instance;

        public static NhanVienDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NhanVienDAO();
                }
                return NhanVienDAO.instance;
            }
            private set
            {
                NhanVienDAO.instance = value;
            }
        }

        private NhanVienDAO() { }

        public bool Login(string username, string password)
        {
            string query = "Login @username , @password";

            DataTable result = DBConnect.Instance.ExecuteQuery(query, new object[] { username, password });

            return result.Rows.Count > 0;
        }
    }
}
