using System;
using System.Reflection;
using System.IO;

public interface IPlug
{
    void Dosth();
}
class Program
{
    static void Main(string[] args)
    {
        var defaultAd = AppDomain.CurrentDomain;
        defaultAd.SetShadowCopyFiles();
        var path = Path.Combine(defaultAd.BaseDirectory, "LibLoad.dll");
        while (true)
        {
            var setup = new AppDomainSetup();
            setup.ShadowCopyFiles = "true";
            setup.ShadowCopyDirectories = defaultAd.BaseDirectory;
            var ad = AppDomain.CreateDomain("HotPlugAd", null, setup);
            
            var entryAssName = Assembly.GetEntryAssembly().FullName;
            var loader = (Loader)ad.CreateInstanceAndUnwrap(entryAssName, "Loader");
            loader.Work(path, "LibLoad.Plug");
            AppDomain.Unload(ad);
            Console.ReadKey();
        }
    }
}
public class Loader : MarshalByRefObject
{
    public void Work(string assemblyPath,string className)
    {
        if (string.IsNullOrEmpty(assemblyPath) || string.IsNullOrEmpty(className))
            return;
        var assembly = Assembly.LoadFrom(assemblyPath);

        var t = assembly.GetType(className);
        var instance = (IPlug)Activator.CreateInstance(t);
        if (instance != null)
            instance.Dosth();
    }
}
