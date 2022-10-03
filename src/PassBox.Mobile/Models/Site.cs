using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace PassBox.Mobile.Models
{
    public class Site : EncryptEntity
    {
        public string Address { get; set; }
        public List<Account> Accounts { get; set; }
    }
}
