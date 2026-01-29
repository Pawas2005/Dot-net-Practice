using System;

namespace XamXpert;

public class OnlineTest : Exam
{
    private string studentName { get; set; }
    private int totalQuestions { get; set; }
    private int correctAnswers { get; set; }
    private int wrongAnswers { get; set; }
    private string questionType { get; set; }

    public OnlineTest(string studentName, int totalQuestions, int correctAnswers, int wrongAnswers, string questionType)
    {
        this.studentName = studentName;
        this.totalQuestions = totalQuestions;
        this.correctAnswers = correctAnswers;
        this.wrongAnswers = wrongAnswers;
        this.questionType = questionType;
    }

    public double calculateScore()
    {
        int marksPerQues = 0;

        if(questionType.Equals("MCQ", StringComparison.OrdinalIgnoreCase))
            marksPerQues = 2;
        else if(questionType.Equals("Coding", StringComparison.OrdinalIgnoreCase))
            marksPerQues = 5;

        double totalScore = (correctAnswers * marksPerQues) - (wrongAnswers * marksPerQues * 0.10);

        double percentage = (totalScore / (totalQuestions * marksPerQues)) * 100;

        return percentage;
    }
}