﻿using Application.Repositories;

namespace Application
{
    public interface IUnitOfWork
    {
        public IOrderRepository OrderRepository { get; }
        public IUserRepository UserRepository { get; }
        public Task<int> SaveChangeAsync();
    }
}
