using System;
using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class Quiz : MonoBehaviour
{
    [Header("Question")]
    [SerializeField] TextMeshProUGUI textQuiz;
    [SerializeField] List<QuestionSystem> questions = new List<QuestionSystem>();
    QuestionSystem   currentQuestion;

    [Header("Answer")]
    [SerializeField] GameObject[] buttonAnswer;
    int correctAnswerIndex;
    bool hasAnswerEarly;

    [Header("Button")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // DisplayQuestion();
        timer = FindFirstObjectByType<Timer>();
       


    }
    private void Update()
    {
        //cho image thời gian xoay
        timerImage.fillAmount = timer.fillFraction;

        if (timer.loadNextQuestion)
        {
            getNextQuestion();
            timer.loadNextQuestion = false;
        }
        //người chơi chưa tl và het thời gian
        else if(!hasAnswerEarly && !timer.isAnsweringQuestion)
        {
            hasAnswerEarly=false;
            DisplayAnswer(-1);
            buttonState(false);
        }
    }
    void DisplayAnswer(int index)
    {
        if (index == currentQuestion.getCorrectAnswer())
        {
            textQuiz.text = "correct!!";
            Image buttonImage = buttonAnswer[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;

        }
        else
        {
            correctAnswerIndex = currentQuestion.getCorrectAnswer();
            string correctAnswer = currentQuestion.getAnswer(correctAnswerIndex);
            textQuiz.text = "the correct answer is:\n" + correctAnswer;
            Image buttonImage = buttonAnswer[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        
    }
    
    public void DisplayQuestion()
    {
        textQuiz.text = currentQuestion.getQuestion();
        for (int i = 0; i < buttonAnswer.Length; i++)
        {
            TextMeshProUGUI buttonText = buttonAnswer[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.getAnswer(i);
        }

    }

    void buttonState(bool state)
    {
        for(int i =0;i < buttonAnswer.Length; i++)
        {
            Button button = buttonAnswer[i].GetComponent<Button>();
            button.interactable = state;
        }
    }
    public void OnSelectedAnswer(int index)
    {
        hasAnswerEarly = true;
        DisplayAnswer(index);
        timer.Canceltimer();
        buttonState(false);
    }
    void getNextQuestion()
    {
       if(questions.Count > 0)
        {

            SetDefaultButtonSprite();
            buttonState(true);
            GetRandomQuestion();
            DisplayQuestion();
        }

    }
    void GetRandomQuestion()
    {
        int index = Random.Range(0, questions.Count);
        currentQuestion = questions[index];
        if (questions.Contains(currentQuestion))
        {
            questions.Remove(currentQuestion);
        }
    }
    private void SetDefaultButtonSprite()
    {
        for(int i=0;i < buttonAnswer.Length; i++)
        {
            Image buttonImage = buttonAnswer[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }

}

 