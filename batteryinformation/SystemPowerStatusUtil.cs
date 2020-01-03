using System;

namespace batteryinformation
{
    public static class SystemPowerStatusUtil
    {
        public static string ToString(SYSTEM_POWER_STATUS sps)
        {
            return
                $"ACLineStatus = {sps.ACLineStatus}({AcLineStatusToString(sps.ACLineStatus)})\n"  //AC電源の状態
                + $"BatteryFlag = {sps.BatteryFlag}({BatteryFlagToString(sps.BatteryFlag)})\n"   //バッテリーの充電状態
                + $"BatteryLifePercent = {sps.BatteryLifePercent}({BatteryLifePercentToString(sps.BatteryLifePercent)})\n"  //バッテリー残量（%）
                + $"BatteryLifeTime = {sps.BatteryLifeTime}({BatteryLifeTimeToString(sps.BatteryLifeTime)})\n"   //バッテリー残量（時間）
                + $"BatteryFullLifeTime = {sps.BatteryFullLifeTime}({BatteryFullLifeTimeToString(sps.BatteryFullLifeTime)})";  //バッテリーがフル充電された時の持ち時間（バッテリー駆動時間）
        }
        static string AcLineStatusToString(byte acLineStatus)
        {
            switch (acLineStatus)
            {
                case 0:
                    return "offline";
                case 1:
                    return "online";
                case 255:
                    return "unknown";
                default:
                    throw new SystemException(acLineStatus.ToString());
            }
        }

        static string ChargedLevelToString(int chargedLevel)
        {
            switch (chargedLevel)
            {
                case 1:
                    return ">=66%";
                case 2:
                    return "<33%";
                case 4:
                    return "<5%";
                default:
                    throw new SystemException("unknown charged level " + chargedLevel);
            }
        }

        static string ChargingFlagToString(int chargingFlag)
        {
            return (chargingFlag != 0) ? "charging" : "not charging";
        }

        static string BatteryFlagToString(byte batteryFlag)
        {
            if (batteryFlag == 255)
                return "unknown";
            if ((batteryFlag & 128) != 0)
                return "no system battery";
            var chargedLevel = batteryFlag & 7;
            var chargingFlag = batteryFlag & 8;
            return $"Charged level={chargedLevel}({ChargedLevelToString(chargedLevel)}), "
                + $"charging flag={chargingFlag}({ChargingFlagToString(chargingFlag)})";
        }

        static string BatteryLifePercentToString(byte batteryLifePercent)
        {
            if (batteryLifePercent == 255)
                return "unknown";
            return $"{batteryLifePercent} %";
        }

        static string BatteryLifeTimeToString(int batteryLifeTime)
        {
            if (batteryLifeTime < 0)
                return "unknown";
            return $"{batteryLifeTime} sec";
        }
        static string BatteryFullLifeTimeToString(int batteryFullLifeTime)
        {
            if (batteryFullLifeTime < 0)
                return "unknown";
            return $"{batteryFullLifeTime} sec";
        }
    }
}
