using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreenManager : MonoBehaviour
{
    public Text buttonText, endText, collectedText, gradeText;
    public Button button;
    private string scene;
    int[] flowerTotals = {0, 8, 13, 13};

    void Start()
    {
        int lastLevel = PlayerPrefs.GetInt("LastLevel");
        button.onClick.AddListener(SceneSwitcher);
        if (PlayerPrefs.GetInt("EndState") < 1) {
            if (PlayerPrefs.GetInt("LivesLeft") > 0) {
                endText.text = "SPOTTED";
                buttonText.text = "TRY AGAIN";
                collectedText.text = "";
                gradeText.text = "";
                scene = "Level"+lastLevel;
            } else {
                endText.text = "GAME OVER";
                buttonText.text = "START OVER";
                collectedText.text = "";
                gradeText.text = "";
                scene = "MenuScreen";
            }
        } 
        else if (lastLevel == 3)
        {
            int collected = PlayerPrefs.GetInt("FlowersCollected");
            int score = 100*collected/flowerTotals[lastLevel];
            endText.text = "YOU WIN!";
            buttonText.GetComponentInParent<Button>().gameObject.SetActive(false);
            collectedText.text = "Rescued " + score.ToString() + "% of friends";
            gradeText.text = GetGrade(score);
        }
        else {
            int collected = PlayerPrefs.GetInt("FlowersCollected");
            int score = 100*collected/flowerTotals[lastLevel];
            endText.text = "YOU WIN!";
            buttonText.text = "NEXT LEVEL";
            collectedText.text = "Rescued " + score.ToString() + "% of friends";
            gradeText.text = GetGrade(score);
            scene = "Level"+(lastLevel+1);
        }
        
    }

    public void SceneSwitcher()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    string GetGrade(int score) {
        if (score<20) {return "F";}
        else if (score<40) {if (score<=25) {return "D-";} else if (score>=35) {return "D+";} else {return "D";}}
        else if (score<60) {if (score<=45) {return "C-";} else if (score>=55) {return "C+";} else {return "C";}}
        else if (score<80) {if (score<=65) {return "B-";} else if (score>=75) {return "B+";} else {return "B";}}
        else {if (score<=85) {return "A-";} else if (score>=95) {return "A+";} else {return "A";}}
    }
}
