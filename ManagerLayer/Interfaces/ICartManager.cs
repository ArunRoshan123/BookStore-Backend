using CommonLayer.RequestModel;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Interfaces
{
    public interface ICartManager
    {
        public CartEntity CartAdd(CartModel model, int Id);
        public List<CartEntity> GetAllCart(int id);
        public CartEntity CartUpdate(int id, int bookid, int update);
        public CartEntity CartDelete(int id, int cartid);
        public CartEntity IsPurchase(int bookid, int cartid, int userid);
    }
}
