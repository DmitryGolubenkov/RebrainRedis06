using StackExchange.Redis;

var key = args[0];
var redis = ConnectionMultiplexer.Connect("localhost:6379");
var db = redis.GetDatabase();

while (true)
{
    var value = Console.ReadLine();
    if (value == null)
    {
        break;
    }

    if (await db.ListLengthAsync(key) >= 20)
    {
        await db.ListLeftPopAsync(key);
        Console.WriteLine("Removed old value");

    }
    await db.ListRightPushAsync(key, value);
    Console.WriteLine("Added new value");
}

