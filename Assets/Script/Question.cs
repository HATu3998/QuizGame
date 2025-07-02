using UnityEngine;

[CreateAssetMenu (fileName = "Question" , menuName = "Quiz Game", order =0)]
public class QuestionSystem : ScriptableObject
{
    [TextArea(2,5)]
   [SerializeField] string Question = "how are u";
    [SerializeField] string[] answer = new string[4];
    [SerializeField] int correctAnswer;

    public string getQuestion()
    {
        return Question;
    }
    public string getAnswer(int intdex)
    {
        return answer[intdex];
    }
    public int getCorrectAnswer()
    {
        return correctAnswer;
    }

}
