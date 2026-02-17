using System;
namespace ConstructionEstimate;

public class Program
{
    public EstimateDetails ValidateConstructionEstimate(float constructionArea, float siteArea)
    {
        if(constructionArea > siteArea)
            throw new ConstructionEstimateException("Sorry your Construction Estimate is not approved.");
        else
            return new EstimateDetails
            {
                ConstructionArea = constructionArea,
                SiteArea = siteArea
            };
    }

    public static void Main()
    {
        Program p = new Program();

        Console.Write("Enter Construction Area: ");
        float cArea = float.Parse(Console.ReadLine());

        Console.Write("Enter Site Area: ");
        float sArea = float.Parse(Console.ReadLine());

        try
        {
            EstimateDetails ed = p.ValidateConstructionEstimate(cArea, sArea);
            Console.WriteLine("Construction Estimate Approved");
        }
        catch (ConstructionEstimateException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}