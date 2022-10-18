using Common.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassBox.Mobile.Models
{
    public abstract class EncryptEntity : Entity
    {
        public string Name { get; set; }
    }
}