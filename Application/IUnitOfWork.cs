﻿using Application.Repositories;

namespace Application
{
    public interface IUnitOfWork
    {
        public IOrderRepository OrderRepository { get; }
        public IOrderDetailRepository OrderDetailRepository { get; }
        public IUserRepository UserRepository { get; }
        public IPaymentRepository PaymentRepository { get; }
        public IShipCompanyRepository ShipCompanyRepository { get; }
        public IShipperRepository ShipperRepository { get; }
        public IAddressToShipRepository AddressToShipRepository { get; }
        public IAddressUserRepository AddressUserRepository { get; }
        public IVoucherRepository VoucherRepository { get; }
        public IVoucherUsageRepository VoucherUsageRepository { get; }
        public IPostRepository PostRepository { get; }

        public IProductRepository ProductRepository { get; }

        public IImageRepository ImageRepository { get; }

        public IProductMaterialRepository ProductMaterialRepository { get; }
        public ICommentRepository CommentRepository { get; }
        public IFeedbackRepository FeedbackRepository { get; }
        public Task<int> SaveChangeAsync();
    }
}
