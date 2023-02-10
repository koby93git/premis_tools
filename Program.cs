using System.Text.RegularExpressions;

string pvdb = "../../../pvu-app-pvdb.cfg";
string mainCFG = "../../../pvu-app.cfg";
string pss = "../../../pss-config.xml";

/*string path = System.Reflection.Assembly.GetEntryAssembly().Location;

System.Console.WriteLine(path);*/

System.Console.WriteLine("Script to fix CC errors, that CC can't fix itself");

try
{
    string [] rows = File.ReadAllLines(pss);

    int index = 0;

    foreach (var item in rows)
    {
        if (Regex.IsMatch(item, "(pvu-trdp-md-101)"))
        {
            System.Console.WriteLine("Found a match message 101 in pss");
            string tmp = Regex.Replace(item, "type=\"\\d*\"", "type=\"18\"");
            tmp = Regex.Replace(tmp, "dsId=\"\\d*\"", "dsId=\"101\"");
            System.Console.WriteLine(tmp);
            rows[index] = tmp;
        }

        if (Regex.IsMatch(item, "(pvu-trdp-md-105)"))
        {
            System.Console.WriteLine("Found a match message 105 in pss");
            string tmp = Regex.Replace(item, "type=\"\\d*\"", "type=\"18\"");
            tmp = Regex.Replace(tmp, "dsId=\"\\d*\"", "dsId=\"105\"");
            System.Console.WriteLine(tmp);
            rows[index] = tmp;
        }
        index++;
    }

    File.WriteAllLines(pss, rows);

    // another file

    string [] rows2 = File.ReadAllLines(pvdb);

    index = 0;

    foreach (var item in rows2)
    {
        if (Regex.IsMatch(item, "(pvu-trdp-md-101)"))
        {
            System.Console.WriteLine("Found a match message 101 in pvdb");
            string tmp = Regex.Replace(item, "type=\"\\d*\"", "type=\"18\"");
            tmp = Regex.Replace(tmp, "dsId=\"\\d*\"", "dsId=\"101\"");
            System.Console.WriteLine(tmp);
            rows2[index] = tmp;
        }

        if (Regex.IsMatch(item, "(pvu-trdp-md-105)"))
        {
            System.Console.WriteLine("Found a match message 105 in pvdb");
            string tmp = Regex.Replace(item, "type=\"\\d*\"", "type=\"18\"");
            tmp = Regex.Replace(tmp, "dsId=\"\\d*\"", "dsId=\"105\"");
            System.Console.WriteLine(tmp);
            rows2[index] = tmp;
        }
        index++;
    }

    File.WriteAllLines(pvdb, rows2);

    // another file

    string [] rows3 = File.ReadAllLines(mainCFG);

    index = 0;

    foreach (var item in rows3)
    {
        if (Regex.IsMatch(item, "(diag enable=\"no\")"))
        {
            System.Console.WriteLine("Found a match in main cfg file:");
            string tmp = Regex.Replace(item, "diag enable=\"no\"", "diag enable=\"yes\"");
            System.Console.WriteLine(tmp);
            rows3[index] = tmp;
        }
        index++;
    }

    File.WriteAllLines(mainCFG, rows3);
    System.Console.WriteLine("Don't forget to increase the cfg version in Consist Configurator");
}
catch(Exception e)
{
    System.Console.WriteLine("There has been some error: " + e.Message);
}

try{
    System.Console.ReadKey();
}
catch(Exception e)
{

}