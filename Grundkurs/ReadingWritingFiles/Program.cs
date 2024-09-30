string path = Environment.CurrentDirectory + "/data/log.txt";
Console.WriteLine(path);


string message = "Info added " + DateTime.Now.ToShortDateString();

File.WriteAllText(path, message);

string text = File.ReadAllText(path);
Console.WriteLine(text);
