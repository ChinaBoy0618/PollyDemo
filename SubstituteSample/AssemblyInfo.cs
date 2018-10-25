using StackExchange.Redis;
using Substitute;
using SubstituteSample;

[assembly: Substitute(typeof(IDatabase), typeof(MyRedisDatabase))]