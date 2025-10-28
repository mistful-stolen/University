namespace Program {
    class MyProgramXDD 
    {
        static void Main(string[] args) 
        {
            Car ferrari = new Car();
            Person joe = new Person();
            Snail pixie = new Snail();

            Console.WriteLine(pixie.speed);


            
        }

        class Person {
            public string skinColor = "black";
        }
    }

    class Snail {
        public string speed = "slow";
    }
}