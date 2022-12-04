using StackExchange.Redis;

var key = args[0];
var limit = int.Parse(args[1]);

var redis = ConnectionMultiplexer.Connect("localhost:6379");
var db = redis.GetDatabase();

if (db.KeyExists(key))
{
    foreach(var value in await db.ListLeftPopAsync(key, 20))
    {
        Console.WriteLine(value);
    }
}