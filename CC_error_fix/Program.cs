

using System.Text.RegularExpressions;

class Program
{    
    static void Main(string[] args)
    {
        try
        {
            Function fnc = new Function();
            string path = fnc.GetLaunchPath(); 
            //System.Console.WriteLine(path);
            string pvdb = path + "pvu-app-pvdb.cfg";
            string mainCFG = path + "pvu-app.cfg";
            string pss = path + "pss-config.xml";

            System.Console.WriteLine("Script to fix CC errors, that CC can't fix itself");
            System.Console.WriteLine();

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