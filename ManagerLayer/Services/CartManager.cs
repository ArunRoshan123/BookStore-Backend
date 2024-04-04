using CommonLayer.RequestModel;
using ManagerLayer.Interfaces;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Services
{
    public class CartManager:ICartManager
    {
        private readonly ICartRepository repository;
        public CartManager(ICartRepository repository)
        {
            this.repository = repository;
        }
        public CartEntity CartAdd(CartModel model, int Id)
        {
            return repository.CartAdd(model, Id);
        }
        public List<CartEntity> GetAllCart(int id)
        {
            return repository.GetAllCart(id);
        }
        public CartEntity CartUpdate(int id, int bookid, int update)
        {
            return repository.CartUpdate(id, bookid, update);
        }
        public CartEntity CartDelete(int id, int cartid)
        {
            return repository.CartDelete(id, cartid);
        }
        public CartEntity IsPurchase(int bookid, int cartid, int userid)
        {
            return repository.IsPurchase(bookid, cartid, userid);
        }
    }
}
