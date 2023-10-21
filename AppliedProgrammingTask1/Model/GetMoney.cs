using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AppliedProgrammingTask1.Models
{
    public class GetMoney
    {
        public string id { get; set; }
        public string date { get; set; }
        public double totalDonation { get; set; }
        public string status { get; set; }
    }
}
