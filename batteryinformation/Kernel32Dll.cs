using System.Runtime.InteropServices;

namespace batteryinformation
{
    class Kernel32Dll
    {
        [DllImport("kernel32.dll")]
        public static extern bool GetSystemPowerStatus(
            out SYSTEM_POWER_STATUS lpSystemPowerStatus);
    }
}
