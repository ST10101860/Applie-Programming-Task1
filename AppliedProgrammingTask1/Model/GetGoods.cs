using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AppliedProgrammingTask1.Models
{
    public class GetGoods
    {
        public string Id { get; set; }
        public string date { get; set; }
        public int totalItem { get; set; }
        public string goodsSelection { get; set; }
        public string otherGoods { get; set; }
        public string goodDescription { get; set; }
        public string status { get; set; }
    }
}
