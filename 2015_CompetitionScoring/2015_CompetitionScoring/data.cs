﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2015_CompetitionScoring
{
    class Nevezések
    {
        List<Nevezés> nevezések = new List<Nevezés>();

        public Nevezések()
        {
            StreamReader forrás = new StreamReader("nevezes.txt");

            int i = 0;
            while (i < File.ReadLines("nevezes.txt").Count())
            {
                nevezések.Add(new Nevezés(forrás.ReadLine()));
                i++;
            }
        }
    }

    class Nevezés
    {
        int verseny;
        string csapat;
        int nevIdő;
        int hónap;
        int nap;
        string iskola;
        string megye;
        string diák;
        List<string> diákok = new List<string>();
        int évfolyam;
        string tanár;

        public Nevezés(string forrás)
        {
            string[] narancs = forrás.Split(';');

            /// Verseny kódja
            verseny = Convert.ToInt32(narancs[0]);

            /// Csapat neve
            csapat = narancs[1];

            /// Nevezés ideje
            hónap = Convert.ToInt32(narancs[2].Substring(0, 2));
            nap = Convert.ToInt32(narancs[2].Substring(2, 2));

            nevIdő = 0;
            for (int i = 1; i <= hónap; i++)
                nevIdő += i % 2 == 0 ? (i == 2 ? 28 : 30) : 31;
            nevIdő += nap;

            /// Iskola neve
            iskola = narancs[3];

            /// Megye neve
            megye = narancs[4];

            /// Diákok neve
            if (verseny == 1)
                for (int i = 0; i < 3; i++)
                    diákok.Add(narancs[5 + i]);

            else
                diák = narancs[5];

            /// Évfolyam
            évfolyam = Convert.ToInt32(verseny == 1 ? narancs[8] : narancs[6]);

            /// Felkészítő tanár
            tanár = verseny == 1 ? narancs[9] : narancs[7];
    }
    }
    class Eredmeny
    {
        public int programozóSzám;
        public int robotSzam;
        public string[,] csapatnev;
        public int[,] pontszam;
        public Eredmeny()
        {
            StreamReader eredmény = new StreamReader("eredmeny.txt");

            programozóSzám = Convert.ToInt32(eredmény.ReadLine());
            robotSzam = Convert.ToInt32(eredmény.ReadLine());

            csapatnev = new string [programozóSzám + robotSzam, 2]; // [x, 0] -> programozoadatok, [x, 1] -> robotadatok
            pontszam = new int [programozóSzám + robotSzam, 2]; // [x, 0] -> programozoadatok, [x, 1] -> robotadatok

            string[] konténer = new string[programozóSzám+robotSzam]; //ideiglenes változó, ezt még "splitelni" kell majd
            for (int i = 0; i < programozóSzám+robotSzam; i++)
            {
                konténer[i] = eredmény.ReadLine();
            }


            for (int i = 0; i < programozóSzám; i++) // programoró kategóriához ciklus
            {
                string[] ketteskonténer = konténer[i].Split(';');
                csapatnev[i, 0] = ketteskonténer[0];
                pontszam[i, 0] = Convert.ToInt32(ketteskonténer[1]);
            }
            for (int i = 0; i < robotSzam; i++) // robotika ketegóriához ciklus
            {
                string[] ketteskonténer = konténer[i + programozóSzám].Split(';');
                csapatnev[i, 1] = ketteskonténer[0];
                pontszam[i, 1] = Convert.ToInt32(ketteskonténer[1]);
            }
           
        }
    }

}
