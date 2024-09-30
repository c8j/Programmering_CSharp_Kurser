string path = Environment.CurrentDirectory + "/data/log.txt";
Console.WriteLine(path);


/* string message = "Info added " + DateTime.Now.ToShortDateString();

File.WriteAllText(path, message);

string text = File.ReadAllText(path);
Console.WriteLine(text); */

using StreamWriter sw = new(path);

string message = "Info added " + DateTime.Now;
sw.WriteLine(message);

message = "Info added again " + DateTime.Now;
sw.WriteLine(message);

sw.Close();

using StreamReader sr = new(path);

string text = sr.ReadToEnd();
Console.WriteLine(text);

sr.Close();
