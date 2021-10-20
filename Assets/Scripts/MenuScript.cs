using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public static bool greenLevel;
    public static int greenLevelStars;

    public static bool violetLevel;
    public static int violetLevelStars;

    public static bool orangeLevel;
    public static int orangeLevelStars;

    public GameObject[] greenStars;
    public GameObject[] violetStars;

    public Sprite goldStar;
    public Sprite whiteStar;

    private void Start()
    {
        //if (greenLevel) {
            resetGreenStars();
            switch (greenLevelStars)
            {
                case 1:
                    for (var i = 0; i < (greenStars.Length - 2); i++)
                    {
                        greenStars[i].GetComponent<Image>().sprite = goldStar;
                    }
                    break;
                case 2:
                    for (var y = 0; y < (greenStars.Length - 1); y++)
                    {
                        greenStars[y].GetComponent<Image>().sprite = goldStar;
                    }
                    break;
                case 3:
                    for (var x = 0; x < greenStars.Length; x++)
                    {
                        greenStars[x].GetComponent<Image>().sprite = goldStar;
                    }
                    break;
            }
        //}

        //if (violetLevel) {
            resetVioletStars();
            switch (violetLevelStars)
            {
                case 1:
                    for (var i = 0; i < (greenStars.Length - 2); i++)
                    {
                        violetStars[i].GetComponent<Image>().sprite = goldStar;
                    }
                    break;
                case 2:
                    for (var y = 0; y < (greenStars.Length - 1); y++)
                    {
                        violetStars[y].GetComponent<Image>().sprite = goldStar;
                    }
                    break;
                case 3:
                    for (var x = 0; x < greenStars.Length; x++)
                    {
                        violetStars[x].GetComponent<Image>().sprite = goldStar;
                    }
                    break;
            }
        //}
        
        resetBooleanLevels();
    }

    public void resetBooleanLevels() {
        greenLevel = false;
        violetLevel = false;
        orangeLevel = false;
    }

    void resetGreenStars() {
        Debug.Log("test1  reseteo las verdes");
        for (var x = 0; x < greenStars.Length; x++)
        {
            //greenStars[x].GetComponent<Image>().sprite = whiteStar;
        }
    }

    void resetVioletStars()
    {
        Debug.Log("test1  reseteo las violetas");
        for (var x = 0; x < violetStars.Length; x++)
        {
            //violetStars[x].GetComponent<Image>().sprite = whiteStar;
        }
    }

    public void firstLevel() {
        greenLevel = true;
        SceneManager.LoadScene("First_Level");
    }

    public void secondLevel()
    {
        violetLevel = true;
        SceneManager.LoadScene("Second_Level");
    }
}
