using System;
using Abp;

namespace WeChat.Common.Exceptions
{
    [Serializable]
    public class SignatureInvalidException : AbpException
    {
        public SignatureInvalidException()
        {
        }

        public SignatureInvalidException(string message) : base(message)
        {
        }
    }
}