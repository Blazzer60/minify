using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Minify.Controllers;
using Minify.Interfaces;
using Minify.Model;
using Xunit;
using Moq;

namespace Minify.Tests
{
    public class MinifyControllerDoit
    {
        [Fact]
        public void AddData()
        {
            Mock<IRepository> bdd = new Mock<IRepository>();
            MinifyController minifyController = new MinifyController(bdd.Object);

            var data = new MinifyData
            {
                _id = null,
                Key = null,
                Url = "https://www.twitch.tv"
            };

            minifyController.Add(data);
            
            bdd.Verify(f => f.Add(It.IsAny<MinifyData>()));
            bdd.Verify(f => f.Add(It.Is<MinifyData>(
                e => e.Url == "https://www.twitch.tv")));
            
        }

        [Fact]
        public void GetData()
        {
            Mock<IRepository> bdd = new Mock<IRepository>();
            MinifyController minifyController = new MinifyController(bdd.Object);

            List<MinifyData> datas = new List<MinifyData>();
            
            datas.Add(new MinifyData
            {
                _id = null,
                Key = null,
                Url = "https://twitch.tv"
            });

            bdd.Setup(f => f.Get())
                .Returns(datas);
            
            var result = minifyController.Get();
            
            Assert.Equal(datas, result);
        }
        
        [Fact]
        public void DeleteData()
        {
            Mock<IRepository> bdd = new Mock<IRepository>();
            MinifyController minifyController = new MinifyController(bdd.Object);

            string id = "77947636-b77f-4d36-83f3-213d45cad18c";
            
            minifyController.Delete(id);
            
            bdd.Verify(f => f.Delete(It.IsAny<string>()));
            bdd.Verify(f => f.Delete(It.Is<string>(
                e => id == "77947636-b77f-4d36-83f3-213d45cad18c")));
        }
    }
}