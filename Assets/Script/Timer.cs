using UnityEngine;

public class Timer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float timeToCompleteQuestion = 30f;
    [SerializeField] float timeToShowCorrectAnswers = 10f;
    float TimeValue;
    public bool isAnsweringQuestion = false;
    public float fillFraction;
    public bool loadNextQuestion;
    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }
    void UpdateTimer()
    {
        //da tra loi cau hoi
        if (isAnsweringQuestion)
        {
            if(TimeValue >0)
            {
                fillFraction = TimeValue / timeToCompleteQuestion;
            }
            else
            {
                isAnsweringQuestion = false;
                TimeValue = timeToShowCorrectAnswers;
                loadNextQuestion = true;
            }
        }
        //chua tra loi cau hoi
        else{
            if (TimeValue > 0)
            {
                fillFraction = TimeValue / timeToShowCorrectAnswers;
            }
            else
            {
                isAnsweringQuestion = true;
                TimeValue = timeToCompleteQuestion;
                loadNextQuestion = true;
            }
        }

            TimeValue -= Time.deltaTime;
       
        Debug.Log(isAnsweringQuestion+ ":"+  TimeValue + "= "+ fillFraction);
    }
    //ham huy thoi gian, khi skip cau hoi
   public void Canceltimer()
    {
        TimeValue = 0;
    }

}
