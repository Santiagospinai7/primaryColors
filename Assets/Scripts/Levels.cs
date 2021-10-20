using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Levels : MonoBehaviour
{
    public int starsCounter;

    public bool completeGoal;
    public bool error;

    public GameObject[] stars;
    public Sprite goldStar;
    public Sprite whiteStar;

    private AudioSource celebrateAudio;

    public GameObject completeLevel;

    private bool finish;

    private bool violetWasPlayed;
    private bool greenWasPlayed;

    // Start is called before the first frame update
    void Start()
    {
        finish = false;
        completeLevel.SetActive(false);
        celebrateAudio = GameObject.Find("Parent").GetComponent<AudioSource>();

        if (MenuScript.greenLevel) {
            MenuScript.greenLevelStars = 3;
            starsCounter = MenuScript.greenLevelStars;
        }

        if (MenuScript.violetLevel) {
            MenuScript.violetLevelStars = 3;
            starsCounter = MenuScript.violetLevelStars;
        }

        
        completeGoal = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (MenuScript.greenLevel) {
            if (!finish)
            {
                if (completeGoal)
                {
                    completeGoal = false;
                    celebrateAudio.Play(0);
                    finish = true;
                    MenuScript.greenLevelStars = starsCounter;
                    completeLevelCanvas();
                }

                if (error)
                {
                    starsCounter--;
                    stars[starsCounter].GetComponent<Image>().sprite = whiteStar;
                    error = false;
                }

                if (starsCounter == 0)
                {
                    stars[starsCounter].GetComponent<Image>().sprite = whiteStar;
                }
            }
        }

        if (MenuScript.violetLevel)
        {
            if (!finish)
            {
                if (completeGoal)
                {
                    completeGoal = false;
                    celebrateAudio.Play(0);
                    finish = true;
                    MenuScript.violetLevelStars = starsCounter;
                    completeLevelCanvas();
                }

                if (error)
                {
                    starsCounter--;
                    stars[starsCounter].GetComponent<Image>().sprite = whiteStar;
                    error = false;

                }

                if (starsCounter == 0)
                {
                    stars[starsCounter].GetComponent<Image>().sprite = whiteStar;
                }
            }
        }
    }

    public void goToMenu() {
        Debug.Log("Estrellas antes: " + starsCounter);
        SceneManager.LoadScene("Menu");
    }

    void completeLevelCanvas() {
        completeLevel.SetActive(true);
    }
}
