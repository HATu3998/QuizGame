using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Quiz quiz;
    EndGame endGame;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        quiz = FindFirstObjectByType<Quiz>();
        endGame = FindFirstObjectByType<EndGame>();
    }
    void Start()
    {
        
        quiz.gameObject.SetActive(true);
        endGame.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (quiz.isComplete)
        {
            quiz.gameObject.SetActive(false);
            endGame.gameObject.SetActive(true);
        }
    }
    public void OnReplay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
