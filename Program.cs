using System;

public class Bandung
{
    public enum Kelurahan
    {
        Batununggal,
        Kujangsari,
        Wates,
        Cijaura,
        Jatisari,
        Margasari,
        Sekejati,
        Kebonwaru,
        Maleer,
        Samoja,
        // Tambahkan kota lainnya sesuai kebutuhan
    }

    public static int GetKodePos(Kelurahan kelurahan)
    {
        int[] kodePos = { 40266, 40287, 40267, 40256, 40287, 40286, 40286, 40286, 40272, 40274, 40273 };

        return kodePos[(int)kelurahan];
    }
}

class Program
{
    static void Main()
    {
        Bandung.Kelurahan contohKelurahan = Bandung.Kelurahan.Batununggal;

        int kodePos = Bandung.GetKodePos(contohKelurahan);

        Console.WriteLine($"Kode Pos untuk kelurahan {contohKelurahan} adalah {kodePos}");
    }
}