using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.RequestModel
{
    public class ForgotPasswordModel
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
