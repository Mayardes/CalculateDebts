using OLIVEIRA.Mayardes.Finances.CalculateDebts.Enums;
using OLIVEIRA.Mayardes.Finances.CalculateDebts.Models;
using OLIVEIRA.Mayardes.Finances.CalculateDebts.Services;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace OLIVEIRA.Mayardes.Finances.CalculateDebts
{
    class Program
    {
        public static List<BillsModel> bills = new();
        static void Main(string[] args)
        { 

            decimal claro = 0;
            decimal creditcard = 0;
            decimal posGraduate = 0;
            decimal gym = 0;
            decimal waterBill = 0;
            char opt;

            Console.WriteLine("How much did these bills costs:");
            Console.WriteLine("");
            Console.WriteLine("Claro (Net, Phone Bill, Cable TV):");
            claro = Convert.ToDecimal(Console.ReadLine(), CultureInfo.InvariantCulture);
            bills.Add(new BillsModel() { Enterprise = "Claro (Net, Phone Bill, Cable TV):", Sector = Enums.SectorEnum.Communication, Value = claro});

            Console.WriteLine("Credit card bill:");
            creditcard = Convert.ToDecimal(Console.ReadLine(), CultureInfo.InvariantCulture);
            bills.Add(new BillsModel() { Enterprise = "Credit card bill", Sector = Enums.SectorEnum.CreditCard, Value = creditcard});

            Console.WriteLine("Pos graduate");
            posGraduate = Convert.ToDecimal(Console.ReadLine(),CultureInfo.InvariantCulture);
            bills.Add(new BillsModel(){ Enterprise = "Pontifical Catholic University of Minas Gerais", Sector = Enums.SectorEnum.School, Value = posGraduate});

            Console.WriteLine("Gym:");
            gym = Convert.ToDecimal(Console.ReadLine(), CultureInfo.InvariantCulture);
            bills.Add(new BillsModel() { Enterprise = "Gym", Sector = Enums.SectorEnum.Health, Value = gym});

            Console.WriteLine("Water:");
            waterBill = Convert.ToDecimal(Console.ReadLine(), CultureInfo.InvariantCulture);
            bills.Add(new BillsModel(){ Enterprise = "Manaus Waters", Sector = Enums.SectorEnum.Water, Value = waterBill});


            Console.WriteLine("Do you want add more spends? [S/N]");
            opt = Convert.ToChar(Console.ReadLine().ToUpper());
            while(opt == 'S')
            {
                string enterprise;
                int sectorInteger;
                decimal value;
                SectorEnum sector;

                Console.WriteLine("What is the sector:");
                Console.WriteLine("1 - Communication");
                Console.WriteLine("2 - Water");
                Console.WriteLine("3 - Car");
                Console.WriteLine("4 - Health");
                Console.WriteLine("5 - School");
                Console.WriteLine("6 - CreditCard");
                Console.WriteLine("7 - Gas");

                sectorInteger = Convert.ToInt32(Console.ReadLine(), CultureInfo.InvariantCulture);
                sector = (SectorEnum) sectorInteger;

                Console.WriteLine("What is the name Enterprise?");
                enterprise = Console.ReadLine();

                Console.WriteLine("How much does it cost:");
                value = Convert.ToDecimal(Console.ReadLine(), CultureInfo.InvariantCulture);

                bills.Add(new BillsModel() { Enterprise = enterprise, Sector = sector, Value = value });

                Console.WriteLine("Do you want add more spends? [S/N]");
                opt = Convert.ToChar(Console.ReadLine().ToUpper());

            }

            Console.WriteLine("-------------------------------------------------");
            foreach(BillsModel bill in bills)
            {
                Console.WriteLine(bill);
                Calculate.ToSum(bill.Value);
            }
            Console.WriteLine($"Value Total: {Calculate.GetValueTotal()}" );
            Console.WriteLine("-------------------------------------------------");

        }
    }
}
