using System;
using System.Collections.Generic;

namespace ManajemenKaryawan
{
    public class Karyawan
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
            Console.WriteLine($"{Nama} sedang bekerja secara umum.");
        }

        public virtual void InfoKaryawan()
        {
            Console.WriteLine($"Nama: {Nama}, Gaji Pokok: {Gaji:N0}");
        }
    }

    public class Tetap : Karyawan
    {
        public double Tunjangan { get; set; }

        public Tetap(string nama, double gaji, double tunjangan) : base(nama, gaji)
        {
            Tunjangan = tunjangan;
        }

        public void HitungGajiTotal()
        {
            double total = Gaji + Tunjangan;
            Console.WriteLine($"Total Gaji {Nama} (Gaji + Tunjangan): {total:N0}");
        }

        public override void Kerja()
        {
            Console.WriteLine($"{Nama} bekerja sebagai karyawan tetap dengan jam kantor reguler.");
        }
    }

    public class Kontrak : Karyawan
    {
        public int Durasi { get; set; } 

        public Kontrak(string nama, double gaji, int durasi) : base(nama, gaji)
        {
            Durasi = durasi;
        }

        public void CekKontrak()
        {
            Console.WriteLine($"Sisa kontrak {Nama} adalah {Durasi} bulan.");
        }

        public override void Kerja()
        {
            Console.WriteLine($"{Nama} bekerja berdasarkan target proyek jangka pendek.");
        }
    }

    public class Manager : Tetap
    {
        public Manager(string nama, double gaji, double tunjangan) : base(nama, gaji, tunjangan) { }

        public void Memimpin()
        {
            Console.WriteLine($"{Nama} sedang memimpin rapat divisi.");
        }

        public override void Kerja()
        {
            Console.WriteLine($"{Nama} mengelola tim dan menyusun strategi departemen.");
        }
    }

    public class Staff : Tetap
    {
        public Staff(string nama, double gaji, double tunjangan) : base(nama, gaji, tunjangan) { }

        public void KerjakanTugas()
        {
            Console.WriteLine($"{Nama} sedang mengerjakan tugas harian operasional.");
        }

        public override void Kerja()
        {
            Console.WriteLine($"{Nama} menjalankan tugas teknis sesuai instruksi manager.");
        }
    }

        public class Magang : Kontrak
    {
        public Magang(string nama, double gaji, int durasi) : base(nama, gaji, durasi) { }

        public void Belajar()
        {
            Console.WriteLine($"{Nama} sedang mempelajari alur kerja di industri.");
        }

        public override void Kerja()
        {
            Console.WriteLine($"{Nama} membantu tim sambil belajar proses teknis.");
        }
    }

    public class Freelancer : Kontrak
    {
        public Freelancer(string nama, double gaji, int durasi) : base(nama, gaji, durasi) { }

        public void AmbilProyek()
        {
            Console.WriteLine($"{Nama} sedang mengambil proyek baru.");
        }

        public override void Kerja()
        {
            Console.WriteLine($"{Nama} menyelesaikan milestone proyek secara remote.");
        }
    }

    public class Perusahaan
    {
        private List<Karyawan> daftarKaryawan = new List<Karyawan>();

        
        public void TambahKaryawan(Karyawan karyawan)
        {
            daftarKaryawan.Add(karyawan);
            Console.WriteLine($"Berhasil menambahkan {karyawan.Nama} ke perusahaan.");
        }

        public void DaftarKaryawan()
        {
            Console.WriteLine("\n=== DAFTAR KARYAWAN PERUSAHAAN ===");
            foreach (var k in daftarKaryawan)
            {
                k.InfoKaryawan();
            }
        }

        public List<Karyawan> GetSemuaKaryawan() => daftarKaryawan;
    }

    class Program
    {
        static void Main(string[] args)
        {

            Perusahaan startup = new Perusahaan();

            Manager mngr = new Manager("Budiyono", 15000000, 5000000);
            Staff stf = new Staff("Siti", 8000000, 1000000);
            Magang mgg = new Magang("Lutfi", 2000000, 3);
            Freelancer frl = new Freelancer("Yono", 5000000, 1);

            startup.TambahKaryawan(mngr);
            startup.TambahKaryawan(stf);
            startup.TambahKaryawan(mgg);
            startup.TambahKaryawan(frl);

            startup.DaftarKaryawan();

            Console.WriteLine("\nDEMONSTRASI POLIMORFISME (Method Kerja)");
            foreach (var k in startup.GetSemuaKaryawan())
            {
                k.Kerja(); 
            }

            Console.WriteLine("\n=== DEMONSTRASI METHOD KHUSUS ===");
            mngr.Memimpin();
            stf.KerjakanTugas();
            mgg.Belajar();
            frl.AmbilProyek();

            mngr.HitungGajiTotal();
            mgg.CekKontrak();

            Console.ReadLine();
        }
    }
}