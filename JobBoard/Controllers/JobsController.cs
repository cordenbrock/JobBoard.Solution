using Microsoft.AspNetCore.Mvc;
using JobBoard.Models;
using System.Collections.Generic;

namespace JobBoard.Controllers
{
  public class JobsController : Controller
  {
    [HttpGet("/jobs")]
    public ActionResult Index()
    {
      List<Job> allJobs = Job.GetAll();
      return View(allJobs);
    }

    [HttpGet("/jobs/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/jobs")]
    public ActionResult Create(string title, string description, string contact)
    {
      Job newJob = new Job(title, description, contact);
      return RedirectToAction("Index");
    }

    [HttpPost("/jobs/delete")]
    public ActionResult DeleteAll()
    {
      Job.ClearAll();
      return RedirectToAction("Index");
    }

    [HttpGet("/jobs/{id}")]
    public ActionResult Show(int id)
    {
      Job foundJob = Job.Find(id);
      return View(foundJob);
    }

    [HttpPost("/jobs/{id}")]
    public ActionResult Destroy(int id)
    {
      Job foundJob = Job.Find(id);
      Job.DeleteJob(foundJob.Id);
      return RedirectToAction("Index");
    }
  }
}