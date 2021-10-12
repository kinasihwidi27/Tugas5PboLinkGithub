using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceHal305
{
    class Program
    {
        public class KomisiKaryawan : object
        {
            public string NamaDepan;
            public string NamaBelakang;
            public string NoKTP;
            private decimal penjualKotor;
            private decimal tarifKomisi;
            public KomisiKaryawan(string namaDepan, string namaBelakang, string noKTP, decimal penjualKotor, decimal tarifKomisi)
            {
                NamaDepan = namaDepan;
                NamaBelakang = namaBelakang;
                NoKTP = noKTP;
                PenjualKotor = penjualKotor; // Validasi dara penjual kotor
                TarifKomisi = tarifKomisi; // Validasi tarifkomisi
            }
            public void setNamaDepan(string namaDepan)
            {
                NamaDepan = namaDepan;
            }
            public string getNamaDepan()
            {
                return NamaDepan;
            }
            public void setNamaBelakang(string namaBelakang)
            {
                NamaBelakang = namaBelakang;
            }
            public string getNamaBelakang()
            {
                return NamaBelakang;
            }
            public void setNoKTP(string noKTP)
            {
                NoKTP = noKTP;
            }
            public string getNoKTP()
            {
                return NoKTP;
            }
            public decimal PenjualKotor
            {
                get
                {
                    return penjualKotor;
                }
                set
                {
                    penjualKotor = (value < 0) ? 0 : value;
                }
            }
            public decimal TarifKomisi
            {
                get
                {
                    return tarifKomisi;
                }
                set
                {
                    tarifKomisi = (value > 0 && value < 1) ? value : 0;
                }
            }
            public decimal Pendapatan()
            {
                return TarifKomisi * PenjualKotor;
            }
            public override string ToString()
            {
                return string.Format("\nNama Depan : {0}, \nNama Belakang : {1}, \nNo KTP : {2}, \nPenjual Kotor : {3}, \nTarif Komisi : {4}", NamaDepan, NamaBelakang, NoKTP, penjualKotor, tarifKomisi);
            }
            static void Main(string[] args)
            {
                KomisiKaryawan karyawan = new KomisiKaryawan("Sue", "Jones", "222-22-222", 10000.00M, .06M);

                Console.WriteLine("Informasi karyawan diperoleh dengan properti dan metode : \n");
                Console.WriteLine("Nama Depan adalah {0}", karyawan.NamaDepan);
                Console.WriteLine("Nama Belakang adalah {0}", karyawan.NamaBelakang);
                Console.WriteLine("No KTP adalah {0}", karyawan.NoKTP);
                Console.WriteLine("Penjual Kotor adalah {0:C}", karyawan.PenjualKotor);
                Console.WriteLine("Tarif Komisi adalah {0:F2}", karyawan.TarifKomisi);
                Console.WriteLine("Pendapatan adalah {0:C}", karyawan.Pendapatan());

                karyawan.PenjualKotor = 5000.00M; //set penjual kotor
                karyawan.TarifKomisi = .1M; //set tarif komisi
                Console.WriteLine("{0} :  {1}", "Informasi terbaru karyawan diperoleh dari ToString", karyawan);
                Console.WriteLine("karyawan : {0:C}", karyawan.Pendapatan());
                Console.ReadLine();

            }
        }
    }
}