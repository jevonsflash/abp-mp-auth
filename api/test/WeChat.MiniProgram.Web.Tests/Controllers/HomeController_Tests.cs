﻿using System.Threading.Tasks;
using WeChat.MiniProgram.Models.TokenAuth;
using WeChat.MiniProgram.Web.Controllers;
using Shouldly;
using Xunit;

namespace WeChat.MiniProgram.Web.Tests.Controllers
{
    public class HomeController_Tests: MiniProgramWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}