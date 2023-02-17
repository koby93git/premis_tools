
using System;
using System.Text.RegularExpressions;

class Program
{    
    static void Main(string[] args)
    {
        try
        {
            System.Console.WriteLine("Script to fix CC errors, that CC can't fix itself");
            System.Console.WriteLine();

            Function fnc = new Function();
            string path = fnc.GetLaunchPath(); 
            //System.Console.WriteLine(path);
            string pvdb = path + "pvu-app-pvdb.cfg";
            string mainCFG = path + "pvu-app.cfg";
            string pss = path + "pss-config.xml";
            if(File.Exists(pvdb) && File.Exists(mainCFG) && File.Exists(pss))
            {
                fnc.PSSCorrection(pss);
                fnc.PVDBCorrection(pvdb);
                fnc.MainCFGCorrection(mainCFG);
                        
                System.Console.WriteLine("Success, don't forget to increase the cfg version in Consist Configurator");
                System.Console.ReadKey();
            }
            else
            {
                while(!(File.Exists(pvdb) && File.Exists(mainCFG) && File.Exists(pss)))
                {
                    System.Console.Write("Files not found, enter path to files or * to exit: ");
                    path = System.Console.ReadLine();
                    if(String.Equals(path, "*"))
                    {
                        System.Environment.Exit(0);
                    }
                    else 
                    {
                        System.Console.WriteLine();
                        pvdb = path + "pvu-app-pvdb.cfg";
                        mainCFG = path + "pvu-app.cfg";
                        pss = path + "pss-config.xml";
                    }
                }
                fnc.PSSCorrection(pss);
                fnc.PVDBCorrection(pvdb);
                fnc.MainCFGCorrection(mainCFG);
                        
                System.Console.WriteLine("Success, don't forget to increase the cfg version in Consist Configurator");
                System.Console.ReadKey();
            }            
        }
        catch(Exception e)
        {
            System.Console.WriteLine("There has been some error: " + e.Message);
        }
    }  
}