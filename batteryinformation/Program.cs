using System;

namespace batteryinformation
{
    class Program
    {
        static void Main(string[] args)
        {
            //システムの電源状態を取得する
            Kernel32Dll.GetSystemPowerStatus(out var sps);
            Console.WriteLine(SystemPowerStatusUtil.ToString(sps));
            Console.ReadLine();
        }
    }
}
