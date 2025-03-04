namespace CloseApproach.Api.Models;

public class Asteroid
{
    public int Id { get; set; }
    public double Diameter { get; set; }
    public CloseApproachData CloseApproach { get; set; }
    public bool IsHazardous
    {
        get
        {
            if (Diameter > 140.0 && CloseApproach.LunarDistance <= 20.0)
            {
                return true;
            }

            return false;
        }
    }
}
