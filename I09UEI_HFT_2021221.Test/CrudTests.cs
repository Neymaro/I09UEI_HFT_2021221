using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I09UEI_HFT_2021221.Test
{
    [TestFixture]
    public class CrudTests
    {
        //[Test]
        //public void TestCreateAdopter()
        //{
        //    Mock<IAdopterRepository> mockedAdopterRepo = new Mock<IAdopterRepository>(MockBehavior.Loose);
        //    AdopterLogic adopterLogic = new AdopterLogic(mockedAdopterRepo.Object);
        //    mockedAdopterRepo.Setup(repo => repo.Insert(It.IsAny<Adopter>()));
        //    adopterLogic.InsertNewAdopter("Teszt Elek", "Csudapest", "Main street 42.", false);
        //    // verifies that the test adopter object has been added, and only once
        //    mockedAdopterRepo.Verify(repo => repo.Insert(It.IsAny<Adopter>()), Times.Once);
        //}

        //[Test]
        //public void TestCreateAnimal()
        //{
        //    Mock<IAnimalRepository> mockedAnimalRepo = new Mock<IAnimalRepository>(MockBehavior.Loose);
        //    AnimalLogic animalLogic = new AnimalLogic(mockedAnimalRepo.Object);
        //    mockedAnimalRepo.Setup(repo => repo.Insert(It.IsAny<Animal>()));
        //    animalLogic.InsertNewAnimal("Fluffy", "female", "gatto", "smoll", 1);
        //    // verifies that the test animal object has been added, and only once
        //    mockedAnimalRepo.Verify(repo => repo.Insert(It.IsAny<Animal>()), Times.Once);
        //}

        //[Test]
        //public void TestCreateShelter()
        //{
        //    Mock<IShelterRepository> mockedShelterRepo = new Mock<IShelterRepository>(MockBehavior.Loose);
        //    ShelterLogic shelterLogic = new ShelterLogic(mockedShelterRepo.Object);
        //    mockedShelterRepo.Setup(repo => repo.Insert(It.IsAny<Shelter>()));
        //    shelterLogic.InsertNewShelter("Homeless Kitty Network", "Csudapest", "Other Street 19.");
        //    // verifies that the test shelter object has been added, and only once
        //    mockedShelterRepo.Verify(repo => repo.Insert(It.IsAny<Shelter>()), Times.Once);
        //}

        //[Test]
        //public void TestDeleteAnimal()
        //{
        //    Mock<IAnimalRepository> mockedAnimalRepo = new Mock<IAnimalRepository>(MockBehavior.Loose);

        //    List<Animal> testAnimals = new List<Animal>()
        //    {
        //        new Animal() { Id = 1, Name = "Bob", Gender = "male", Specie = "dog", Bodysize = "average", Age = 3, ShelterId = 1, AdopterId = 2 },
        //        new Animal() { Id = 2, Name = "Luna", Gender = "female", Specie = "cat", Bodysize = "fat", Age = 7, ShelterId = 3, AdopterId = 5 },
        //        new Animal() { Id = 3, Name = "Rex", Gender = "male", Specie = "dog", Bodysize = "small", Age = 1, ShelterId = 1, AdopterId = 4 },
        //    };

        //    mockedAnimalRepo.Setup(repo => repo.GimmeAll()).Returns(testAnimals.AsQueryable());
        //    mockedAnimalRepo.Setup(repo => repo.GimmeOne(It.IsAny<int>())).Returns((int i) => testAnimals.Where(x => x.Id == i).Single());
        //    mockedAnimalRepo.Setup(repo => repo.Delete(It.IsAny<int>()));

        //    AnimalLogic animalLogic = new AnimalLogic(mockedAnimalRepo.Object);
        //    animalLogic.DeleteAnimal(2);
        //    mockedAnimalRepo.Verify(repo => repo.Delete(2));

        //}

        //[Test]
        //public void TestChangeAdopterAddress()
        //{
        //    Mock<IAdopterRepository> mockedAdopterRepo = new Mock<IAdopterRepository>(MockBehavior.Loose);

        //    List<Adopter> testAdopters = new List<Adopter>()
        //    {
        //        new Adopter() { Id = 1, Name = "John Doe", City="Kiskunfélegyháza", Address="Petőfi Sándor utca 5.", HasKid=true},
        //        new Adopter() { Id = 2, Name = "Béla Béla", City="Vác", Address="Fő út 37.", HasKid=false},
        //    };

        //    mockedAdopterRepo.Setup(repo => repo.GimmeAll()).Returns(testAdopters.AsQueryable());
        //    mockedAdopterRepo.Setup(x => x.GimmeOne(It.IsAny<int>())).Returns((int i) => testAdopters.Where(x => x.Id == i).Single());

        //    AdopterLogic adopterLogic = new AdopterLogic(mockedAdopterRepo.Object);

        //    adopterLogic.ChangeAdopterAddress(1, "Szeged", "Kötő utca 2.");
        //    mockedAdopterRepo.Verify(repo => repo.ChangeAddress(1, "Szeged", "Kötő utca 2."), Times.Once);
        //}

    }
}
