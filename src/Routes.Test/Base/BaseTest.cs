using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Routes.Core.Interfaces;

namespace Routes.Test.Base
{
    public class BaseTest
    {
        protected readonly Mock<IRepository> _repository = new Mock<IRepository>();
    }
}
