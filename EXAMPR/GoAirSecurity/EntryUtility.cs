using System;
namespace GoAirSecurity;

public class EntryUtility
{
    public void validateEmployeeId(String employeeId)
    {
        if(employeeId.Length != 10)
        {
            throw new InvalidEntryException("Invalid entry details");
        }
        if (!employeeId.StartsWith("GOAIR"))
        {
            throw new InvalidEntryException("Invalid entry details");
        }
        if(employeeId[5] != '/')
        {
            throw new InvalidEntryException("Invalid entry details");
        }
        for(int i = 6; i < 10; i++)
        {
            if (!char.IsDigit(employeeId[i]))
            {
                throw new InvalidEntryException("invalid entry details");
            }
        }
    }

    public void validateDuration(int duration)
    {
        if(duration < 1 || duration > 5)
        {
            throw new InvalidEntryException("invalid entry details");
        }
    }
}