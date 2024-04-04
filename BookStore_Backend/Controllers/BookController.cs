using CommonLayer.RequestModel;
using CommonLayer.ResponseModel;
using ManagerLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;
using System.Collections.Generic;
using System;

namespace BookStore_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookManager manager;

        public BookController(IBookManager manager)
        {
            this.manager = manager;
        }

        [Authorize]
        [HttpPost]
        [Route("AddBook")]

        public ActionResult AddBook(BookModel model)
        {
            try
            {

                int id = Convert.ToInt32(User.FindFirst("userId").Value);
                var response = manager.AddBook(model);
                if (response != null)
                {
                    return Ok(new ResModel<BookEntity> { Success = true, Message = "Creation Success", Data = response });
                }
                else
                {
                    return BadRequest(new ResModel<BookEntity> { Success = false, Message = "Creation Failed", Data = response });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<BookEntity> { Success = false, Message = ex.Message, Data = null });
            }
        }

        [Authorize]
        [HttpGet]
        [Route("GetAllBooks")]

        public ActionResult GetAll()
        {
            try
            {
                int id = Convert.ToInt32(User.FindFirst("userId").Value);
                List<BookEntity> response = manager.GetAll();
                if (response != null)
                {
                    return Ok(new ResModel<List<BookEntity>> { Success = true, Message = "Get All Books Passed", Data = response });
                }
                else
                {
                    return BadRequest(new ResModel<List<BookEntity>> { Success = false, Message = "Get All Books Failed", Data = response });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<List<BookEntity>> { Success = false, Message = ex.Message, Data = null });
            }
        }

        [Authorize]
        [HttpGet]
        [Route("GetBookById")]
        public ActionResult GetByID(int id)
        {
            try
            {
                List<BookEntity> response = manager.GeyById(id);
                if (response != null)
                {
                    return Ok(new ResModel<List<BookEntity>> { Success = true, Message = "Get Book By Id Passed", Data = response });
                }
                else
                {
                    return BadRequest(new ResModel<List<BookEntity>> { Success = false, Message = "Get Book By Id Failed", Data = response });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<List<BookEntity>> { Success = false, Message = ex.Message, Data = null });
            }
        }


        [Authorize]
        [HttpGet]
        [Route("SortPriceAsc")]
        public ActionResult SortPriceAsc()
        {
            try
            {
                var response = manager.SortPriceAsc();
                if (response != null)
                {

                    return Ok(new ResModel<List<BookEntity>> { Success = true, Message = "Sort Price Asc Success", Data = response });

                }
                else
                {

                    return BadRequest(new ResModel<List<BookEntity>> { Success = false, Message = "Sort Price Asc Failed", Data = response });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(new ResModel<List<BookEntity>> { Success = false, Message = ex.Message, Data = null });
            }
        }

        [Authorize]
        [HttpGet]
        [Route("SortPriceDesc")]
        public ActionResult SortPriceDesc()
        {
            try
            {
                var response = manager.SortPriceDesc();
                if (response != null)
                {

                    return Ok(new ResModel<List<BookEntity>> { Success = true, Message = "Sort Price Desc Success", Data = response });

                }
                else
                {

                    return BadRequest(new ResModel<List<BookEntity>> { Success = false, Message = "Sort Price Desc Failed", Data = response });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(new ResModel<List<BookEntity>> { Success = false, Message = ex.Message, Data = null });
            }
        }
        [Authorize]
        [HttpGet]
        [Route("SortArrivalAsc")]
        public ActionResult SortArrivalAsc()
        {
            try
            {
                var response = manager.SortArrivalAsc();
                if (response != null)
                {

                    return Ok(new ResModel<List<BookEntity>> { Success = true, Message = "Sort Arrival Asc Success", Data = response });

                }
                else
                {

                    return BadRequest(new ResModel<List<BookEntity>> { Success = false, Message = "Sort Arrival Desc Failed", Data = response });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(new ResModel<List<BookEntity>> { Success = false, Message = ex.Message, Data = null });
            }
        }
        [Authorize]
        [HttpGet]
        [Route("SortArrivalDesc")]
        public ActionResult SortArrivalDesc()
        {
            try
            {
                var response = manager.SortArrivalDesc();
                if (response != null)
                {

                    return Ok(new ResModel<List<BookEntity>> { Success = true, Message = "Sort Arrival Desc Success", Data = response });

                }
                else
                {

                    return BadRequest(new ResModel<List<BookEntity>> { Success = false, Message = "Sort Arrival Desc Failed", Data = response });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(new ResModel<List<BookEntity>> { Success = false, Message = ex.Message, Data = null });
            }
        }

        [Authorize]
        [HttpGet]
        [Route("GetBySearch")]
        public ActionResult GetBySearch(string author, string bookname)
        {
            try
            {
                var response = manager.GetBySearch(author, bookname);
                if (response != null)
                {

                    return Ok(new ResModel<List<BookEntity>> { Success = true, Message = "Search by author or book name Success", Data = response });

                }
                else
                {

                    return BadRequest(new ResModel<List<BookEntity>> { Success = false, Message = "Search by author or book name Failed", Data = response });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<List<BookEntity>> { Success = false, Message = "Search by author or book name Failed", Data = null });
            }
        }
    }
}
