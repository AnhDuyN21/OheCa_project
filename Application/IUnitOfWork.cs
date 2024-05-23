﻿using Application.Repositories;

namespace Application
{
    public interface IUnitOfWork
    {
        public IOrderRepository OrderRepository { get; }
        public IOrderDetailRepository OrderDetailRepository { get; }
        public Task<int> SaveChangeAsync();
    }
}
