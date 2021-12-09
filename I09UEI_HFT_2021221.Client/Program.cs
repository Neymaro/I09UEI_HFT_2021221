using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using ConsoleTools;
using I09UEI_HFT_2021221.Models;
using I09UEI_HFT_2021221.Models.Dtos;

namespace I09UEI_HFT_2021221.Client
{
    class Program
    {
        private static readonly JsonSerializerOptions JsonOptions = new() { PropertyNameCaseInsensitive = true };

        static void Main(string[] args)
        {
            var menu = new ConsoleMenu(args, level: 0)
               .Add("GetAll Customers", async () => await GetAllCustomersAsync())
               .Add("Create Customer", async () => await PostCustomerAsync())
               .Add("Update Customer", async () => await PutCustomerAsync())
               .Add("Delete Customer", async () => await DeleteCustomerAsync())
               .Add("Get GetPackagesVisaNeeded", async () => await GetPackagesVisaNeeded())
               .Add("Get GetPackagesAbovePrice", async () => await GetPackagesAbovePrice())
               .Add("Get GetPackagesWithCategory", async () => await GetPackagesWithCategory())
               .Configure(config =>
               {
                   config.Selector = "---> ";
                   config.EnableFilter = true;
                   config.Title = "--- Main Menu ---";
                   config.EnableBreadcrumb = true;
               });

            menu.Show();
        }

        private static async Task GetAllCustomersAsync()
        {
            var content = await CustomHttpClient.GetRequestAsync("/customers/all");

            var allCustomers = JsonSerializer.Deserialize<List<Customer>>(content, JsonOptions);

            Console.WriteLine("----");
            foreach (var customer in allCustomers)
            {
                Console.WriteLine(customer.Id);
                Console.WriteLine(customer.Name);
                Console.WriteLine(customer.Phone);
                Console.WriteLine(customer.TravelAgencyId);
                Console.WriteLine();
            }
            Console.WriteLine("----");
        }

        private static async Task GetPackagesWithCategory()
        {
            var dto = new PackagesWithCategoryPostDto(new List<int>() { 1, 2, 3, 4, 5, 6, 7 }, "Summer");

            string jsonContent = JsonSerializer.Serialize(dto);
            var response = await CustomHttpClient.PostRequestAsync("/packages/GetPackagesWithCategory", jsonContent);

            var packages = JsonSerializer.Deserialize<List<Package>>(response, JsonOptions);

            foreach (var package in packages)
            {
                Console.WriteLine(package.Id);
                Console.WriteLine(package.Name);
                Console.WriteLine(package.Category);
                Console.WriteLine(package.Price);
                Console.WriteLine(package.Description);
                Console.WriteLine(package.TravelAgencyId);
                Console.WriteLine();
            }
        }

        private static async Task GetPackagesVisaNeeded()
        {
            int travelAgencyId = 3;
            bool visaNeeded = false;
            var queryString = $"?travelAgencyId={travelAgencyId}&visaNeeded={visaNeeded}";
            string requestUri = $"/packages/GetPackagesVisaNeeded{queryString}";

            var content = await CustomHttpClient.GetRequestAsync(requestUri);

            var packages = JsonSerializer.Deserialize<List<Package>>(content, JsonOptions);

            foreach (var package in packages)
            {
                Console.WriteLine(package.Id);
                Console.WriteLine(package.Name);
                Console.WriteLine(package.Category);
                Console.WriteLine(package.Price);
                Console.WriteLine(package.Description);
                Console.WriteLine(package.TravelAgencyId);
                Console.WriteLine();
            }
        }

        private static async Task GetPackagesAbovePrice()
        {
            int travelAgencyId = 5;
            int price = 100;
            var queryString = $"?travelAgencyId={travelAgencyId}&price={price}";
            string requestUri = $"/packages/GetPackagesAbovePrice{queryString}";

            var content = await CustomHttpClient.GetRequestAsync(requestUri);

            var packages = JsonSerializer.Deserialize<List<Package>>(content, JsonOptions);

            Console.WriteLine("----");
            foreach (var package in packages)
            {
                Console.WriteLine(package.Id);
                Console.WriteLine(package.Name);
                Console.WriteLine(package.Category);
                Console.WriteLine(package.Price);
                Console.WriteLine(package.Description);
                Console.WriteLine(package.TravelAgencyId);
                Console.WriteLine();
            }
            Console.WriteLine("----");
        }

        private static async Task PostCustomerAsync()
        {
            var dto = new CustomerPostDto()
            {
                CustomerName = "Customer1",
                Phone = 12345,
                TravelAgencyId = 3
            };

            string jsonContent = JsonSerializer.Serialize(dto);
            var response = await CustomHttpClient.PostRequestAsync("/customers", jsonContent);

            var createdCustomer = JsonSerializer.Deserialize<Customer>(response, JsonOptions);

            Console.WriteLine(createdCustomer.Id);
            Console.WriteLine(createdCustomer.Name);
            Console.WriteLine(createdCustomer.Phone);
            Console.WriteLine(createdCustomer.TravelAgencyId);
        }

        private static async Task PutCustomerAsync()
        {
            var dto = new CustomerPutDto()
            {
                Id = 1,
                CustomerName = "Changed Name",
                PhoneNumber = 11111111
            };

            string jsonContent = JsonSerializer.Serialize(dto);
            var response = await CustomHttpClient.PutRequestAsync("/customers", jsonContent);

            var createdCustomer = JsonSerializer.Deserialize<Customer>(response, JsonOptions);

            Console.WriteLine(createdCustomer.Id);
            Console.WriteLine(createdCustomer.Name);
            Console.WriteLine(createdCustomer.Phone);
            Console.WriteLine(createdCustomer.TravelAgencyId);
        }

        private static async Task DeleteCustomerAsync()
        {
            int id = 3;
            var statusCode = await CustomHttpClient.DeleteRequestAsync($"/customers/{id}");

            Console.WriteLine($"Delete status code : {statusCode}");
        }

    }
}
