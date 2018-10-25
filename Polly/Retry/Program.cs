using System;
using Polly;

namespace PollyDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.Handle Exception
            Policy
            .Handle<Exception>();

            //2.重试3次
            Policy
            .Handle<Exception>()
            .Retry(3);

            //3.按照不同时间间隔重试
            Policy
            .Handle<Exception>()
            .WaitAndRetry(new [] {
                TimeSpan.FromSeconds(1),
                TimeSpan.FromSeconds(2),
                TimeSpan.FromSeconds(3)}
            );
            //4.永远重试
            Policy
          .Handle<Exception>()//这里可以根据不同的异常进行过滤，确认是否要执行后面的操作
          .RetryForever(exception =>
          {
              // do something       
          });
        }
    }
}
