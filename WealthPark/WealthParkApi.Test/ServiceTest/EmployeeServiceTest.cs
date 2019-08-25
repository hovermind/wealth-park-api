using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WealthParkApi.Domain;
using WealthParkApi.Domain.Entities;
using WealthParkApi.Filters;
using WealthParkApi.Models;
using WealthParkApi.Services;
using WealthParkApi.Utils;
using Xunit;

namespace WealthParkApi.Test.ServiceTest
{
    public class EmployeeServiceTest
    {
        [Fact]
        public void GetEmployeesTest()
        {
            // arrange
            var mockRepo = new Mock<IEmployeeRepository>();
            var mockAutoMapper = new Mock<IMapper>();
            mockRepo.Setup(x => x.GetAll(It.IsAny<EmployeeSearchModel>(), It.IsAny<List<SearchFieldMutator<Employee, EmployeeSearchModel>>>())).Returns(DBSeeder.GetDummyEmployeeList());
            mockRepo.Setup(x => x.GetAll(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<EmployeeSearchModel>(), It.IsAny<List<SearchFieldMutator<Employee, EmployeeSearchModel>>>())).Returns(DBSeeder.GetDummyEmployeeList());
            mockAutoMapper.Setup(y => y.Map<List<EmployeeDto>>(It.IsAny<IEnumerable<Employee>>())).Returns(new List<EmployeeDto> { new EmployeeDto() });
            var sut = new EmployeeService(mockRepo.Object, mockAutoMapper.Object);

            // act
            var employeeList = sut.GetEmployees(1, new EmployeeSearchModel { FirstName = "Foo", LastName = "Bar" });

            // assert
            Assert.NotNull(employeeList);
            Assert.NotEmpty(employeeList);
            Assert.Single(employeeList);
        }

        [Fact]
        public void GetEmployeeTest()
        {
            // arrange
            var mockRepo = new Mock<IEmployeeRepository>();
            var mockAutoMapper = new Mock<IMapper>();
            mockRepo.Setup(x => x.Get(It.IsAny<long>())).Returns(new Employee { FirstName = "Foo", LastName = "Bar" }); ;
            mockAutoMapper.Setup(y => y.Map<EmployeeDto>(It.IsAny<Employee>())).Returns(new EmployeeDto { FullName = "Foo Bar" });
            var sut = new EmployeeService(mockRepo.Object, mockAutoMapper.Object);

            // act
            var employee = sut.GetEmployee(1);

            // assert
            Assert.NotNull(employee);
            Assert.Equal("Foo Bar", employee.FullName);
        }

        [Fact]
        public void CreateEmployeeTest()
        {
            // arrange
            var mockRepo = new Mock<IEmployeeRepository>();
            var mockAutoMapper = new Mock<IMapper>();
            mockAutoMapper.Setup(y => y.Map<Employee>(It.IsAny<CreateEmployeeDto>())).Returns(new Employee { FirstName = "Foo" });
            mockRepo.Setup(x => x.Add(It.IsAny<Employee>())).Returns(222);
            var sut = new EmployeeService(mockRepo.Object, mockAutoMapper.Object);

            // act
            var employeeId = sut.CreateEmployee(new CreateEmployeeDto { FirstName = "Foo" });

            // assert
            Assert.Equal(222, employeeId);
        }

        [Fact]
        public void UpdateEmployeeTest()
        {
            // arrange
            var mockRepo = new Mock<IEmployeeRepository>();
            var mockAutoMapper = new Mock<IMapper>();
            mockRepo.Setup(x => x.Get(It.IsAny<long>())).Returns(new Employee { FirstName = "Foo" });
            //mockAutoMapper.Setup(y => y.Map<Employee>(It.IsAny<Employee>()));
            //mockRepo.Setup(x => x.Update(It.IsAny<Employee>()));
            mockAutoMapper.Setup(y => y.Map<EmployeeDto>(It.IsAny<Employee>())).Returns(new EmployeeDto { FullName = "Foo Baz" });
            var sut = new EmployeeService(mockRepo.Object, mockAutoMapper.Object);

            // act
            var employee = sut.UpdateEmployee(222, new UpdateEmployeeDto { FirstName = "Foo", LastName = "Baz" });

            // assert
            Assert.NotNull(employee);
            Assert.Equal("Foo Baz", employee.FullName);
        }
    }
}
