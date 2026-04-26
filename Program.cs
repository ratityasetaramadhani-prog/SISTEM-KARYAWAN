using System;
using System.Collections.Generic;


// KELAS DASAR: Karyawan
class Karyawan
{
    public string Nama { get; set; }
    public double Gaji { get; set; }

    public Karyawan(string nama, double gaji)
    {
        Nama = nama;
        Gaji = gaji;
    }

    public virtual void Kerja()
    {
        Console.WriteLine($"[Karyawan] {Nama} sedang bekerja.");
    }

    public virtual void InfoKaryawan()
    {
        Console.WriteLine($"  Nama  : {Nama}");
        Console.WriteLine($"  Gaji  : Rp {Gaji:N0}");
    }
}


// KELAS TETAP (mewarisi Karyawan)
class Tetap : Karyawan
{
    public double Tunjangan { get; set; }

    public Tetap(string nama, double gaji, double tunjangan)
        : base(nama, gaji)
    {
        Tunjangan = tunjangan;
    }

    public double HitungGajiTotal()
    {
        return Gaji + Tunjangan;
    }

    public override void Kerja()
    {
        Console.WriteLine($"[Tetap] {Nama} bekerja sebagai karyawan tetap.");
    }

    public override void InfoKaryawan()
    {
        base.InfoKaryawan();
        Console.WriteLine($"  Tunjangan   : Rp {Tunjangan:N0}");
        Console.WriteLine($"  Total Gaji  : Rp {HitungGajiTotal():N0}");
    }
}


// KELAS KONTRAK (mewarisi Karyawan)
class Kontrak : Karyawan
{
    public int Durasi { get; set; } // dalam bulan

    public Kontrak(string nama, double gaji, int durasi)
        : base(nama, gaji)
    {
        Durasi = durasi;
    }

    public void CekKontrak()
    {
        Console.WriteLine($"  Kontrak {Nama}: {Durasi} bulan.");
        if (Durasi <= 3)
            Console.WriteLine("  Status: Kontrak hampir habis!");
        else
            Console.WriteLine("  Status: Kontrak masih aktif.");
    }

    public override void Kerja()
    {
        Console.WriteLine($"[Kontrak] {Nama} bekerja berdasarkan kontrak {Durasi} bulan.");
    }

    public override void InfoKaryawan()
    {
        base.InfoKaryawan();
        Console.WriteLine($"  Durasi Kontrak : {Durasi} bulan");
    }
}


// KELAS MANAGER (mewarisi Tetap)
class Manager : Tetap
{
    public Manager(string nama, double gaji, double tunjangan)
        : base(nama, gaji, tunjangan) { }

    public void Memimpin()
    {
        Console.WriteLine($"  {Nama} sedang memimpin rapat tim.");
    }

    public override void Kerja()
    {
        Console.WriteLine($"[Manager] {Nama} mengelola tim dan mengambil keputusan yang tepat.");
    }

    public override void InfoKaryawan()
    {
        Console.WriteLine("  [MANAGER]");
        base.InfoKaryawan();
    }
}


// KELAS STAFF (mewarisi Tetap)
class Staff : Tetap
{
    public Staff(string nama, double gaji, double tunjangan)
        : base(nama, gaji, tunjangan) { }

    public void KerjakanTugas()
    {
        Console.WriteLine($"  {Nama} sedang mengerjakan tugas harian.");
    }

    public override void Kerja()
    {
        Console.WriteLine($"[Staff] {Nama} menyelesaikan tugas operasional.");
    }

    public override void InfoKaryawan()
    {
        Console.WriteLine("  [STAFF]");
        base.InfoKaryawan();
    }
}


// KELAS MAGANG (mewarisi Kontrak)
class Magang : Kontrak
{
    public Magang(string nama, double gaji, int durasi)
        : base(nama, gaji, durasi) { }

    public void Belajar()
    {
        Console.WriteLine($"  {Nama} sedang belajar dan mengikuti program magang.");
    }

    public override void Kerja()
    {
        Console.WriteLine($"[Magang] {Nama} sedang magang selama {Durasi} bulan.");
    }

    public override void InfoKaryawan()
    {
        Console.WriteLine("  [MAGANG]");
        base.InfoKaryawan();
    }
}


// KELAS FREELANCER (mewarisi Kontrak)
class Freelancer : Kontrak
{
    public Freelancer(string nama, double gaji, int durasi)
        : base(nama, gaji, durasi) { }

    public void AmbilProyek()
    {
        Console.WriteLine($"  {Nama} mengambil proyek baru untuk dikerjakan.");
    }

    public override void Kerja()
    {
        Console.WriteLine($"[Freelancer] {Nama} mengerjakan proyek secara lepas.");
    }

    public override void InfoKaryawan()
    {
        Console.WriteLine("[FREELANCER]");
        base.InfoKaryawan();
    }
}


// KELAS PERUSAHAAN
class Perusahaan
{
    private List<Karyawan> daftarKaryawan = new List<Karyawan>();

    public void TambahKaryawan(Karyawan karyawan)
    {
        daftarKaryawan.Add(karyawan);
        Console.WriteLine($"  >> {karyawan.Nama} berhasil ditambahkan.");
    }

    public void DaftarKaryawan()
    {
        
        Console.WriteLine("DAFTAR SELURUH KARYAWAN");
     

        if (daftarKaryawan.Count == 0)
        {
            Console.WriteLine("  Tidak ada karyawan terdaftar.");
            return;
        }

        int no = 1;
        foreach (var k in daftarKaryawan)
        {
            Console.WriteLine($"\n--- Karyawan #{no++} ---");
            k.InfoKaryawan();
        }
        Console.WriteLine("\n========================================");
    }

    // Getter untuk akses list dari Main
    public List<Karyawan> GetDaftarKaryawan() => daftarKaryawan;
}


// PROGRAM UTAMA
class Program
{
    static void Main(string[] args)
    {
        
        Console.WriteLine("   SISTEM MANAJEMEN KARYAWAN          ");
      

        // ── 1. Buat Objek Perusahaan ────────────────────────
        Perusahaan perusahaan = new Perusahaan();

        // ── 2. Buat Objek Karyawan ──────────────────────────
        Manager mgr = new Manager("Bayu Aji", 15_000_000, 5_000_000);
        Staff stf = new Staff("Ayu Dwi", 8_000_000, 1_500_000);
        Magang mgng = new Magang("Jeno Sujono", 2_000_000, 3);
        Freelancer fl = new Freelancer("lala lili", 6_000_000, 6);

        // ── 3. Tambahkan ke Perusahaan ──────────────────────
        Console.WriteLine("▶ Menambahkan karyawan ke perusahaan...");
        perusahaan.TambahKaryawan(mgr);
        perusahaan.TambahKaryawan(stf);
        perusahaan.TambahKaryawan(mgng);
        perusahaan.TambahKaryawan(fl);

        // ── 4. Tampilkan Semua Data ─────────────────────────
        perusahaan.DaftarKaryawan();

        // ── 5. Demonstrasi Polymorphism ─────────────────────
        Console.WriteLine("\n▶ DEMONSTRASI POLYMORPHISM (method Kerja()):");
        foreach (Karyawan k in perusahaan.GetDaftarKaryawan())
        {
            k.Kerja(); // setiap subclass memanggil versi override-nya
        }

        // ── 6. Panggil Method Khusus ────────────────────────
        Console.WriteLine("\n▶ METHOD KHUSUS PER TIPE KARYAWAN:");
        

        Console.WriteLine("\n[Manager → Memimpin()]");
        mgr.Memimpin();

        Console.WriteLine("\n[Staff → KerjakanTugas()]");
        stf.KerjakanTugas();

        Console.WriteLine("\n[Magang → Belajar()]");
        mgng.Belajar();

        Console.WriteLine("\n[Freelancer → AmbilProyek()]");
        fl.AmbilProyek();

        // ── 7. Fitur Tambahan: HitungGajiTotal & CekKontrak ─
        Console.WriteLine("\n▶ HITUNG GAJI TOTAL (Karyawan Tetap):");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine($"  Gaji Total {mgr.Nama} : Rp {mgr.HitungGajiTotal():N0}");
        Console.WriteLine($"  Gaji Total {stf.Nama} : Rp {stf.HitungGajiTotal():N0}");

        Console.WriteLine("\n▶ CEK KONTRAK (Karyawan Kontrak):");
        mgng.CekKontrak();
        fl.CekKontrak();

        
        Console.WriteLine("   Program Selesai. Terima kasih!     ");
        
    }
}