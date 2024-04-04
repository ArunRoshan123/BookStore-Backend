using CommonLayer.RequestModel;
using CommonLayer.ResponseModel;
using ManagerLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;
using System.Collections.Generic;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Net;

namespace BookStore_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private ICartManager manager;
        public CartController(ICartManager manager)
        {
            this.manager = manager;
        }

        [Authorize]
        [HttpPost]
        [Route("CartAdd")]
        public ActionResult CartAdd(CartModel model)
        {
            try
            {

                int id = Convert.ToInt32(User.FindFirst("userId").Value);
                var response = manager.CartAdd(model, id);
                if (response != null)
                {
                    return Ok(new ResModel<CartEntity> { Success = true, Message = "Creation Success", Data = response });
                }
                else
                {
                    return BadRequest(new ResModel<CartEntity> { Success = false, Message = "Creation Failed", Data = response });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<CartEntity> { Success = false, Message = ex.Message, Data = null });
            }
        }

        [Authorize]
        [HttpGet]
        [Route("GetAllCart")]
        public ActionResult GetAllCart()
        {
            try
            {

                int id = Convert.ToInt32(User.FindFirst("userId").Value);
                List<CartEntity> response = manager.GetAllCart(id);
                if (response != null)
                {
                    return Ok(new ResModel<List<CartEntity>> { Success = true, Message = "Get All Cart Success", Data = response });
                }
                else
                {
                    return BadRequest(new ResModel<List<CartEntity>> { Success = false, Message = "Get All Cart Failed", Data = response });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<CartEntity> { Success = false, Message = ex.Message, Data = null });
            }
        }

        [Authorize]
        [HttpPut]
        [Route("CartUpdate")]
        public ActionResult CartUpdate(int bookid,int update)
        {
            try
            {
                int id = Convert.ToInt32(User.FindFirst("userId").Value);
                var response = manager.CartUpdate(id, bookid, update);
                if (response != null)
                {
                    return Ok(new ResModel<CartEntity> { Success = true, Message = "Update Cart Success", Data = response });
                }
                else
                {
                    return BadRequest(new ResModel<CartEntity> { Success = false, Message = "Update Cart Failed", Data = response });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<CartEntity> { Success = false, Message = ex.Message, Data = null });
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("CartDelete")]
        public ActionResult CartDelete(int cartid)
        {
            try
            {
                int id = Convert.ToInt32(User.FindFirst("userId").Value);
                var response = manager.CartDelete(id, cartid);
                if (response != null)
                {
                    return Ok(new ResModel<CartEntity> { Success = true, Message = "Delete Cart Success", Data = response });
                }
                else
                {
                    return BadRequest(new ResModel<CartEntity> { Success = false, Message = "Delete Cart Failed", Data = response });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<CartEntity> { Success = false, Message = ex.Message, Data = null });
            }
        }

        [Authorize]
        [HttpPost]
        [Route("IsPurchase")]

        public  ActionResult IsPurchase(int bookid, int cartid, int userid)
        {
            try
            {
                var response = manager.IsPurchase(bookid, cartid, userid);
                if (response != null)
                {
                    return Ok(new ResModel<CartEntity> { Success = true, Message = "Purchase Success", Data = response });
                }
                else
                {
                    return BadRequest(new ResModel<CartEntity> { Success = false, Message = "Purchase Failed", Data = response });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<CartEntity> { Success = false, Message = ex.Message, Data = null });
            }
        }
    }
}
