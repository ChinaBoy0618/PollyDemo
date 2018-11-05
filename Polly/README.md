# PollyDemo
Polly 支持的机制
* 1.Retry 重试机制 （多次、永远、按照时间间隔重试等）
* 2.Circuit-breaker 熔断
* 3.timeout 超时
* 4.Bulkhead Isolation 隔离（下游得系统异常可能会影响上游得系统）
* 5.Cache 缓存
* 6.Fallback 回路（对于预知异常得处理）
* 7.PolicyWrap 策略（对于不同异常适配得异常处理）