List<string> lines = new List<string>();

lines.Add("Line 1");
lines.Add("Line 2");

//Take a list of text lines and write them into a file.
File.WriteAllLines("sample.txt", lines);