using CommonLayer.RequestModel;
using CommonLayer.ResponseModel;
using ManagerLayer.Interfaces;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using System.Threading.Tasks;
using System;

namespace BookStore_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager userManager;
        private readonly BookStoreContext context1;
        private readonly IBus bus;
        public UserController(IUserManager userManager, BookStoreContext context, IBus bus)
        {
            this.userManager = userManager;
            this.context1 = context;
            this.bus = bus;
        }

        [HttpPost]
        [Route("Reg")]
        public ActionResult Register(RegisterModel model)
        {
            /*hi my name is arun*/
            try
            {
                var response = userManager.UserRegisteration(model);
                if (response != null)
                {
                    return Ok(new ResModel<UserEntity> { Success = true, Message = "register successfull", Data = response });
                }
                else
                {
                    return BadRequest(new ResModel<UserEntity> { Success = false, Message = "register failed", Data = response });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new ResModel<UserEntity> { Success = false, Message = e.Message, Data = null });
            }
        }

        /*User login*/

        [HttpPost]
        [Route("Log")]
        public ActionResult Login(LoginModel model)
        {
            try
            {
                string response = userManager.UserLogin(model);
                if (response != null)
                {
                    return Ok(new ResModel<string> { Success = true, Message = "Login sucessfull", Data = response });
                }
                else
                {
                    return BadRequest(new ResModel<string> { Success = false, Message = "Login failed", Data = response });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<string> { Success = false, Message = ex.Message, Data = null });
            }
        }

        [HttpPost]
        [Route("ForgotPassword")]
        public async Task<ActionResult> ForgotPassword(string Email)
        {

            try
            {
                if (userManager.CheckEmail(Email))
                {
                    Send mail = new Send();
                    ForgotPasswordModel model = userManager.ForgotPassword(Email);
                    string str = mail.SendMail(model.Email, model.Token);
                    Uri uri = new Uri("rabbitmq://localhost/FunfooNotesEmailQueue");
                    var endPoint = await bus.GetSendEndpoint(uri);
                    await endPoint.Send(model);
                    return Ok(new ResModel<string> { Success = true, Message = str, Data = model.Token });
                }
                else
                {
                    throw new Exception("Failed to send email");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<string> { Success = false, Message = ex.Message, Data = null });
            }
        }

        [HttpPost]
        [Authorize]
        [Route("ResetPassword")]
        public ActionResult ResetPassword(ResetPasswordModel reset)
        {
            string Email = User.FindFirst("Email").Value;
            if (userManager.ResetPassword(Email, reset))
            {
                return Ok(new ResModel<bool> { Success = true, Message = "Password changed", Data = true });
            }
            else
            {
                return BadRequest(new ResModel<bool> { Success = false, Message = "Password is not changed", Data = false });
            }
        }
    }
}
