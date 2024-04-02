using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText ;
    public static int scoreCount;
    public static int starRating;
    [SerializeField] int[] scoreRequirement;
    void Update()
    {
        scoreText.text = "Score: " + scoreCount;

        starRating = 0;

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


