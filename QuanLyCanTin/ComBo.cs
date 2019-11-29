using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCanTin
{
    public class ComBo
    {
        private int giaComBo;

        public int GiaComBo
        {
            get { return giaComBo; }
            set { giaComBo = value; }
        }

        private string tenComBo;

        public string TenComBo
        {
            get { return tenComBo; }
            set { tenComBo = value; }
        }

        private string maComBo;

        public string MaComBo
        {
            get { return maComBo; }
            set { maComBo = value; }
        }

        public ComBo() { }

        public ComBo(string id, string name, int price)
        {
            this.MaComBo = id;
            this.TenComBo = name;
            this.GiaComBo = price;
        }

        public ComBo(DataRow row)
        {
            this.MaComBo = row["MaComBo"].ToString();
            this.TenComBo = row["TenComBo"].ToString();
            this.GiaComBo = (int)row["GiaComBo"];
        }
    }
}
