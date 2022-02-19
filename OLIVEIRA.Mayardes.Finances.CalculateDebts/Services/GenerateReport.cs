using OLIVEIRA.Mayardes.Finances.CalculateDebts.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace OLIVEIRA.Mayardes.Finances.CalculateDebts.Services
{
    public class GenerateReport
    {
        public static StringBuilder sb = new StringBuilder();
        public static decimal salary;
        public static int maxLengh = 70;
        public static void GenerateFile(List<BillsModel> bills)
        {
            string path = @"C:\Users\Mayardes Oliveira\Documents\Dívidas\";
            string month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month);
            string year = DateTime.Now.Year.ToString();

            foreach (var item in bills)
            {
                try
                {
                    sb.Append(item.Enterprise + ":");
                    for (int i = item.Enterprise.Length; i <= maxLengh; i++)
                        sb.Append(' ');
                    sb.AppendLine("R$ " + item.Value);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            for (int i = 0; i < maxLengh; i++)
                sb.Append('-');

            sb.AppendLine("");
            sb.AppendLine("Value total Expenses: R$ " + Calculate.GetValueTotalExpenses().ToString());

            for (int i = 0; i < maxLengh; i++)
                sb.Append('-');

            sb.AppendLine();
            sb.AppendLine("Your Salary Monthy is: R$ " + salary);
            for (int i = 0; i < maxLengh; i++)
                sb.Append('-');

            sb.AppendLine();
            sb.AppendLine("Total Final: R$ " + (salary - Calculate.GetValueTotalExpenses()));
              for (int i = 0; i < maxLengh; i++)
                sb.Append('-');

            using (FileStream fs = File.Create(path + month.ToUpper() + "_" + year +".txt"))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(sb.ToString());
                fs.Write(info, 0, info.Length);
            }
        }
    }
}
