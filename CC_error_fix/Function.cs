using System.Runtime.InteropServices;
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
                    rows[index] = tmp;

                    Match match1 = Regex.Match(tmp, "type=\"\\d*\"");
                    Match match2 = Regex.Match(tmp, "dsId=\"\\d*\"");
                    Match[] matches = {match1, match2};
                    PrintLine(tmp, matches);                    
                }

                if (Regex.IsMatch(item, "(pvu-trdp-md-105)"))
                {
                    System.Console.WriteLine("Found a match message 105 in pss");
                    string tmp = Regex.Replace(item, "type=\"\\d*\"", "type=\"18\"");
                    tmp = Regex.Replace(tmp, "dsId=\"\\d*\"", "dsId=\"105\"");
                    rows[index] = tmp;

                    Match match1 = Regex.Match(tmp, "type=\"\\d*\"");
                    Match match2 = Regex.Match(tmp, "dsId=\"\\d*\"");
                    Match[] matches = {match1, match2};
                    PrintLine(tmp, matches);  
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
            string [] rows = File.ReadAllLines(pvdb);
            int index = 0;

            foreach (var item in rows)
            {
                if (Regex.IsMatch(item, "(pvu-trdp-md-101)"))
                {
                    System.Console.WriteLine("Found a match message 101 in pvdb");
                    string tmp = Regex.Replace(item, "type=\"\\d*\"", "type=\"18\"");
                    tmp = Regex.Replace(tmp, "dsId=\"\\d*\"", "dsId=\"101\"");
                    rows[index] = tmp;

                    Match match1 = Regex.Match(tmp, "type=\"\\d*\"");
                    Match match2 = Regex.Match(tmp, "dsId=\"\\d*\"");
                    Match[] matches = {match1, match2};
                    PrintLine(tmp, matches);  
                }

                if (Regex.IsMatch(item, "(pvu-trdp-md-105)"))
                {
                    System.Console.WriteLine("Found a match message 105 in pvdb");
                    string tmp = Regex.Replace(item, "type=\"\\d*\"", "type=\"18\"");
                    tmp = Regex.Replace(tmp, "dsId=\"\\d*\"", "dsId=\"105\"");
                    rows[index] = tmp;

                    Match match1 = Regex.Match(tmp, "type=\"\\d*\"");
                    Match match2 = Regex.Match(tmp, "dsId=\"\\d*\"");
                    Match[] matches = {match1, match2};
                    PrintLine(tmp, matches);  
                }
                index++;
            }

            File.WriteAllLines(pvdb, rows);
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
            string [] rows = File.ReadAllLines(mainCFG);
            int index = 0;

            foreach (var item in rows)
            {
                if (Regex.IsMatch(item, "(diag enable=\"no\")"))
                {
                    System.Console.WriteLine("Found a match in main cfg file:");
                    string tmp = Regex.Replace(item, "diag enable=\"no\"", "diag enable=\"yes\"");
                    rows[index] = tmp;

                    Match match1 = Regex.Match(tmp, "diag enable=\"yes\"");
                    Match[] matches = {match1};
                    PrintLine(tmp, matches);
                }
                index++;
            }

            File.WriteAllLines(mainCFG, rows);
        }
        catch(Exception e)
        {
            System.Console.WriteLine("There has been some error: " + e.Message);
        }
    }

    public string GetLaunchPath()
    {
        [DllImport("kernel32.dll", SetLastError = true, EntryPoint = "GetStartupInfoA")]
        static extern void GetStartupInfo(out STARTUPINFO lpStartupInfo);     

        STARTUPINFO info;
        GetStartupInfo(out info);
        string title = info.lpTitle;
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

    private void WriteColour(string line)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        System.Console.Write(line);
        Console.ResetColor();
    }

    private void SortMatches(Match[] matches)
    {
        int length = matches.Length;
        for(int i = 0; i < length - 1 ; i++)
        {
            for(int j = 0; j < length - i - 1; j++)
            {
                if(matches[j].Index > matches[j + 1].Index)
                {
                    Match tmp = matches[j];
                    matches[j] = matches[j + 1];
                    matches[j + 1] = tmp;
                }
            }
        }
    }

    private void PrintLine(string tmp, Match[] matches)
    {
        SortMatches(matches);
        System.Console.Write(tmp.Substring(0,matches[0].Index));
        int i = 0;
        for (; i < matches.Length - 1; i++)
        {
            WriteColour(tmp.Substring(matches[i].Index, matches[i].Length));
            System.Console.Write(tmp.Substring(matches[i].Index + matches[i].Length, matches[i + 1].Index - (matches[i].Index + matches[i].Length)));
        }                    
        WriteColour(tmp.Substring(matches[i].Index, matches[i].Length));
        System.Console.WriteLine(tmp.Substring(matches[i].Index + matches[i].Length));
        System.Console.WriteLine();
    }
}