using System;
using System.Security.Cryptography.X509Certificates;

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
};
class Program
{
    static void Main()
    {
        Bandung.Kelurahan contohKelurahan = Bandung.Kelurahan.Batununggal;

        int kodePos = Bandung.GetKodePos(contohKelurahan);

        Console.WriteLine($"Kode Pos untuk kelurahan {contohKelurahan} adalah {kodePos}");
    }
}


public enum Pintu { Terkunci, Terbuka };
public enum Trigger { KunciPintu, BukaPintu };

public class Aktivitas
{
    // Gunakan properti untuk transisi
    public Transtion[] Transisi { get; set; }
    public Pintu CurrentState { get; set; }

    public Aktivitas()
    {
        // Inisialisasi transisi di konstruktor
        Transisi = new Transtion[]
        {
            new Transtion(Pintu.Terkunci, Pintu.Terbuka, Trigger.BukaPintu),
            new Transtion(Pintu.Terbuka, Pintu.Terkunci, Trigger.KunciPintu)
        };

        // Inisialisasi stateAwal di konstruktor
        CurrentState = Pintu.Terkunci;
    }

    // Metode untuk mendapatkan nextState
    public Pintu GetNextState(Pintu stateAwal, Trigger trigger)
    {
        Pintu stateAkhir = stateAwal;

        for (int i = 0; i < Transisi.Length; i++)
        {
            Transtion perubahan = Transisi[i];
            if (stateAwal == perubahan.stateAwal && trigger == perubahan.Trigger)
            {
                stateAkhir = perubahan.stateAkhir;
            }
        }
        return stateAkhir;
    }

    // Metode untuk aktivasi trigger
    public void ActivateTrigger(Trigger trigger)
    {
        CurrentState = GetNextState(CurrentState, trigger);
        Console.WriteLine("State Pintu Sekarang adalah: " + CurrentState);

        if (CurrentState == Pintu.Terbuka)
        {
            Console.WriteLine("Pintu Terbuka");
        }
    }

    public static void Main(string[] args)

    {
        Aktivitas objAktivitas = new Aktivitas();
        Console.WriteLine(objAktivitas.CurrentState);

        objAktivitas.ActivateTrigger(Trigger.BukaPintu);
    }
}

public class Transtion
{
    public Pintu stateAwal;
    public Pintu stateAkhir;
    public Trigger Trigger;

    public Transtion(Pintu stateAwal, Pintu stateAkhir, Trigger trigger)
    {
        this.stateAwal = stateAwal;
        this.stateAkhir = stateAkhir;
        this.Trigger = trigger;
    }
}
