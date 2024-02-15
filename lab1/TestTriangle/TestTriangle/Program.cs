using System;
using System.IO;

class TestTriangle
{
    static string RunTestCase(string input, string expectedOutput)
    {
        double a;
        double b;
        double c;
        string[] inputArgs;
        try
        {
            inputArgs = input.Split();
            if (inputArgs.Length < 3)
            {
                return "Неизвестная ошибка";
            }
            if ((inputArgs[0] == "Неверное" && inputArgs[1] == "количество" && inputArgs[2] == "аргументов")
                || (inputArgs[1] == "Неверное" && inputArgs[2] == "количество" && inputArgs[3] == "аргументов")
                || (inputArgs[2] == "Неверное" && inputArgs[3] == "количество" && inputArgs[4] == "аргументов"))
            {
                return "success";
            }

            a = double.Parse(inputArgs[0]);
            b = double.Parse(inputArgs[1]);
            c = double.Parse(inputArgs[2]);
        }
        catch
        {
            return "error";
        }

        using (var process = new System.Diagnostics.Process())
        {
            process.StartInfo.FileName = "Triangle.exe";
            process.StartInfo.Arguments = $"{a} {b} {c}";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            string output = process.StandardOutput.ReadToEnd().Trim();

            process.WaitForExit();

            return output == expectedOutput ? "success" : "error";
        }
    }

    static void Main()
    {
        string[] testCases = File.ReadAllLines("test_cases.txt");
        using (StreamWriter sw = new StreamWriter("results.txt"))
        {
            foreach (string testCase in testCases)
            {
                string[] parts = testCase.Split();

                string input = $"{parts[0]} {parts[1]} {parts[2]}";
                if (parts.Length == 3)
                {
                    if (parts[0] == "Неверное" && parts[1] == "количество" && parts[3] == "аргументов")
                    {
                        sw.WriteLine("success");
                        continue;
                    }
                    if ((parts[0] == "Неизвестная" && parts[1] == "ошибка") || (parts[1] == "Неизвестная" && parts[2] == "ошибка"))
                    {
                        sw.WriteLine("succes");
                        continue;
                    }
                    sw.WriteLine("error");
                    continue;
                }
                string expectedOutput = parts[3];
                if (parts.Length == 5)
                {
                    expectedOutput += " " + parts[4];
                }

                sw.WriteLine(RunTestCase(input, expectedOutput));
            }
        }
    }
}
