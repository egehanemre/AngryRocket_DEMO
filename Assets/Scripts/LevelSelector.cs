using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public int level;

    public GameObject panel;
    public void OpenScene()
    {
        Score.scoreCount = 0;
        Score.starRating = 0;
        SceneManager.LoadScene("Level_" + level.ToString());
    }

    public void LoadNext()
    {
        Score.scoreCount = 0;
        Score.starRating = 0;
        panel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
