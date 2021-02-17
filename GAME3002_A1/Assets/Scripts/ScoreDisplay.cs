using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{

    public int score;

    [SerializeField]
    private TextMeshProUGUI scoreText = null;


    private void OnTriggerEnter(Collider other)
    {
        addScore(other);
    }

    void addScore(Collider other)
    {
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

    // Update is called once per frame
    void Update()
    {

    }
}
