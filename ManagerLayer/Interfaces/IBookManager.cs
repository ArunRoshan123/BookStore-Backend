using CommonLayer.RequestModel;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Interfaces
{
    public interface IBookManager
    {
        public BookEntity AddBook(BookModel model);
        public List<BookEntity> GetAll();
        public List<BookEntity> GeyById(int id);
        public List<BookEntity> SortPriceAsc();
        public List<BookEntity> SortPriceDesc();
        public List<BookEntity> SortArrivalAsc();
        public List<BookEntity> SortArrivalDesc();
        public List<BookEntity> GetBySearch(string author, string bookname);
    }
}
