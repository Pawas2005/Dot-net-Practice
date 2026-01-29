using System;

namespace XamXpert;

public interface Exam
{
    double calculateScore();
    static string evaluateResult(double percentage)
    {
        if(percentage >= 85)
            return "Merit";
        else if(percentage >= 60 && percentage < 85)
            return "Pass";
        else
            return "Fail";
    }
}