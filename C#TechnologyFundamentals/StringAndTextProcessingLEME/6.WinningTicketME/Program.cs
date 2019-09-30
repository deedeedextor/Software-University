using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _6.WinningTicketME
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] tickets = input.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            StringBuilder sb = new StringBuilder();

            Regex pattern = new Regex(@"\@{6,}|\${6,}|\#{6,}|\^{6,}");

            foreach (var ticket in tickets)
            {
                if (ticket.Length != 20)
                {
                    sb.Append($"invalid ticket{Environment.NewLine}");
                }
                else
                {
                    Match leftSide = pattern.Match(ticket.Substring(0, 10));
                    Match rightSide = pattern.Match(ticket.Substring(10));
                    int minLength = Math.Min(leftSide.Length, rightSide.Length);

                    if (!leftSide.Success || !rightSide.Success)
                    {
                        sb.Append($"ticket \"{ticket}\" - no match{Environment.NewLine}");
                    }
                    else
                    {
                        string leftPart = leftSide.Value.Substring(0, minLength);
                        string rightPart = rightSide.Value.Substring(0, minLength);

                        if (leftPart.Equals(rightPart))
                        {
                            if (leftPart.Length == 10)
                            {
                                sb.Append($"ticket \"{ ticket}\" - {minLength}{leftPart.Substring(0, 1)} Jackpot!{Environment.NewLine}");
                            }
                            else
                            {
                                sb.Append($"ticket \"{ ticket}\" - {minLength}{leftPart.Substring(0, 1)}{Environment.NewLine}");
                            }
                        }
                        else
                        {
                            sb.Append($"ticket \"{ ticket}\" - no match{Environment.NewLine}");
                        }
                    }
                }
            }
            Console.WriteLine(sb);
        }
    }
}
