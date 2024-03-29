using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public static int scoreCount;
    public static int starRating;
    private int[] scoreRequirement = { 300, 400, 500};
    void Update()
    {
        scoreText.text = "Score: " + scoreCount;

        if(scoreCount >= scoreRequirement[0] && scoreCount < scoreRequirement[1])
        {
            starRating = 1;
        }
        if(scoreCount >= scoreRequirement[1] && scoreCount < scoreRequirement[2])
        {
            starRating = 2;
        }
        if (scoreCount >= scoreRequirement[2])
        {
            starRating = 3;
        }
    }

}


