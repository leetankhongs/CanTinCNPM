using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCanTin
{
    public class NhanVienDAO
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
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] hashData = new MD5CryptoServiceProvider().ComputeHash(temp);

            string hashPass = "";

            foreach (byte item in hashData)
            {
                hashPass += item;
            }

            string query = "Login @username , @password";

            DataTable result = DBConnect.Instance.ExecuteQuery(query, new object[] { username, hashPass });

            return result.Rows.Count > 0;
        }
		
        public string getAccountIDByUsername(string username)
        {
            string query = "getAccountIDByUsername @username";

            string result = (string)DBConnect.Instance.ExecuteScalar(query, new object[] { username });

            return result;
        }
    }
}
