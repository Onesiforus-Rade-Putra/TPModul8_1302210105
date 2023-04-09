using TPModul8_1302210105;
public class Program
{
    private static void Main(string[] args)
    {
        covid covid = new covid();
        Console.Write("Berapa suhu badan anda?" + covid.CovidConfig.satuan_suhu + ": ");
        double suhu = double.Parse(Console.ReadLine());
        Console.Write("Berapa hari mengalami gejala deman? : ");
        int hariDemam = int.Parse(Console.ReadLine());
        if (covid.inputan(suhu, hariDemam))
        {
            Console.WriteLine(covid.CovidConfig.pesan_diterima);
        }
        else
        {
            Console.WriteLine(covid.CovidConfig.pesan_ditolak);
        }
    }
}