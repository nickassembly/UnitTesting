using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using DemoLibrary;
using DemoLibrary.Models;

namespace DemoLibrary.Tests
{
   public class DataAccessTests
   {
      [Fact]
      public void AddPersonToPeopleList_ShouldWork()
      {
         // Arrange
         PersonModel newPerson = new PersonModel { FirstName = "Nick", LastName = "Keller" };
         List<PersonModel> people = new List<PersonModel>();

         // Act
         DataAccess.AddPersonToPeopleList(people, newPerson);

         // Assert
         Assert.True(people.Count == 1);

         Assert.Contains<PersonModel>(newPerson, people);
      }

      [Theory]
      [InlineData("Nick","", "LastName")]
      [InlineData("","Keller", "FirstName")]
      public void AddPersonToPeopleList_ShouldFail(string firstName, string lastName, string param)
      {
         // Arrange
         PersonModel newPerson = new PersonModel { FirstName = firstName, LastName = lastName };
         List<PersonModel> people = new List<PersonModel>();

         // Assert
         Assert.Throws<ArgumentException>(param, () => DataAccess.AddPersonToPeopleList(people, newPerson));

      }

      [Fact]
      public void ConvertModelsToCSV_ShouldWork()
      {
         // Arrange
         PersonModel person1 = new PersonModel { FirstName = "Nick", LastName = "Keller" };
         PersonModel person2 = new PersonModel { FirstName = "John", LastName = "Smith" };

         List<PersonModel> people = new List<PersonModel>();
         List<string> peopleCsv = new List<string>();

         people.Add(person1);
         people.Add(person2);

         // Act
        peopleCsv = DataAccess.ConvertModelsToCSV(people);

         foreach (var person in peopleCsv)
         {
            Assert.IsType<string>(person);
         }
     
         // Assert


      }


   }
}
