using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void firstLevel() {
        SceneManager.LoadScene("First_Level");
    }
}
