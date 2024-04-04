using CommonLayer.RequestModel;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class CartRepository : ICartRepository
    {
        private readonly BookStoreContext context;
        public CartRepository(BookStoreContext context)
        {
            this.context = context;
        }
        public CartEntity CartAdd(CartModel model, int Id)
        {
            CartEntity entity = new CartEntity();
            entity.Cart_Quantity = model.Cart_Quantity;
            entity.UserId = Id;
            entity.Book_Id = model.Book_Id;
            context.CartTable.Add(entity);
            context.SaveChanges();
            return entity;
        }
        public List<CartEntity> GetAllCart(int id)
        {
            return context.CartTable.Where(x => x.UserId == id).ToList();
        }
        public CartEntity CartUpdate(int id, int bookid, int update)
        {
            var cart = context.CartTable.FirstOrDefault(x => x.UserId == id && x.Book_Id == bookid);
            if (cart != null)
            {
                var book = context.BookTable.FirstOrDefault(x => x.Book_Id == bookid);
                if (update == 1)
                {
                    if (book != null && book.Quantity > cart.Cart_Quantity)
                    {
                        context.CartTable.Add(cart);
                        context.SaveChanges();
                        return cart;
                    }
                    else
                    {
                        throw new Exception("Product out of stock");
                    }
                }
                else
                {
                    if (book != null && cart.Cart_Quantity > 1)
                    {
                        cart.Cart_Quantity -= 1;
                        context.SaveChanges();
                        return cart;
                    }
                    else
                    {
                        throw new Exception("minimum");
                    }
                }
            }
            else
            {
                throw new Exception("product not added to cart");
            }
        }
        public CartEntity CartDelete(int id, int cartid)
        {
            var cart = context.CartTable.FirstOrDefault(x => x.UserId == id && x.Cart_Id == cartid);
            if (cart != null)
            {
                context.CartTable.Remove(cart);
                context.SaveChanges();
                return cart;
            }
            else
            {
                throw new Exception("cart is already empty");
            }
        }
        public CartEntity IsPurchase(int bookid, int cartid, int userid)
        {
            var cart = context.CartTable.FirstOrDefault(x => x.Book_Id == bookid && x.Cart_Id == cartid && x.UserId == userid);
            if (cart != null)
            {
                if (cart.IsPurchase)
                {
                    cart.IsPurchase = false;
                }
                else
                {
                    cart.IsPurchase = true;
                }
                context.SaveChanges();
                return cart;
            }
            else
            {
                throw new Exception("Is purchase failed");
            }
        }

    }
}
