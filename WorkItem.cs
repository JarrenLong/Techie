namespace LongTech.Techie
{
  public class WorkItem
  {
    public int Id { get; set; }
    public string JobId { get; set; }
    public int JobStatus { get; set; }
    public string JobDescription { get; set; }
    public decimal JobPays { get; set; }
    public string ClientId { get; set; }
    public string ClientName { get; set; }
    public string ClientAddress { get; set; }
    public string ClientPhone { get; set; }
    public string ClientEmail { get; set; }
  }
}
