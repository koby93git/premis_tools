
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

class Program
{    
    static void Main(string[] args)
    {
        try
        {
            [DllImport("kernel32.dll", SetLastError = true, EntryPoint = "GetStartupInfoA")]
            static extern void GetStartupInfo(out STARTUPINFO lpStartupInfo);

            Function fnc = new Function();

            STARTUPINFO info;
            GetStartupInfo(out info);
            string path = fnc.GetPath(info.lpTitle); 
            //System.Console.WriteLine(path);
            string pvdb = path + "pvu-app-pvdb.cfg";
            string mainCFG = path + "pvu-app.cfg";
            string pss = path + "pss-config.xml";

            System.Console.WriteLine("Script to fix CC errors, that CC can't fix itself");

            fnc.PSSCorrection(pss);
            fnc.PVDBCorrection(pvdb);
            fnc.MainCFGCorrection(mainCFG);
                        
            System.Console.WriteLine("Don't forget to increase the cfg version in Consist Configurator");
            System.Console.ReadKey();
        }
        catch(Exception e)
        {
            System.Console.WriteLine("There has been some error: " + e.Message);
        }
    }  
}