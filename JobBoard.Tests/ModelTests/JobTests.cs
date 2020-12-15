using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using JobBoard.Models;
using System;

namespace JobBoard.Tests
{
  [TestClass]
  public class JobTest : IDisposable
  {

    public void Dispose()
    {
      Job.ClearAll();
    }

    [TestMethod]
    public void JobConstructor_CreatesInstanceOfJob_Job()
    {
      Job newJob = new Job("test");
      Assert.AreEqual(typeof(Job), newJob.GetType());
    }

    [TestMethod]
    public void GetTitle_ReturnsTitle_String()
    {
      //Arrange
      string title = "Walk the dog.";

      //Act
      Job newJob = new Job(title);
      string result = newJob.Title;

      //Assert
      Assert.AreEqual(title, result);
    }

    [TestMethod]
    public void SetTitle_SetTitle_String()
    {
      //Arrange
      string title = "Walk the dog.";
      Job newJob = new Job(title);

      //Act
      string updatedTitle = "Do the dishes";
      newJob.Title = updatedTitle;
      string result = newJob.Title;

      //Assert
      Assert.AreEqual(updatedTitle, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_JobList()
    {
      // Arrange
      List<Job> newList = new List<Job> { };

      // Act
      List<Job> result = Job.GetAll();

      // Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsJobs_JobList()
    {
      //Arrange
      string title01 = "Walk the dog";
      string title02 = "Wash the dishes";
      Job newJob1 = new Job(title01);
      Job newJob2 = new Job(title02);
      List<Job> newList = new List<Job> { newJob1, newJob2 };

      //Act
      List<Job> result = Job.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetId_JobsInstantiateWithAnIdAndGetterReturns_Int()
    {
      //Arrange
      string title = "Walk the dog.";
      Job newJob = new Job(title);

      //Act
      int result = newJob.Id;

      //Assert
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectJob_Job()
    {
      //Arrange
      string title01 = "Walk the dog";
      string title02 = "Wash the dishes";
      Job newJob1 = new Job(title01);
      Job newJob2 = new Job(title02);

      //Act
      Job result = Job.Find(2);

      //Assert
      Assert.AreEqual(newJob2, result);
    }
  }
}