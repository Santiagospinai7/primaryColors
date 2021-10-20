using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    public GameObject sphere;

    public Material[] materials;

    private AudioSource joinAudio;
    private GameObject floor;

    private float gameObjectPositionX;
    private float gameObjectPositionY;
    private float gameObjectPositionZ;

    private GameObject parent;
    private Levels levels;

    private void Start()
    {
        parent = GameObject.Find("Parent");
        levels = parent.GetComponent<Levels>();
        floor = GameObject.Find("Floor");
        joinAudio = floor.GetComponent<AudioSource>();
    }

    void Update()
    {
        gameObjectPositionX = sphere.transform.position.x;
        gameObjectPositionY = sphere.transform.position.y;
        gameObjectPositionZ = sphere.transform.position.z;

        if (gameObjectPositionX > 3)
        {
            gameObject.transform.position = new Vector3(3, gameObjectPositionY, gameObjectPositionZ);
        }
        else if (gameObjectPositionX < -3)
        {
            gameObject.transform.position = new Vector3(-3, gameObjectPositionY, gameObjectPositionZ);
        }

        if (gameObjectPositionZ > 5)
        {
            gameObject.transform.position = new Vector3(gameObjectPositionX, gameObjectPositionY, 5);
        }
        else if (gameObjectPositionZ < -5)
        {
            gameObject.transform.position = new Vector3(gameObjectPositionX, gameObjectPositionY, -5);
        }

        if (gameObjectPositionZ > 5 && gameObjectPositionX > 3)
        {
            gameObject.transform.position = new Vector3(3, gameObjectPositionY, 5);
        }
        else if (gameObjectPositionZ > 5 && gameObjectPositionX < -3)
        {
            gameObject.transform.position = new Vector3(-3, gameObjectPositionY, 5);
        }
        else if (gameObjectPositionZ < -5 && gameObjectPositionX > 3)
        {
            gameObject.transform.position = new Vector3(3, gameObjectPositionY, -5);
        }
        else if (gameObjectPositionZ < -5 && gameObjectPositionX < -3)
        {
            gameObject.transform.position = new Vector3(-3, gameObjectPositionY, -5);
        }
    }

    void OnMouseDrag()
    {
        float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        Vector3 pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
        transform.position = new Vector3(pos_move.x, transform.position.y, pos_move.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(MenuScript.greenLevel)
        {
            //GREEN
            if (sphere.gameObject.tag == "blue" && other.gameObject.tag == "yellow" || sphere.gameObject.tag == "yellow" && other.gameObject.tag == "blue")
            {
                foreach (var x in materials)
                {
                    if (x.name == "green")
                    {
                        sphere.GetComponent<Renderer>().material = x;
                        sphere.gameObject.tag = "green";
                        Debug.Log("Convertir en verde.");
                    }
                }
                joinAudio.Play(0);
                StartCoroutine(tweenCoroutine());
                levels.completeGoal = true;
                Destroy(other.gameObject);
            }
            //ORANGE
            if (sphere.gameObject.tag == "red" && other.gameObject.tag == "yellow" || sphere.gameObject.tag == "yellow" && other.gameObject.tag == "red")
            {
                foreach (var x in materials)
                {
                    if (x.name == "orange")
                    {
                        sphere.GetComponent<Renderer>().material = x;
                        sphere.gameObject.tag = "orange";
                        Debug.Log("Convertir en naranja.");
                    }
                }
                joinAudio.Play(0);
                StartCoroutine(tweenCoroutine());
                levels.error = true;
                Destroy(other.gameObject);
            }
            //VIOLET
            if (sphere.gameObject.tag == "blue" && other.gameObject.tag == "red" || sphere.gameObject.tag == "red" && other.gameObject.tag == "blue")
            {
                foreach (var x in materials)
                {
                    if (x.name == "violet")
                    {
                        sphere.GetComponent<Renderer>().material = x;
                        sphere.gameObject.tag = "violet";
                        Debug.Log("Convertir en morado.");
                    }
                }
                joinAudio.Play(0);
                StartCoroutine(tweenCoroutine());
                levels.error = true;
                Destroy(other.gameObject);
            }
        }

        if (MenuScript.violetLevel)
        {
            //GREEN
            if (sphere.gameObject.tag == "blue" && other.gameObject.tag == "yellow" || sphere.gameObject.tag == "yellow" && other.gameObject.tag == "blue")
            {
                foreach (var x in materials)
                {
                    if (x.name == "green")
                    {
                        sphere.GetComponent<Renderer>().material = x;
                        sphere.gameObject.tag = "green";
                        Debug.Log("Convertir en verde.");
                    }
                }
                joinAudio.Play(0);
                StartCoroutine(tweenCoroutine());
                levels.error = true;
                Destroy(other.gameObject);
            }
            //ORANGE
            if (sphere.gameObject.tag == "red" && other.gameObject.tag == "yellow" || sphere.gameObject.tag == "yellow" && other.gameObject.tag == "red")
            {
                foreach (var x in materials)
                {
                    if (x.name == "orange")
                    {
                        sphere.GetComponent<Renderer>().material = x;
                        sphere.gameObject.tag = "orange";
                        Debug.Log("Convertir en naranja.");
                    }
                }
                joinAudio.Play(0);
                StartCoroutine(tweenCoroutine());
                levels.error = true;
                Destroy(other.gameObject);
            }
            //VIOLET
            if (sphere.gameObject.tag == "blue" && other.gameObject.tag == "red" || sphere.gameObject.tag == "red" && other.gameObject.tag == "blue")
            {
                foreach (var x in materials)
                {
                    if (x.name == "violet")
                    {
                        sphere.GetComponent<Renderer>().material = x;
                        sphere.gameObject.tag = "violet";
                        Debug.Log("Convertir en morado.");
                    }
                }
                joinAudio.Play(0);
                StartCoroutine(tweenCoroutine());
                levels.completeGoal = true;
                Destroy(other.gameObject);
            }
        }
    }

    IEnumerator tweenCoroutine()
    {
        yield return new WaitForSeconds(0.0001f);
        LeanTween.scale(sphere, new Vector3(0.85f, 0.85f, 0.85f), 0.1f);
        yield return new WaitForSeconds(0.1f);
        LeanTween.scale(sphere, new Vector3(1.2f, 1.2f, 1.2f), 0.1f);
        
        yield return new WaitForSeconds(0.1f);
        LeanTween.scale(sphere, new Vector3(0.9f, 0.9f, 0.9f), 0.1f);
        yield return new WaitForSeconds(0.1f);
        LeanTween.scale(sphere, new Vector3(1.1f, 1.1f, 1.1f), 0.1f);
        yield return new WaitForSeconds(0.1f);
        LeanTween.scale(sphere, new Vector3(1.0f, 1.0f, 1.0f), 0.1f);
    }
}