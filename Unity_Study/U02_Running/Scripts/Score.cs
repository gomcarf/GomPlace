using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int score;

    private TextMeshProUGUI tmp;

    private void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>();

        tmp.text = $"Score : 0";
    }

    public void AddScore()
    {
        score++;

        tmp.text = $"Score : {score}";
    }
    
}
