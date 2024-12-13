using System.Reflection;

public static class AppVersion
{
    //public static string Version => Assembly.GetExecutingAssembly().GetName().Version.ToString();
    public static string Version => "1.2.1";
    public static string BuildDate => "13/12/2024"; // İsterseniz burada derleme tarihini de dinamik hesaplayabilirsiniz.
    public static string FullVersion => $"Version {Version} (Built on {BuildDate})";
}
