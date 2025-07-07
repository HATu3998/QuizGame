using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    //da tra loi bao nhieu cau
    // da tra loi dung bao nhieu cau
    int correctAnswer = 0;
    int questionSeen = 0;
    public int getCorrectAnswer() {
        return correctAnswer;
    }
    public void incrementCorrectAnswer() {
        correctAnswer++;
    }
    public int getQuestionSeen()
    {
        return questionSeen;
    }
    public void incrementQuestionSeen()
    {
        questionSeen++;
    }
    public int calculate() {
        return Mathf.RoundToInt(correctAnswer / (float)questionSeen * 100);
    }
}
