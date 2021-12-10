class Program
    {
        const int Cmaxsize = 10;
        const string CFd1 = "John.txt";
        const string CFd2 = "Mary.txt";
        const string CJohnResults = "JohnResults.txt";
        const string CMaryResults = "MaryResults.txt";


        static void Read(string fv, Person[] p, out int number)
        {
            string country;
            double money, conversion;
            using (StreamReader reader = new StreamReader(fv))
            {
                string line;
                line = reader.ReadLine();
                int i = 0;
                number = 0;
                while ((line = reader.ReadLine()) != null && (i < Cmaxsize))
                {
                    string[] parts;
                    parts = line.Split(';');
                    country = parts[0];
                    money = double.Parse(parts[1]);
                    conversion = double.Parse(parts[2]);
                    p[i++] = new Person(country, money, conversion);
                    number++;
                }
            }
        }

        static void Print(string header, Person[] p, int number)
        {
            Console.WriteLine("\t\t      " + header);
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("| Country Name | Money in local currency | Conversion rate to euro |");
            Console.WriteLine("--------------------------------------------------------------------");
            for (int i = 0; i < number; i++)
            {
                Console.WriteLine("|   {0, 10} |     {1, 19:f2} | {2, 23:f3} |",
                p[i].GetCountry(),
                p[i].GetMoney(),
                p[i].GetConversionRate());
            }
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine();
        }

        public static double CalculateSum(Person[] p, int number)
        {
            double sum = 0;
            for (int i = 0; i < number; i++)
            {
                sum += p[i].GetMoneyEuro();
            }
            return sum;
        }

        static void PrintToTexFile(string file, string header, Person[] p, int number, double sum)
        {
            using (StreamWriter writer = new StreamWriter(file))
            {
                
                writer.WriteLine("\t\t  " + header);
                writer.WriteLine("----------------------------------------");
                writer.WriteLine("|   Country Name   |   Money in euro   |");
                writer.WriteLine("----------------------------------------");
                for (int i = 0; i < number; i++)
                {
                    writer.WriteLine("| {0, 14}   | {1, 17:f2} |", 
                        p[i].GetCountry(),
                        p[i].GetMoneyEuro(),
                    sum);
                }
                writer.WriteLine("----------------------------------------");
                writer.WriteLine("|          Total money in euro         |");
                writer.WriteLine("----------------------------------------");
                writer.WriteLine("| {0, 28:f2}         |", sum);
                writer.Write("----------------------------------------");
            }
        }


        static void Main(string[] args)
        {
            Person[] p1 = new Person[Cmaxsize];
            Person[] p2 = new Person[Cmaxsize];
            int number1;
            int number2;
            Read(CFd1, p1, out number1);
            Print("Initial Data for John", p1, number1);

            Read(CFd2, p2, out number2);
            Print("Initial Data for Mary", p2, number2);

            double sum;
            sum = CalculateSum(p1, number1);
            PrintToTexFile(CJohnResults, "Ouput Data for John", p1, number1, sum);

            sum = CalculateSum(p2, number2);
            PrintToTexFile(CMaryResults, "Ouput Data for Mary", p2, number2, sum);
        }
    }
