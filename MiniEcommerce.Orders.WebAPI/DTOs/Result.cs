﻿namespace MiniEcommerce.Orders.WebAPI.DTOs
{
    public sealed class Result<T>
    {
        public Result()
        {
        }

        public Result(T data)
        {
          Data=data;
        }
        public T? Data { get; set; } = default!;
    }
}
