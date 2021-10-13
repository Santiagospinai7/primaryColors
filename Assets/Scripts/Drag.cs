using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    public GameObject sphere;

    private bool isMoving = false;

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
        isMoving = true;

        float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        Vector3 pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
        transform.position = new Vector3(pos_move.x, transform.position.y, pos_move.z);
    }

    private void OnMouseExit()
    {
        isMoving = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isMoving)
        {
            Debug.Log("Delete: " + other.gameObject.tag);
        }
    }
}