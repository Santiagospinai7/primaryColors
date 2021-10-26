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

    public static bool blueGreenLevel;
    public static int blueGreenLevelStars;

    public GameObject[] greenStars;
    public GameObject[] violetStars;
    public GameObject[] orangeStars;
    public GameObject[] blueGreenStars;

    public Sprite goldStar;
    public Sprite whiteStar;

    private void Start()
    {
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

        switch (orangeLevelStars)
        {
            case 1:
                for (var i = 0; i < (orangeStars.Length - 2); i++)
                {
                    orangeStars[i].GetComponent<Image>().sprite = goldStar;
                }
                break;
            case 2:
                for (var y = 0; y < (orangeStars.Length - 1); y++)
                {
                    orangeStars[y].GetComponent<Image>().sprite = goldStar;
                }
                break;
            case 3:
                for (var x = 0; x < orangeStars.Length; x++)
                {
                    orangeStars[x].GetComponent<Image>().sprite = goldStar;
                }
                break;
        }

        switch (blueGreenLevelStars)
        {
            case 1:
                for (var i = 0; i < (blueGreenStars.Length - 2); i++)
                {
                    blueGreenStars[i].GetComponent<Image>().sprite = goldStar;
                }
                break;
            case 2:
                for (var y = 0; y < (blueGreenStars.Length - 1); y++)
                {
                    blueGreenStars[y].GetComponent<Image>().sprite = goldStar;
                }
                break;
            case 3:
                for (var x = 0; x < blueGreenStars.Length; x++)
                {
                    blueGreenStars[x].GetComponent<Image>().sprite = goldStar;
                }
                break;
        }

        resetBooleanLevels();
    }

    public void resetBooleanLevels() {
        greenLevel = false;
        violetLevel = false;
        orangeLevel = false;
        blueGreenLevel = false;
    }

    public void firstLevel() {
        greenLevel = true;
        SceneManager.LoadScene("Color_Level");
    }

    public void secondLevel()
    {
        violetLevel = true;
        SceneManager.LoadScene("Color_Level");
    }

    public void thirdLevel()
    {
        orangeLevel = true;
        SceneManager.LoadScene("Color_Level");
    }

    public void fourthLevel()
    {
        blueGreenLevel = true;
        SceneManager.LoadScene("Color_Level");
    }
}
