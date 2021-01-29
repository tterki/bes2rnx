using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("================================");
            Console.WriteLine("|       B.E.S  To  R.N.X       |");
            Console.WriteLine("================================");
            string Mydir = System.IO.Directory.GetCurrentDirectory();
            Console.WriteLine();

            Console.Write("Entrez le code de la station : ");
            string code = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Entrez nouveau code de sortie : ");
            string new_code = Console.ReadLine();
            string MarkerName = " -O.mo " + new_code;
            string MarkerNum = " -O.mn " + new_code;
            Console.WriteLine();

            Console.Write("Entrez année (04 pour 2004) : ");
            string year = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Entrez nom d'opérateur -O.e : ");
            string operateur = Console.ReadLine(); string Operateur = "";
            if (operateur != "")
            { Operateur = " -O.o " + operateur; }
            Console.WriteLine();

            string Agency = " -O.ag C.R.A.A.G.";
            Console.WriteLine();

            //Console.Write("Entrez le nom du Marker Name -O.mo et du Marker Numer -O.mn : ");
            //string markerName = Console.ReadLine(); string MarkerName = "";
            //string MarkerNum = "";
            //if (markerName != "")
            //{
            //    MarkerName = " -O.mo " + markerName;
            //    MarkerNum = " -O.mn " + markerName;
            //}
            //Console.WriteLine();

            //string nav_out;
            //string obs_out;
            string Instruction;
            //====================================================================================================
            //====================================================================================================
            for (int i = 1; i < 366; i++)
            {
                //================================================================================================
                //  CONVERSION DU JOUR GPS EN DATE :
                //==================================
                int Year = Convert.ToInt32(year) + 2000;
                DateTime theDate = new DateTime(Year, 1, 1).AddDays(i - 1);
                string MyDate = theDate.ToString("yyyy:MM:dd");
                //Console.WriteLine(MyDate);
                //Console.ReadLine();
                //===============================================================================================
                if (i < 10)
                {
                    //nav_out = new_code + "00" + i + "0." + year + "n";
                    //obs_out = new_code + "00" + i + "0." + year + "o";
                    Instruction = "/C teqc -week " + MyDate + Operateur + Agency + MarkerName + MarkerNum + " +obs + +nav +,+ -tbin 1d " + new_code + " B" + code + "*" + year + ".00" + i;
                    //Instruction = "/C teqc -week " + MyDate + Operateur + Agency + MarkerName + MarkerNum + " +obs " + obs_out + " B" + code + "*04.00" + i;
                    Console.WriteLine(Instruction);
                    Console.WriteLine(Instruction);
                }
                else if (i < 100)
                {
                    //nav_out = new_code + "0" + i + "0." + year + "n";
                    //obs_out = new_code + "0" + i + "0." + year + "o";
                    // Instruction = "/C teqc -week " + MyDate + Operateur + Agency + MarkerName + MarkerNum + " +obs " +   " B" + code + "*04.0" + i;
                    Instruction = "/C teqc -week " + MyDate + Operateur + Agency + MarkerName + MarkerNum + " +obs + +nav +,+ -tbin 1d " + new_code + " B" + code + "*" + year + ".0" + i;
                    //Console.WriteLine(obs_out);
                    Console.WriteLine(Instruction);
                }
                else
                {
                    //nav_out = new_code + i + "0." + year + "n";
                    //obs_out = new_code + i + "0." + year + "o";
                    //Instruction = "/C teqc -week " + MyDate + Operateur + Agency + MarkerName + MarkerNum + " +obs " +  " B" + code + "*04." + i;
                    Instruction = "/C teqc -week " + MyDate + Operateur + Agency + MarkerName + MarkerNum + " +obs + +nav +,+ -tbin 1d " + new_code + " B" + code + "*" + year + "." + i;
                    //Console.WriteLine(obs_out);
                    Console.WriteLine(Instruction);
                }
                //====================================================================================================
                //====================================================================================================
                //Console.WriteLine(Instruction);
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.WorkingDirectory = Mydir;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo.Arguments = Instruction;
                p.Start();
            }
            Console.WriteLine("Terminé!");
            Console.ReadLine();
        }
    }
}
