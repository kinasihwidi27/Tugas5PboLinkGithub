using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceeHal355
{
    class Program
    {
        //class gaji karyawan
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

        //IHutang
        public interface IHutang
        {
            decimal DapatkanJumlahPembayaran();
        }

        //Class Karyawan
        public abstract class Karyawan : IHutang
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
                $" {NamaDepan} {NamaBelakang}\n " +
                $" No KTP              : {NoKtp}";
            public abstract decimal Penghasilan();

            public decimal DapatkanJumlahPembayaran() => Penghasilan();
        }

        //Class Tagihan
        public class Tagihan : IHutang
        {
            public string NomorBagian { get; }
            public string DeskripsiBagian { get; }
            private int jumlah;
            private decimal hargaPerBarang;

            public Tagihan(string nomorBagian, string deskripsiBagian, int jumlah, decimal hargaPerBarang)
            {
                NomorBagian = nomorBagian;
                DeskripsiBagian = deskripsiBagian;
                Jumlah = jumlah;
                HargaPerBarang = hargaPerBarang;
            }

            public int Jumlah
            {
                get { return jumlah; }

                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(Jumlah)} harus >= 0");
                    }

                    jumlah = value;
                }
            }

            public decimal HargaPerBarang
            {
                get { return hargaPerBarang; }
                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(HargaPerBarang)} harus >= 0");
                    }
                    hargaPerBarang = value;
                }
            }

            public override string ToString() =>
            $"  Tagihan :\n  Nomor Bagian        : {NomorBagian} ({DeskripsiBagian})\n" +
            $"  Jumlah              : {Jumlah}\n  Harga per Barang    : {HargaPerBarang:C}";

            public decimal DapatkanJumlahPembayaran() => Jumlah * HargaPerBarang;
        }

        //Main program
        static void Main(string[] args)
        {
            var Hutang = new List<IHutang>() {
            new Tagihan("01234",  "seat",  2,  375.00M),
            new Tagihan("56789",  "tire",  4,  79.95M),
            new GajiKaryawan("John",  "Smith", "111-11-1111",  800.00M),
            new GajiKaryawan("Lisa",  "Barnes", "888-88-8888",  1200.00M)};

            Console.WriteLine("  Tagihan dan Karyawan diproses secara Polimorfik : \n");

            foreach (var hutang in Hutang)
            {
                Console.WriteLine($"{hutang}");
                Console.WriteLine($"  Tanggal jatuh tempo : {hutang.DapatkanJumlahPembayaran():C}\n");
            }
            Console.ReadLine();
        }
    }
}