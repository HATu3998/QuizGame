using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textQuiz;
    [SerializeField] QuestionSystem  question;
    [SerializeField] GameObject[] buttonAnswer;
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    int correctAnswerIndex;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textQuiz.text = question.getQuestion();
        for(int i=0;i < buttonAnswer.Length; i++)
        {
            TextMeshProUGUI buttonText = buttonAnswer[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.getAnswer(i);
        }

       
    }
    public void OnSelectedAnswer(int index)
    {
        if(index == question.getCorrectAnswer())
        {
            textQuiz.text = "correct!!";
            Image buttonImage = buttonAnswer[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;

        }else
        {
            correctAnswerIndex = question.getCorrectAnswer();
            string correctAnswer = question.getAnswer(correctAnswerIndex);
            textQuiz.text = "the correct answer is:\n" + correctAnswer;
            Image buttonImage = buttonAnswer[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
    }


}

 