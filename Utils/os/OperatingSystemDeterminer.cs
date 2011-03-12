using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils.os
{
    public class OperatingSystemDeterminer
    {
        public static bool Is2000Version()
        {
            OperatingSystem os = Environment.OSVersion;
            return Is2000Version(os);
        }
        public static bool Is2000Version(OperatingSystem os)
        {
            return os.Platform.Equals(PlatformID.Win32NT) && os.Version.Major == 5 && os.Version.Minor == 0;
        }

        public static bool IsXpVersion()
        {
            OperatingSystem os = Environment.OSVersion;
            return IsXpVersion(os);
        }

        public static bool IsXpVersion(OperatingSystem os)
        {
            return os.Platform.Equals(PlatformID.Win32NT) && os.Version.Major == 5 && os.Version.Minor == 1;
        }

        public static bool IsVistaVersion()
        {
            OperatingSystem os = Environment.OSVersion;
            return IsVistaVersion(os);
        }
        public static bool IsVistaVersion(OperatingSystem os)
        {
            return os.Platform.Equals(PlatformID.Win32NT) && os.Version.Major == 6 && os.Version.Minor == 0;
        }

        public static bool Is7Version()
        {
            OperatingSystem os = Environment.OSVersion;
            return Is7Version(os);
        }
        public static bool Is7Version(OperatingSystem os)
        {
            return os.Platform.Equals(PlatformID.Win32NT) && os.Version.Major == 6 && os.Version.Minor == 1;
        }
    }
}
