using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;

namespace ClipBoardAggregator
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder textBuilder = new StringBuilder();
            while (true)
            {
                

                var selectedText = Console.ReadLine();
                switch (selectedText)
                {
                    case "cl":
                        textBuilder = new StringBuilder();
                        Clipboard.Clear();
                        break;
                    case "co":
                        Console.WriteLine("Copied to Clipboard:");
                        Clipboard.SetText(textBuilder.ToString());
                        Console.WriteLine(textBuilder.ToString());
                        break;
                    case "en":
                        return;
                    default:
                        break;
                }
                textBuilder.Append($"{GetMeText()}, ");
            }
        }

        static string GetMeText()
        {
            string textCopied = String.Empty;
            Thread staThread = new Thread(x =>
            {
                try
                {
                    textCopied = Clipboard.GetText();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            });
            staThread.SetApartmentState(ApartmentState.STA);
            staThread.Start();
            staThread.Join();
            return textCopied;
        }



    }
}
