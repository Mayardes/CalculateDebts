using OLIVEIRA.Mayardes.Finances.CalculateDebts.Enums;
using System.Text;

namespace OLIVEIRA.Mayardes.Finances.CalculateDebts.Models
{
    public class BillsModel
    {
        public SectorEnum Sector { get; set; }
        public string Enterprise { get; set; }
        public decimal Value { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Enterprise} \t R$: {Value}");
            return sb.ToString();
        }

    }
}
