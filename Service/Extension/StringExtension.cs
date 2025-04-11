using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services.Extension
{
    public static class StringExtension
    {
        public static bool IsNumber(this string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
        public static bool checkCOMExits(this string PortName)
        {
            try
            {
                if (SerialPort.GetPortNames().Any(x => x == PortName))
                    return true;
                else
                    return false;
            }
            catch (Exception) { return false; }
        }
    }
}
