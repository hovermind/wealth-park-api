using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WealthParkApi.Domain;
using WealthParkApi.Domain.Entities;
using WealthParkApi.Filters;
using WealthParkApi.Models;
using WealthParkApi.Repositories;
using WealthParkApi.Utils;
using Xunit;

namespace WealthParkApi.Test.RepositoryTest
{
    public class EmployeeRepositoryTest : IDisposable, IClassFixture<EmployeeRepositoryTestFixture>
    {
        private readonly EmployeeRepositoryTestFixture _fixure;

        public EmployeeRepositoryTest(EmployeeRepositoryTestFixture fixure)
        {
            _fixure = fixure;
        }

        public void Dispose()
        {

        }

        public static IEnumerable<object[]> GetTestDataForGetAllWithoutPagingTest()
        {
            var searchModel = new EmployeeSearchModel() { FirstName = "Foo", LastName = "Bar" };
            var searchFieldMutators = new List<SearchFieldMutator<Employee, EmployeeSearchModel>>();
            searchFieldMutators.Add(new SearchFieldMutator<Employee, EmployeeSearchModel>(search => true, (query, search) => query.Where(e => e.FirstName.Contains(search.FirstName))));
            searchFieldMutators.Add(new SearchFieldMutator<Employee, EmployeeSearchModel>(search => true, (query, search) => query.Where(e => e.LastName.Contains(search.LastName))));
            yield return new object[] { searchModel, searchFieldMutators, 1 };


            var searchFieldMutators2 = new List<SearchFieldMutator<Employee, EmployeeSearchModel>>();
            yield return new object[] { searchModel, searchFieldMutators2, DBSeeder.GetDummyEmployeeList().Count };
        }

        [Theory]
        [MemberData(nameof(GetTestDataForGetAllWithoutPagingTest))]
        public void GetAllWithoutPagingTest(EmployeeSearchModel searchModel, List<SearchFieldMutator<Employee, EmployeeSearchModel>> searchFieldMutators, int resultCount)
        {
            using (var context = new EmployeeDbContext(_fixure.DbContextOptions))
            {
                context.Database.OpenConnection();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                // arrange
                if (!context.Employees.Any())
                {
                    context.AddRange(DBSeeder.GetDummyEmployeeList());
                    context.SaveChanges();
                }
                var employeeRepository = new EmployeeRepository(context);

                // act
                var employees = employeeRepository.GetAll(searchModel, searchFieldMutators)?.ToList();

                // assert
                Assert.NotNull(employees);
                Assert.NotEmpty(employees);
                Assert.Equal(resultCount, employees.Count);
            }

        }


        public static IEnumerable<object[]> GetTestDataForGetAllWithPagingTest()
        {
            var searchModel = new EmployeeSearchModel() { FirstName = "Foo", LastName = "Bar" };
            var searchFieldMutators = new List<SearchFieldMutator<Employee, EmployeeSearchModel>>();
            yield return new object[] { 1, searchModel, searchFieldMutators, AppConstants.PageSize };

            var searchFieldMutators2 = new List<SearchFieldMutator<Employee, EmployeeSearchModel>>();
            searchFieldMutators2.Add(new SearchFieldMutator<Employee, EmployeeSearchModel>(search => true, (query, search) => query.Where(e => e.FirstName.Contains(search.FirstName))));
            searchFieldMutators2.Add(new SearchFieldMutator<Employee, EmployeeSearchModel>(search => true, (query, search) => query.Where(e => e.LastName.Contains(search.LastName))));

            yield return new object[] { 1, searchModel, searchFieldMutators2, 1 };
        }

        [Theory]
        [MemberData(nameof(GetTestDataForGetAllWithPagingTest))]
        public void GetAllWithPagingTest(int page, EmployeeSearchModel searchModel, List<SearchFieldMutator<Employee, EmployeeSearchModel>> searchFieldMutators, int resultCount)
        {
            using (var context = new EmployeeDbContext(_fixure.DbContextOptions))
            {
                context.Database.OpenConnection();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                // arrange
                if (!context.Employees.Any())
                {
                    context.AddRange(DBSeeder.GetDummyEmployeeList());
                    context.SaveChanges();
                }
                var employeeRepository = new EmployeeRepository(context);
                var skipSize = AppConstants.PageSize * (page - 1);
                var takeSize = AppConstants.PageSize;

                // act
                var employees = employeeRepository.GetAll(skipSize, takeSize, searchModel, searchFieldMutators)?.ToList();

                // assert
                Assert.NotNull(employees);
                Assert.NotEmpty(employees);
                Assert.Equal(resultCount, employees.Count);
            }
        }

        [Fact]
        public void AddTest()
        {
            using (var context = new EmployeeDbContext(_fixure.DbContextOptions))
            {
                context.Database.OpenConnection();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                // arrange
                var employeeRepository = new EmployeeRepository(context);
                var employeeToAdd = new Employee { FirstName = "AAA", LastName = "BBB", Boss = "boss 1", Address = "address 1", DateOfBirth = DateTime.Today.AddDays(-1), Salary = 1_000_000.0 };

                // act
                var employeeId = employeeRepository.Add(employeeToAdd);

                // assert
                Assert.NotNull(employeeRepository.Get(employeeId));
            }
        }

        [Fact]
        public void UpdateTest()
        {
            using (var context = new EmployeeDbContext(_fixure.DbContextOptions))
            {
                context.Database.OpenConnection();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                // arrange
                var employeeRepository = new EmployeeRepository(context);
                var employeeToAdd = new Employee { FirstName = "Foo", LastName = "Bar", Boss = "boss 1", Address = "address 1", DateOfBirth = DateTime.Today.AddDays(-1), Salary = 1_000_000.0 };
                var employeeId = employeeRepository.Add(employeeToAdd);
                var employeeToUpdate = employeeRepository.Get(employeeId);
                employeeToUpdate.LastName = "Baz";
                employeeRepository.Update(employeeToUpdate);

                // act
                var updatedEmployee = employeeRepository.Get(employeeId);

                // assert
                Assert.Equal("Baz", updatedEmployee.LastName);
            }
        }

        [Fact]
        public void DeleteTest()
        {
            using (var context = new EmployeeDbContext(_fixure.DbContextOptions))
            {
                context.Database.OpenConnection();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                // arrange
                var employeeRepository = new EmployeeRepository(context);
                var employeeToAdd = new Employee { FirstName = "aaa", LastName = "bbb", Boss = "boss 1", Address = "address 1", DateOfBirth = DateTime.Today.AddDays(-1), Salary = 1_000_000.0 };
                var employeeId = employeeRepository.Add(employeeToAdd);
                var employeeToDelete = employeeRepository.Get(employeeId);
                employeeRepository.Delete(employeeToDelete);

                // act
                var deletedEmployee = employeeRepository.Get(employeeId);

                // assert
                Assert.Null(deletedEmployee);
            }
        }
    }
}
