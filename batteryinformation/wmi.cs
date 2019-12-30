using System;

namespace batteryinformation
{
    class wmi
    {
        public static void test()
        {
            //ManagementClassオブジェクトを作成する
            System.Management.ManagementClass mc =
                new System.Management.ManagementClass("Win32_Battery");
            //ManagementObjectCollectionオブジェクトを取得する
            System.Management.ManagementObjectCollection moc = mc.GetInstances();
            foreach (System.Management.ManagementObject mo in moc)
            {
                //バッテリーの情報を表示する
                //（ここで紹介しているのは、取得できる情報の一部です）
                //（すべての情報が必ず取得できるわけではありません）
                Console.WriteLine("名前:{0}", mo["Name"]);
                Console.WriteLine("デバイスID:{0}", mo["DeviceID"]);
                Console.WriteLine("説明:{0}", mo["Description"]);
                Console.WriteLine("バッテリー残量:{0}%", mo["EstimatedChargeRemaining"]);
                Console.WriteLine("バッテリー残り時間:{0}分", mo["EstimatedRunTime"]);
                Console.WriteLine("設計容量:{0}mWh", mo["DesignCapacity"]);
                Console.WriteLine("設計電圧:{0}mV", mo["DesignVoltage"]);
                Console.WriteLine("フル充電容量:{0}mVh", mo["FullChargeCapacity"]);
                Console.WriteLine("フル充電までにかかる時間:{0}分", mo["TimeToFullCharge"]);
                Console.WriteLine("0からフル充電までにかかる時間:{0}分", mo["MaxRechargeTime"]);
                Console.WriteLine("バッテリー使用時間:{0}秒", mo["TimeOnBattery"]);

                Console.Write("バッテリーの状態:");
                switch ((UInt16)mo["BatteryStatus"])
                {
                    case 1:
                        Console.WriteLine("放電中");
                        break;
                    case 2:
                        Console.WriteLine("AC電源");
                        break;
                    case 3:
                        Console.WriteLine("充電完了");
                        break;
                    case 4:
                        Console.WriteLine("低");
                        break;
                    case 5:
                        Console.WriteLine("最低");
                        break;
                    case 6:
                        Console.WriteLine("充電中");
                        break;
                    case 7:
                        Console.WriteLine("充電中/高");
                        break;
                    case 8:
                        Console.WriteLine("充電中/低");
                        break;
                    case 9:
                        Console.WriteLine("充電中/最低");
                        break;
                    case 10:
                        Console.WriteLine("未定義");
                        break;
                    case 11:
                        Console.WriteLine("一部充電");
                        break;
                }

                Console.Write("バッテリーの種類:");
                switch ((UInt16)mo["Chemistry"])
                {
                    case 1:
                        Console.WriteLine("その他");
                        break;
                    case 2:
                        Console.WriteLine("不明");
                        break;
                    case 3:
                        Console.WriteLine("鉛蓄電池（鉛酸バッテリー）");
                        break;
                    case 4:
                        Console.WriteLine("ニッケル・カドミウム蓄電池(Ni-Cd)");
                        break;
                    case 5:
                        Console.WriteLine("ニッケル・水素充電池(Ni-MH)");
                        break;
                    case 6:
                        Console.WriteLine("リチウムイオン電池(LiB)");
                        break;
                    case 7:
                        Console.WriteLine("空気亜鉛電池");
                        break;
                    case 8:
                        Console.WriteLine("リチウムポリマー電池(Lipo)");
                        break;
                }
            }

            //後始末
            moc.Dispose();
            mc.Dispose();
        }
    }
}
