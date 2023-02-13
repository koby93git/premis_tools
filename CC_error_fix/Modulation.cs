using System.Text.RegularExpressions;

class Function
{

    public void PSSCorrection(string pss)
    {
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
        }
        catch(Exception e)
        {
            System.Console.WriteLine("There has been some error: " + e.Message);
        }
    }

    public void PVDBCorrection(string pvdb)
    {
        try
        {
            string [] rows2 = File.ReadAllLines(pvdb);

            int index = 0;

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
        }
        catch(Exception e)
        {
            System.Console.WriteLine("There has been some error: " + e.Message);
        }
    }

    public void MainCFGCorrection(string mainCFG)
    {
        try
        {
            string [] rows3 = File.ReadAllLines(mainCFG);

            int index = 0;

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
        }
        catch(Exception e)
        {
            System.Console.WriteLine("There has been some error: " + e.Message);
        }
    }

    public string GetPath(string title)
    {
        int counter = title.Length - 1;
        while(true)
        {
            if(title[counter].Equals('\\'))
            {
                break;
            }
            counter--;
        }
        string path = title.Substring(0,counter + 1);
        return path;
    }
}