using System;
using StackExchange.Redis;
namespace SubstituteSample
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
           // Console.WriteLine("Hello World!");
            IDatabase db = redis.GetDatabase();
            db.StringSet("haha", "lala");
            db.StringSet("haha1", "lala");
            db.StringSet("haha2", "lala");
            Console.WriteLine($"haha vaule:{ db.StringGet("haha")}");
            Console.WriteLine($"haha1 vaule:{ db.StringGet("haha1")}");
            Console.WriteLine($"haha2 vaule:{ db.StringGet("haha2")}");
            Console.ReadKey();
        }
    }
}
