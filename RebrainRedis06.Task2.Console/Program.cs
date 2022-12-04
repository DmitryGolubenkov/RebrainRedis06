using StackExchange.Redis;

var key = args[0];
var limit = int.Parse(args[1]);

var redis = ConnectionMultiplexer.Connect("localhost:6379");
var db = redis.GetDatabase();

for(int i = 0; i < limit; i++)
{
    Console.WriteLine(await db.ListLeftPopAsync(key));
}