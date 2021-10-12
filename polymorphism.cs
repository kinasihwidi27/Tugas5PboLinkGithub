using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphismHal338
{
    class Program
    {

        //Class Karyawan
        public abstract class Karyawan
        {
            public string NamaDepan { get; }
            public string NamaBelakang { get; }
            public string NoKtp { get; }

            public Karyawan(string namaDepan, string namaBelakang, string noKtp)
            {
                NamaDepan = namaDepan;
                NamaBelakang = namaBelakang;
                NoKtp = noKtp;
            }

            public override string ToString() =>
            $"{NamaDepan}{NamaBelakang}\n " +
            $" No KTP               : {NoKtp}";
            public abstract decimal Penghasilan();
        }

        //Class Gaji Karyawan
        public class GajiKaryawan : Karyawan
        {
            private decimal gajiMingguan;

            public GajiKaryawan(string namaDepan, string namaBelakang, string noKtp, decimal gajiMingguan) :
            base(namaDepan, namaBelakang, noKtp)
            {
                GajiMingguan = gajiMingguan;
            }

            public decimal GajiMingguan
            {
                get { return gajiMingguan; }
                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(GajiMingguan) } harus >= 0");
                    }
                    gajiMingguan = value;
                }
            }
            public override decimal Penghasilan() => GajiMingguan;
            public override string ToString() =>
            $"\n  Gaji Karyawan        :{base.ToString()}\n " +
            $" Gaji Mingguan        : {GajiMingguan:C}";
        }

        //Class KaryawanPerjam
        public class KaryawanPerJam : Karyawan
        {
            private decimal gaji;
            private decimal jam;


            public KaryawanPerJam(string namaDepan, string namaBelakang, string noKtp, decimal gajiperJam, decimal jamBekerja) :
                      base(namaDepan, namaBelakang, noKtp)
            {
                Gaji = gajiperJam;
                Jam = jamBekerja;
            }

            public decimal Gaji
            {
                get { return gaji; }
                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(Gaji) } harus >= 0");
                    }
                    gaji = value;
                }
            }

            public decimal Jam
            {
                get { return jam; }
                set
                {
                    if (value < 0 || value > 168)
                    {
                        throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(Jam) } harus >= 0 dan <= 168");
                    }
                    jam = value;
                }
            }

            public override decimal Penghasilan()
            {
                if (Jam <= 40)
                {
                    return Gaji * Jam;
                }
                else
                {
                    return (40 * Gaji) + ((Jam - 40) * Gaji * 1.5M);
                }
            }

            public override string ToString() =>
                $"\n  Karyawan per Jam     :{base.ToString()}\n " +
                $" Gaji per Jam         : {Gaji:C}\n  Jam Kerja            : {Jam:F2}";
        }


        //Class KomisiKaryawan
        public class KomisiKaryawan : Karyawan
        {
            private decimal penjualanBruto;
            private decimal tarifKomisi;

            public KomisiKaryawan(string namaDepan, string namaBelakang, string noKtp, decimal penjualanBruto, decimal tarifKomisi) :
                base(namaDepan, namaBelakang, noKtp)
            {
                PenjualanBruto = penjualanBruto;
                TarifKomisi = tarifKomisi;
            }

            public decimal PenjualanBruto
            {
                get { return penjualanBruto; }
                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(PenjualanBruto)} harus >= 0");
                    }
                    penjualanBruto = value;
                }
            }

            public decimal TarifKomisi
            {
                get { return penjualanBruto; }
                set
                {
                    if (value <= 0 || value >= 1)
                    {
                        throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(TarifKomisi)} harus > 0 dan< 1");
                    }
                    tarifKomisi = value;
                }

            }

            public override decimal Penghasilan() => TarifKomisi * PenjualanBruto;

            public override string ToString() =>
                $"\n  Komisi Karyawan      : {base.ToString()}\n" +
                $"  Penjualan Bruto      : {PenjualanBruto:C}\n " +
                $" Tarif Komisi         : {TarifKomisi:F2}";
        }


        //Class Gaji Pokok Plus Komisi Karyawan
        public class GajiPokokPlusKomisiKaryawan : KomisiKaryawan
        {
            private decimal gajiPokok;

            public GajiPokokPlusKomisiKaryawan(string namaDepan, string namaBelakang, string noKtp, decimal penjualanBruto, decimal tarifKomisi, decimal gajiPokok)
             : base(namaDepan, namaBelakang, noKtp, penjualanBruto, tarifKomisi)
            {
                GajiPokok = gajiPokok;
            }

            public decimal GajiPokok
            {
                get { return gajiPokok; }
                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(GajiPokok)} harus >= 0");
                    }
                    gajiPokok = value;
                }
            }

            public override decimal Penghasilan() => GajiPokok + base.Penghasilan();

            public override string ToString() => $"\n  Gaji-Pokok{base.ToString()} \n  Gaji Pokok           : {GajiPokok:C}";
        }


        //Main Program
        static void Main(string[] args)
        {
            var gajiKaryawan = new GajiKaryawan(" John", " Smith", "111-11-1111", 800.00M);
            var karyawanPerJam = new KaryawanPerJam(" Karen", " Price", "222-22-2222", 16.75M, 40.0M);
            var komisiKaryawan = new KomisiKaryawan("Sue", "Jones", "333-33-3333", 10000.00M, .06M);
            var gajiPokokPlusKomisiKaryawan = new GajiPokokPlusKomisiKaryawan("Bob", "Lewis", "444-44-4444", 5000.00M, .04M, 300.00M);

            Console.WriteLine(" Karyawan diproses secara individual : \n");
            Console.WriteLine($" {gajiKaryawan}\n  Diperoleh            : " + $"{gajiKaryawan.Penghasilan():C}");
            Console.WriteLine($" {karyawanPerJam}\n  Diperoleh            : " + $"{karyawanPerJam.Penghasilan():C}");
            Console.WriteLine($" {komisiKaryawan}\n  Diperoleh            : " + $"{komisiKaryawan.Penghasilan():C}");
            Console.WriteLine($" {gajiPokokPlusKomisiKaryawan}\n  Diperoleh            : " + $"{gajiPokokPlusKomisiKaryawan.Penghasilan():C}\n");


            var seluruhKaryawan = new List<Karyawan>() { gajiKaryawan, karyawanPerJam, komisiKaryawan, gajiPokokPlusKomisiKaryawan };
            Console.WriteLine("\n  Karyawan diproses secara Polimorfik : ");

            foreach (var karyawanSekarang in seluruhKaryawan)
            {
                Console.WriteLine(karyawanSekarang);

                if (karyawanSekarang is GajiPokokPlusKomisiKaryawan)
                {
                    var karyawan = (GajiPokokPlusKomisiKaryawan)karyawanSekarang;
                    karyawan.GajiPokok *= 1.10M;
                    Console.WriteLine("  Gaji Pokok baru dengan kenaikan 10% adalah : " + $"{karyawan.GajiPokok:C}");
                }
                Console.WriteLine($"  Penghasilan          : {karyawanSekarang.Penghasilan():C}");
            }
            Console.WriteLine();
            for (int j = 0; j < seluruhKaryawan.Count; j++)
            {
                Console.WriteLine($"  Karyawan {j} adalah {seluruhKaryawan[j].GetType()}");

            }
            Console.ReadLine();
        }
    }
}