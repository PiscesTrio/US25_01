using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    int score;
    Text text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = GetComponent<Text>();
        score = 0;
    }
    
    public void AddScore(int value)
    {
        score += value;
        text.text = string.Format("{0:D4}", score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
