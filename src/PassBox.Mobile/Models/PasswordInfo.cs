using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PassBox.Mobile.Models
{
    public class PasswordInfo
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }

        public static PasswordInfo Create()
        {
            return new PasswordInfo { Id = DateTime.Now.Ticks };
        }
    }

    public static class PasswordInfoService
    {
        private static List<PasswordInfo> _passwordInfoList = new List<PasswordInfo>();
        public static IEnumerable<PasswordInfo> GetPasswordInfos()
        {
            if (_passwordInfoList.Count > 0)
            {
                foreach (var item in _passwordInfoList)
                    yield return item;
            }

            //yield return new PasswordInfo { Name = "Test", Data = "123" };
        }

        public static bool Update(PasswordInfo info)
        {
            var item = _passwordInfoList.First(x => x.Id == info.Id && x.Name == info.Name && x.Data == info.Data);
            item.Data = info.Data;
            item.Name = info.Name;
            return true;
        }

        public static bool Add(PasswordInfo info)
        {
            _passwordInfoList.Add(info);
            return true;
        }

        public static bool Remove(PasswordInfo info)
        {
            _passwordInfoList.RemoveAll(x => x.Id == info.Id && x.Name == info.Name && x.Data == info.Data);
            return true;
        }
    }
}
