using System;

namespace RobotHazard;

public class RobotSafetyException : Exception
{
    public RobotSafetyException(string msg) : base(msg)
    {
        
    }
}