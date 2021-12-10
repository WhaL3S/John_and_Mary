class Person
    {
        private string country;
        private double money;
        private double conversionRate;

        public Person(string country, double money, double conversionRate)
        {
            this.country = country;
            this.money = money;
            this.conversionRate = conversionRate;
        }

        public string GetCountry()        { return country;                }
        public double GetMoney()          { return money;                  }
        public double GetConversionRate() { return conversionRate;         }
        public double GetMoneyEuro()      { return money * conversionRate; }
    }
