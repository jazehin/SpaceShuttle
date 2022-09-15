namespace SpaceShuttle
{

    class Program
    {
        static List<Kuldetes> kuldetesek = new List<Kuldetes>();
        public static void Main(string[] args)
        {
            F02();
            F03();
            F04();
            F05();
            F06();
            F07();
            F08();
            F09();
            F10();

            Console.ReadKey(true);
        }

        private static void F10()
        {
            FileStream fs = new FileStream("ursiklok.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);

            Dictionary<string, int> eltoltottOrak = new Dictionary<string, int>();

            foreach (Kuldetes kuldetes in kuldetesek)
                if (!eltoltottOrak.ContainsKey(kuldetes.Ursiklo))
                    eltoltottOrak.Add(kuldetes.Ursiklo, kuldetes.EltoltottIdo);
                else 
                    eltoltottOrak[kuldetes.Ursiklo] += kuldetes.EltoltottIdo;

            foreach (KeyValuePair<string, int> kv in eltoltottOrak)
                sw.WriteLine(kv.Key + "\t" + Math.Round((double)kv.Value / 24, 2));

            sw.Close();
            fs.Close();
        }

        private static void F09()
        {
            Console.WriteLine("9. feladat:");

            double szamlalo = 0;
            foreach (Kuldetes kuldetes in kuldetesek)
                if (kuldetes.Legitamaszpont == "Kennedy")
                    szamlalo++;

            Console.WriteLine($"\tA küldetések {Math.Round(szamlalo / kuldetesek.Count * 100, 2)}%-a fejeződött be a Kennedy űrközpontban.");
        }

        private static void F08()
        {
            Console.WriteLine("8. feladat:");
            Console.Write("\tÉvszám: ");
            int ev = Convert.ToInt32(Console.ReadLine());

            int szamlalo = 0;
            foreach (Kuldetes kuldetes in kuldetesek)
                if (kuldetes.Kiloves.Year == ev)
                    szamlalo++;

            if (szamlalo > 0)
                Console.WriteLine($"\tEbben az évben {szamlalo} küldetés volt.");
            else
                Console.WriteLine("\tEbben az évben nem indult küldetés.");
        }

        private static void F07()
        {
            Console.WriteLine("7. feladat:");

            int maxIdo = 0;
            for (int i = 0; i < kuldetesek.Count; i++)
                if (kuldetesek[i].EltoltottIdo > kuldetesek[maxIdo].EltoltottIdo)
                    maxIdo = i;

            Console.WriteLine($"\tA leghosszabb ideig a {kuldetesek[maxIdo].Ursiklo} volt az űrben a {kuldetesek[maxIdo].Kod} küldetés során.");
            Console.WriteLine($"\tÖsszesen {kuldetesek[maxIdo].EltoltottIdo} órát volt távol a Földtől.");
        }

        private static void F06()
        {
            Console.WriteLine("6. feladat:");

            List<Kuldetes> columbia = new List<Kuldetes>();

            foreach (Kuldetes kuldetes in kuldetesek)
                if (kuldetes.Ursiklo == "Columbia")
                    columbia.Add(kuldetes);

            int maxDatum = 0;
            for (int i = 0; i < columbia.Count; i++)
                if (columbia[i].Kiloves.Subtract(columbia[maxDatum].Kiloves).TotalMilliseconds > 0) 
                    maxDatum = i;

            Console.WriteLine($"\t{columbia[maxDatum].Legenyseg} asztronauta volt a Columbia fedélzetén annak utolsó útján.");

        }

        private static void F05()
        {
            Console.WriteLine("5. feladat:");

            int szamlalo = 0;
            foreach (Kuldetes kuldetes in kuldetesek)
            {
                if (kuldetes.Legenyseg < 5) szamlalo++;
            }

            Console.WriteLine($"\tÖsszesen {szamlalo} alkalommal küldtek kevesebb, mint 5 embert az űrbe.");
        }

        private static void F04()
        {
            Console.WriteLine("4. feladat:");

            int szum = 0;
            foreach (Kuldetes kuldetes in kuldetesek)
            {
                szum += kuldetes.Legenyseg;
            }

            Console.WriteLine($"\t{szum} utas indult az űrbe összesen.");
        }

        public static void F03()
        {
            Console.WriteLine("3. feladat:");
            Console.WriteLine($"\tÖsszesen {kuldetesek.Count} alkalommal indítottak űrhajót.");
        }

        public static void F02()
        {
            FileStream fs = new FileStream("kuldetesek.csv", FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            while (!sr.EndOfStream)
            {
                kuldetesek.Add(new Kuldetes(sr.ReadLine()));
            }

            sr.Close();
            fs.Close();
        }
    }
}