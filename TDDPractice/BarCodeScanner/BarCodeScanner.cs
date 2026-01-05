namespace TDDPractice.BarCodeScanner
{
    public class BarCodeScanner
    {
        Dictionary<string, string> barcodes = new Dictionary<string, string>
        {
            { "12345", "$7.25" },
            { "23456", "$12.50" }
        };

        public string Scan(string input)
        {
            if(String.IsNullOrEmpty(input))
            {
                return "Error: empty barcode";
            }

            if (!barcodes.ContainsKey(input))
            {
                return "Error: barcode not found";
            }

            return barcodes[input];
        }
    }
}
