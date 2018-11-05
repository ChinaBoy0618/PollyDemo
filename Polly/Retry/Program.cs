using System;
using System.Threading;
using Polly;

namespace PollyDemo
{
	class Program
	{
		static void Main(string[] args)
		{
			Retry();
			CircuitBreaker();
		}

		static void Retry()
		{
			//1.Handle Exception
			var p = Policy
			.Handle<Exception>()
			.Retry();

			p.Execute(() =>
			{
				Console.WriteLine("执行一次");
				throw new Exception("test");
			});

			//2.重试3次
			p = Policy
			.Handle<Exception>()
			.Retry(3);

			var context = new Context();
			context.Add("index", 0);
			p.Execute((c) =>
			{
				Console.WriteLine("执行" + c["index"] + "次");
				c["index"] = Convert.ToInt32(c["index"]) + 1;
				throw new Exception("test");
			}, context);

			//3.按照不同时间间隔重试
			p = Policy
			.Handle<Exception>()
			.WaitAndRetry(new[] {
				TimeSpan.FromSeconds(1),
				TimeSpan.FromSeconds(2),
				TimeSpan.FromSeconds(3)}
			);

			p.Execute(() =>
			{
				Console.WriteLine("执行一次" + DateTime.Now);
				throw new Exception("test");
			});

			//4.永远重试
			p = Policy
		  .Handle<Exception>()//这里可以根据不同的异常进行过滤，确认是否要执行后面的操作
		  .RetryForever(exception =>
		  {
			  // do something       
		  });
			p.Execute(() =>
			{
				Console.WriteLine("执行一次" + DateTime.Now);
				throw new Exception("test");
			});
		}

		static void CircuitBreaker()
		{
			//一分钟内连续2次 异常则熔断
			var p = Policy
					.Handle<Exception>()
					.CircuitBreaker(8, TimeSpan.FromSeconds(10));

			while (true)
			{
				try
				{
					p.Execute(() =>
					{
						Console.WriteLine("Job Start");
						throw new Exception("Special error occured");
						Console.WriteLine("Job End");
					});
				}
				catch (Exception ex)
				{
					Console.WriteLine("There's one unhandled exception : " + ex.Message);
				}

				Thread.Sleep(500);
			}

		}


	}
}
