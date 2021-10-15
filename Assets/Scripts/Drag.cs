using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    public GameObject sphere;

    private bool isMoving = false;

    public Material[] materials;

    private float gameObjectPositionX;
    private float gameObjectPositionY;
    private float gameObjectPositionZ;

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
        //isMoving = true;

        float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        Vector3 pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
        transform.position = new Vector3(pos_move.x, transform.position.y, pos_move.z);
    }

    private void OnMouseExit()
    {
        //isMoving = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        //GREEN
        if (sphere.gameObject.tag == "blue" && other.gameObject.tag == "yellow" || sphere.gameObject.tag == "yellow" && other.gameObject.tag == "blue")
        {
            foreach (var x in materials) {  
                if (x.name == "green") {
                    sphere.GetComponent<Renderer>().material = x;
                    sphere.gameObject.tag = "green";
                    Debug.Log("Convertir en verde.");
                }
            }
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
            Destroy(other.gameObject);
        }
    }
}