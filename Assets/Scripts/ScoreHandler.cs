using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    public GameObject[] stars;

    private void Update()
    {
        starsAchieved();
    }
    public void starsAchieved()
    {
        if(Score.starRating == 1)
        {
            stars[0].SetActive(true);
        }
        if (Score.starRating == 2)
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
        }
        if (Score.starRating == 3)
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
        }
    }
}
