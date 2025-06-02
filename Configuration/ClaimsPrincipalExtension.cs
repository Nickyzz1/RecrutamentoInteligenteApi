using System.Security.Claims;

namespace Api.Configuration;

public static class ClaimsPrincipalExtension
{
    public static int Id(this ClaimsPrincipal claims)
    {
        Claim? claim = claims.FindFirst("Id");
        if(claim == null)
        {
            return -1;
        }


        if(int.TryParse(claim.Value, out int Id))
        {
            return Id;
        }

        return -1;
    }

    public static bool Admin(this ClaimsPrincipal claims)
    {
        Claim? claim = claims.FindFirst("Admin");
        if(claim == null)
        {
            return false;
        }

        if(bool.TryParse(claim.Value, out bool Admin))
        {
            return Admin;
        }

        return false;
    }

    public static string Name(this ClaimsPrincipal claims)
    {
        Claim? claim = claims.FindFirst("Name");
        if(claim == null)
        {
            return "";
        }

        return claim.Value;
    }
}