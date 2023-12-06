using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score;
    public TMP_Text scoreUi;
    
    // Start is called before the first frame update
    void Start()
    {
        resetScore();
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void resetScore()
    {
        score = 0;
    }
    
    private void resetGame()
    {
        resetScore();
    }
    
    public void incrementScore()
    {
        Debug.Log("incrementing score");
        score += 1;
        scoreUi.SetText("Score : test " + score);
    }
}
