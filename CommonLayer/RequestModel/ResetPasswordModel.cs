using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.RequestModel
{
    public class ResetPasswordModel
    {
        public string newPassword { get; set; }
        public string confirmPassword { get; set; }
    }
}
