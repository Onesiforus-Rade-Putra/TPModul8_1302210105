using TPModul8_1302210105;
public class Program
{
    private static void Main(string[] args)
    {
        covid CovidConfig = new covid();
        Console.Write("Berapa suhu badan anda?" + covid.covid.satuan_suhu + ": ");
        double suhu = double.Parse(Console.ReadLine());
        Console.Write("Berapa hari mengalami gejala deman? : ");
        int hariDemam = int.Parse(Console.ReadLine());
        if (CovidConfig.inputan(suhu, hariDemam))
        {
            Console.WriteLine(covid.covid.pesan_diterima);
        }
        else
        {
            Console.WriteLine(covid.covid.pesan_ditolak);
        }
    }
}