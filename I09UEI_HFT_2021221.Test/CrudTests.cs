﻿using Moq;
using NUnit.Framework;
using I09UEI_HFT_2021221.Logic;
using I09UEI_HFT_2021221.Models;
using I09UEI_HFT_2021221.Repository;
using I09UEI_HFT_2021221.Data;

namespace I09UEI_HFT_2021221.Test
{
    [TestFixture]
    public class CrudTests
    {
        // naming convention [UnitOfWork_StateUnderTest_ExpectedBehavior]
        // The AAA (Arrange, Act, Assert) pattern is a common way of writing unit tests for a method under test. 
        // https://docs.microsoft.com/en-us/visualstudio/test/unit-test-basics?view=vs-2022

        [Test]
        public void GetCustomer_Success()
        {
            // Arrange
            var mockedCustomerRepo = new Mock<ICustomerRepository>();
            var customerLogic = new CustomerLogic(mockedCustomerRepo.Object);
            mockedCustomerRepo.Setup(repo => repo.Get(It.IsAny<int>()));

            // Act
            customerLogic.GetCustomer(123);

            // Assert
            mockedCustomerRepo.Verify(repo => repo.Get(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void Delete_Customer_Success()
        {
            // Arrange
            var mockedCustomerRepo = new Mock<ICustomerRepository>();
            var customerLogic = new CustomerLogic(mockedCustomerRepo.Object);
            mockedCustomerRepo.Setup(repo => repo.Delete(It.IsAny<int>()));
            mockedCustomerRepo
                .Setup(repo => repo.Get(It.IsAny<int>()))
                .Returns(new Customer() { Id = 123, Name = "Test", Phone = 12345 });

            // Act
            customerLogic.DeleteCustomer(123);

            // Assert
            mockedCustomerRepo.Verify(repo => repo.Delete(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void CreateCustomer_Success()
        {
            // Arrange
            var mockedCustomerRepo = new Mock<ICustomerRepository>();
            var customerLogic = new CustomerLogic(mockedCustomerRepo.Object);
            mockedCustomerRepo.Setup(repo => repo.Insert(It.IsAny<Customer>()));

            // Act
            customerLogic.AddNew("David", 565542);

            // Assert
            mockedCustomerRepo.Verify(repo => repo.Insert(It.IsAny<Customer>()), Times.Once);
        }

        [Test]
        public void CreateCustomer_TooLongName_ShouldFail()
        {
            // Arrange
            var mockedCustomerRepo = new Mock<ICustomerRepository>();
            var customerLogic = new CustomerLogic(mockedCustomerRepo.Object);
            mockedCustomerRepo.Setup(repo => repo.Insert(It.IsAny<Customer>()));

            // Act
            string customerName = new('x', TravelAgencyDbContext.NameMaxLength + 1);
            customerLogic.AddNew(customerName, 565542);

            // Assert
            mockedCustomerRepo.Verify(repo => repo.Insert(It.IsAny<Customer>()), Times.Once);
        }

        [Test]
        public void GetPackage_Success()
        {
            // Arrange
            var mockedPackageRepo = new Mock<IPackageRepository>();
            var packageLogic = new PackageLogic(mockedPackageRepo.Object);
            mockedPackageRepo.Setup(repo => repo.Get(It.IsAny<int>()));

            // Act
            packageLogic.GetOnePackage(123);

            // Assert
            mockedPackageRepo.Verify(repo => repo.Get(It.IsAny<int>()), Times.Once);
        }


        [Test]
        public void Delete_Package_Success()
        {
            // Arrange
            var mockedPackageRepo = new Mock<IPackageRepository>();
            var PackageLogic = new PackageLogic(mockedPackageRepo.Object);
            mockedPackageRepo.Setup(repo => repo.Delete(It.IsAny<int>()));
            mockedPackageRepo
                .Setup(repo => repo.Get(It.IsAny<int>()))
                .Returns(new Package()
                {
                    Id = 123,
                    Name = "Test",
                    Description = "description",
                    Price = 1234,
                    VisaNeeded = false,
                    Category = "testCategory"
                });

            // Act
            PackageLogic.DeletePackage(123);

            // Assert
            mockedPackageRepo.Verify(repo => repo.Delete(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void CreatePackage_Success()
        {
            // Arrange
            var mockedPackageRepo = new Mock<IPackageRepository>();
            var packageLogic = new PackageLogic(mockedPackageRepo.Object);
            mockedPackageRepo.Setup(repo => repo.Insert(It.IsAny<Package>()));

            // Act
            packageLogic.AddNewPackage("David", "culture", 123, true, "description");

            // Assert
            mockedPackageRepo.Verify(repo => repo.Insert(It.IsAny<Package>()), Times.Once);
        }

        [Test]
        public void CreatePackage_TooLongPrice_ShouldFail()
        {
            // Arrange
            var mockedPackageRepo = new Mock<IPackageRepository>();
            var packageLogic = new PackageLogic(mockedPackageRepo.Object);
            mockedPackageRepo.Setup(repo => repo.Insert(It.IsAny<Package>()));

            // Act
            packageLogic.AddNewPackage("David", "culture", 123456789, true, "description");

            // Assert
            mockedPackageRepo.Verify(repo => repo.Insert(It.IsAny<Package>()), Times.Once);
        }

        [Test]
        public void GetTravelAgency_Success()
        {
            // Arrange
            var mockedTravelAgencyRepo = new Mock<ITravelAgencyRepository>();
            var travelAgencyLogic = new TravelAgencyLogic(mockedTravelAgencyRepo.Object);
            mockedTravelAgencyRepo.Setup(repo => repo.Get(It.IsAny<int>()));

            // Act
            travelAgencyLogic.GetOneAgency(123);

            // Assert
            mockedTravelAgencyRepo.Verify(repo => repo.Get(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void Delete_TravelAgency_Success()
        {
            // Arrange
            var mockedTravelAgencyRepo = new Mock<ITravelAgencyRepository>();
            var TravelAgencyLogic = new TravelAgencyLogic(mockedTravelAgencyRepo.Object);
            mockedTravelAgencyRepo.Setup(repo => repo.Delete(It.IsAny<int>()));
            mockedTravelAgencyRepo
                .Setup(repo => repo.Get(It.IsAny<int>()))
                .Returns(new TravelAgency()
                {
                    Id = 123,
                    Name = "Test",
                    Rating = 5
                });

            // Act
            TravelAgencyLogic.DeleteAgency(123);

            // Assert
            mockedTravelAgencyRepo.Verify(repo => repo.Delete(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void CreateTravelAgency_Success()
        {
            // Arrange
            var mockedTravelAgencyRepo = new Mock<ITravelAgencyRepository>();
            var travelAgencyLogic = new TravelAgencyLogic(mockedTravelAgencyRepo.Object);
            mockedTravelAgencyRepo.Setup(repo => repo.Insert(It.IsAny<TravelAgency>()));

            // Act
            travelAgencyLogic.AddNewTravelAgency("Guven Ajans", 1);

            // Assert
            mockedTravelAgencyRepo.Verify(repo => repo.Insert(It.IsAny<TravelAgency>()), Times.Once);
        }

        [Test]
        public void CreateTravelAgency_TooLongPoint_ShouldFail()
        {
            // Arrange
            var mockedTravelAgencyRepo = new Mock<ITravelAgencyRepository>();
            var travelAgencyLogic = new TravelAgencyLogic(mockedTravelAgencyRepo.Object);
            mockedTravelAgencyRepo.Setup(repo => repo.Insert(It.IsAny<TravelAgency>()));

            // Act
            travelAgencyLogic.AddNewTravelAgency("David", 16);

            // Assert
            mockedTravelAgencyRepo.Verify(repo => repo.Insert(It.IsAny<TravelAgency>()), Times.Once);
        }
    }
}
