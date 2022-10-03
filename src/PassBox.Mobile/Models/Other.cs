using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassBox.Mobile.Models
{
    public class Other : EncryptEntity
    {
        public List<Account> Accounts { get; set; }
    }
}
