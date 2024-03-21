using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using Net.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrderWebApi.Test
{
    public class BaseControllerTest<T> where T : class
    {
        protected Mock<IMediator> _mediatRMock;
        protected Mock<ILogger<T>> _loggerMock;
        protected IMapper _mapper;

        public BaseControllerTest()
        {
            _loggerMock = new Mock<ILogger<T>>();
            _mediatRMock = new Mock<IMediator>();

            var myProfile = new MapperProfiles();
            var configuration = new MapperConfiguration(cfg =>
                cfg.AddProfile(myProfile));
            _mapper = new Mapper(configuration);
        }

    }
}
