using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    // creates score variable
    public int score;

    [SerializeField]
    private TextMeshProUGUI scoreText = null;

    // on a trigger event updates score (when ball hits targets this is invoked)
    private void OnTriggerEnter(Collider other)
    {
        addScore(other);
    }

    // keeps track of total score
    void addScore(Collider other)
    {
        // compares the balls tag to that of target tag
        if (other.CompareTag("Target"))
        {
            score++;
            scoreText.text = score.ToString();
            Debug.Log("Target Hit!");
        }
        else
        {
            // displays total score
            scoreText.text = score.ToString();
        }   
    }
}
