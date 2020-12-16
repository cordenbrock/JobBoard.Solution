using System.Collections.Generic;

namespace JobBoard.Models
{
  public class Job
  {
    public string Title { get; set; }
    public string Description { get; set; }
    public string Contact { get; set; }
    public int Id { get; }
    private static List<Job> _instances = new List<Job> { };

    public Job(string title, string description, string contact)
    {
      Title = title;
      Description = description;
      Contact = contact;
      _instances.Add(this);
      Id = _instances.Count;
    }

    public static List<Job> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Job Find(int searchId)
    {
      return _instances[searchId - 1];
    }

    public static void DeleteJob(int id)
    {
      _instances.RemoveAll(r => r.Id == id);
    }


  }
}