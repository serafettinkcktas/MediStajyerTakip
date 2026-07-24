namespace Domain.Entity;

public class Mentor
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public Guid ProfileId { get; set; }
    public string? Department { get; set; }  // Yazılım, Yapay Zeka vb. (belki bunun icin de ayri bir tablo tutabiliriz )
}



