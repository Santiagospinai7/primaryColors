using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

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
    public GameObject tryAgainLevel;

    private bool finish;
    private bool uncomplete;

    public Material[] sphereMaterials;

    public GameObject title;
    private TextMeshProUGUI level_title;
    public GameObject model_sphere;

    // Start is called before the first frame update
    void Start()
    {
        finish = false;
        uncomplete = false;
        completeLevel.SetActive(false);
        tryAgainLevel.SetActive(false);
        celebrateAudio = GameObject.Find("Parent").GetComponent<AudioSource>();
        level_title = title.GetComponent<TextMeshProUGUI>();

        if (MenuScript.greenLevel) {
            MenuScript.greenLevelStars = 3;
            starsCounter = MenuScript.greenLevelStars;
            level_title.SetText("GREEN");
            foreach (var x in sphereMaterials)
            {
                if (x.name == "green")
                {
                    model_sphere.GetComponent<Renderer>().material = x;
                    model_sphere.gameObject.tag = "green";
                }
            }
        }

        if (MenuScript.violetLevel) {
            MenuScript.violetLevelStars = 3;
            starsCounter = MenuScript.violetLevelStars;
            level_title.SetText("VIOLET");
            foreach (var x in sphereMaterials)
            {
                if (x.name == "violet")
                {
                    model_sphere.GetComponent<Renderer>().material = x;
                    model_sphere.gameObject.tag = "violet";
                }
            }
        }

        if (MenuScript.orangeLevel)
        {
            MenuScript.orangeLevelStars = 3;
            starsCounter = MenuScript.orangeLevelStars;
            level_title.SetText("ORANGE");
            foreach (var x in sphereMaterials)
            {
                if (x.name == "orange")
                {
                    model_sphere.GetComponent<Renderer>().material = x;
                    model_sphere.gameObject.tag = "orange";
                }
            }
        }

        if (MenuScript.blueGreenLevel)
        {
            MenuScript.blueGreenLevelStars = 3;
            starsCounter = MenuScript.blueGreenLevelStars;
            level_title.SetText("BLUE-GREEN");
            foreach (var x in sphereMaterials)
            {
                if (x.name == "blueGreen")
                {
                    model_sphere.GetComponent<Renderer>().material = x;
                    model_sphere.gameObject.tag = "blueGreen";
                }
            }
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
                    tryAgainLevelCanvas();
                }

                if (uncomplete)
                {
                    MenuScript.greenLevelStars = 0;
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
                    tryAgainLevelCanvas();
                }

                if (uncomplete)
                {
                    MenuScript.violetLevelStars = 0;
                }
            }
        }

        if (MenuScript.orangeLevel)
        {
            if (!finish)
            {
                if (completeGoal)
                {
                    completeGoal = false;
                    celebrateAudio.Play(0);
                    finish = true;
                    MenuScript.orangeLevelStars = starsCounter;
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
                    tryAgainLevelCanvas();
                }

                if (uncomplete)
                {
                    MenuScript.orangeLevelStars = 0;
                }
            }
        }

        if (MenuScript.blueGreenLevel)
        {
            if (!finish)
            {
                if (completeGoal)
                {
                    completeGoal = false;
                    celebrateAudio.Play(0);
                    finish = true;
                    MenuScript.blueGreenLevelStars = starsCounter;
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
                    tryAgainLevelCanvas();
                }

                if (uncomplete)
                {
                    MenuScript.blueGreenLevelStars = 0;
                }
            }
        }
    }

    public void goToMenu() {
        Debug.Log("Estrellas antes: " + starsCounter);
        SceneManager.LoadScene("Menu");
    }

    public void goToMenuUncomplete()
    {
        uncomplete = true;
        SceneManager.LoadScene("Menu");
        Debug.Log("Volver al menu no lo completo");
    }

    public void retry()
    {
        SceneManager.LoadScene("Color_Level");
        Debug.Log("repetir nivel");
    }

    void completeLevelCanvas() {
        completeLevel.SetActive(true);
    }

    void tryAgainLevelCanvas()
    {
        tryAgainLevel.SetActive(true);
    }
}
