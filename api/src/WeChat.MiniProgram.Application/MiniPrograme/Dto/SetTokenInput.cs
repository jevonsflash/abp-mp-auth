﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChat.MiniProgram.MiniPrograme.Dto
{
    public class SetTokenInput
    {
        public string Token { get; set; }
        public string Status { get; set; }
        public string ProviderAccessCode { get; set; }
        public bool IsCheckToken { get; set; } = true;
    }
}
