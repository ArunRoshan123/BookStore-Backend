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
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext context;

        public BookRepository(BookStoreContext context)
        {
            this.context = context;
        }
        public BookEntity AddBook(BookModel model)
        {
            BookEntity entity = new BookEntity();
            entity.Book_Name = model.Book_Name;
            entity.Description = model.Description;
            entity.Author = model.Author;
            entity.Book_Image = model.Book_Image;
            entity.Price = model.Price;
            entity.Discount_Price = model.Discount_Price;
            entity.Quantity = model.Quantity;
            entity.Rating = model.Rating;
            entity.CreatedAt = model.CreatedAt;
            entity.UpdatedAt = model.UpdatedAt;
            context.BookTable.Add(entity);
            context.SaveChanges();
            return entity;
        }
        public List<BookEntity> GetAll()
        {
            return context.BookTable.ToList();
        }
        public List<BookEntity> GeyById(int id)
        {
            return context.BookTable.Where(x => x.Book_Id == id).ToList();
        }
        public List<BookEntity> SortPriceAsc()
        {
            return context.BookTable.OrderBy(x => x.Price).ToList();
        }
        public List<BookEntity> SortPriceDesc()
        {
            return context.BookTable.OrderByDescending(x => x.Price).ToList();
        }
        public List<BookEntity> SortArrivalAsc()
        {
            return context.BookTable.OrderBy(x => x.CreatedAt).ToList();
        }
        public List<BookEntity> SortArrivalDesc()
        {
            return context.BookTable.OrderByDescending(x => x.CreatedAt).ToList();
        }
        public List<BookEntity> GetBySearch(string author, string bookname)
        {
            /* return context.BookTable.Where(x => x.Author == author || x.Book_Name == bookname).ToList();*/
            return context.BookTable.Where(x => x.Author.Contains(author) || x.Book_Name.Contains(bookname)).ToList();
        }
    }
}
