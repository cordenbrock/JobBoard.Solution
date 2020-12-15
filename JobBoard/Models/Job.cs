using System.Collections.Generic;

namespace JobBoard.Models
{
  public class Job
  {
    public string Title { get; set; }
    public int Id { get; }
    private static List<Job> _instances = new List<Job> { };

    public Job(string title)
    {
      Title = title;
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
  }
}