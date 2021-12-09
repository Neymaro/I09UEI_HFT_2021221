using Moq;
using NUnit.Framework;
using I09UEI_HFT_2021221.Logic;
using I09UEI_HFT_2021221.Models;
using I09UEI_HFT_2021221.Repository;
using I09UEI_HFT_2021221.Data;
using System.Linq;

namespace I09UEI_HFT_2021221.Test
{
    [TestFixture]
    public class NonCrudTests
    {
        private readonly TravelAgencyDbContext _dbContext;
        public NonCrudTests()
        {
            _dbContext = new TravelAgencyDbContext(DbContextHelper.GetInMemoryOptions());
        }

        [Test]
        public void GetCustomers_WithPhoneNumber_Success()
        {
            // Arrange

            var customerRepo = new CustomerRepository(_dbContext);
            var customerLogic = new CustomerLogic(customerRepo);
            var travelAgencyId = 4;
            var phoneNumberBeginning = "2";

            // Act
            var customers = customerLogic.GetCustomersStartsWithPhoneNumber(travelAgencyId, phoneNumberBeginning);

            // Assert
            var condition = customers
                .Select(x => x.Phone.ToString())
                .All(x => x.StartsWith(phoneNumberBeginning));

            Assert.True(condition);
            Assert.IsNotEmpty(customers);
            Assert.AreEqual(2, customers.Count);
        }

        [Test]

        public void GetCustomers_WithPhoneNumber_MaxLenght()
        {
            //Arrange

            var customerRepo = new CustomerRepository(_dbContext);
            var customerLogic = new CustomerLogic(customerRepo);
            var travelAgencyId = 1;
            var phoneNumberMaxLength = 7;

            //Act
            var customers = customerLogic.GetCustomersWithPhoneNumberMaxLength(travelAgencyId, phoneNumberMaxLength);

            //Assert
            var condition = customers
                .Select(x => x.Phone.ToString())
                .All(x => x.Length <= phoneNumberMaxLength);

            Assert.True(condition);
            Assert.IsNotEmpty(customers);
            Assert.AreEqual(1, customers.Count);

        }

        [Test]

        public void GetPackages_WithCategory_Success()
        {
            var packageRepo = new PackageRepository(_dbContext);
            var packageLogic = new PackageLogic(packageRepo);
            var travelAgencyIds = new int[3] { 3, 4, 5 };
            var category = "Summer";

            //Act
            var packages = packageLogic.GetPackagesWithCategory(travelAgencyIds, "Summer");

            //Assert
            var condition = packages
                .Select(x => x.Category)
                .All(x => x.Equals(category));

            Assert.True(condition);

            var travelAgencyCondition = packages
                .Select(x => x.TravelAgencyId)
                .All(x => travelAgencyIds.Contains(x));

            Assert.True(travelAgencyCondition);
            Assert.IsNotEmpty(packages);
            Assert.AreEqual(1, packages.Count);
        }

        [Test] 

        public void GetPackages_VisaNeeded_Success()
        {
            var packageRepo = new PackageRepository(_dbContext);
            var packageLogic = new PackageLogic(packageRepo);
            var travelAgencyId = 1;

            //Act
            var packages = packageLogic.GetPackagesVisaNeeded(travelAgencyId, true);

            //Assert
            var condition = packages
                .Select(x => x.VisaNeeded)
                .All(x => x is true);

            Assert.True(condition);

            var travelAgencyCondition = packages
                .Select(x => x.TravelAgencyId)
                .All(x => x == travelAgencyId);

            Assert.True(travelAgencyCondition);
            Assert.IsNotEmpty(packages);
            Assert.AreEqual(1, packages.Count);
        }

        [Test]

        public void GetPackages_AbovePrice_Success()
        {
            var packageRepo = new PackageRepository(_dbContext);
            var packageLogic = new PackageLogic(packageRepo);
            var travelAgencyId = 1;

            //Act
            var packages = packageLogic.GetPackagesAbovePrice(travelAgencyId, 2000);

            //Assert
            var condition = packages
                .Select(x => x.Price)
                .All(x => x >= 2000);

            Assert.True(condition);

            var travelAgencyCondition = packages
                .Select(x => x.TravelAgencyId)
                .All(x => x == travelAgencyId);

            Assert.True(travelAgencyCondition);
            Assert.IsNotEmpty(packages);
            Assert.AreEqual(1, packages.Count);
        }

        [Test]

        public void GetCustomersOfTravelAgency_Multi_Query()
        {
            var customerRepo = new CustomerRepository(_dbContext);
            var customerLogic = new CustomerLogic(customerRepo);

            var customers = customerLogic.GetCustomersOfTravelAgency("tui");
            var condition = customers
                .Select(x => x.Name)
                .All(x => x == "Adam Smith");

            Assert.True(condition);
            Assert.AreEqual("Adam Smith", customers);
        }
    }
}
