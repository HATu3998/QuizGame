using TMPro;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Congratulations \n Your score: " + scoreKeeper.calculate() + "%";
    }
}
