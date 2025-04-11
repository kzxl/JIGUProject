using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services.Extension
{
    public static class ObjectExtension
    {
        public static int? _IntOrNull(this object value)
        {
            try
            {
                if (value == null || value.ToString().Trim() == "")
                {
                    return null;
                }
                else
                {
                    return Convert.ToInt32(value);
                }

            }
            catch (Exception)
            {
                return null;
            }
        }
        public static int _Int(this object value)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
