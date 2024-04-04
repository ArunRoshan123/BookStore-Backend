using CommonLayer.RequestModel;
using ManagerLayer.Interfaces;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Services
{
    public class BookManager:IBookManager
    {
        private readonly IBookRepository repository;

        public BookManager(IBookRepository repository)
        {
            this.repository = repository;
        }
        public BookEntity AddBook(BookModel model)
        {
            return repository.AddBook(model);
        }
        public List<BookEntity> GetAll()
        {
            return repository.GetAll();
        }
        public List<BookEntity> GeyById(int id)
        {
            return repository.GeyById(id);
        }
        public List<BookEntity> SortPriceAsc()
        {
            return repository.SortPriceAsc();
        }
        public List<BookEntity> SortPriceDesc()
        {
            return repository.SortPriceDesc();
        }
        public List<BookEntity> SortArrivalAsc()
        {
            return repository.SortArrivalAsc();
        }
        public List<BookEntity> SortArrivalDesc()
        {
            return repository.SortArrivalDesc();
        }
        public List<BookEntity> GetBySearch(string author, string bookname)
        {
            return repository.GetBySearch(author, bookname);
        }
    }
}
