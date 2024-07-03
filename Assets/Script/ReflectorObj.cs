using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectorObj : MonoBehaviour
{
    public bool clicked;

    void FixedUpdate()
    {
        Vector2 MousePos;
        MousePos = Input.mousePosition;
        MousePos = Camera.main.ScreenToWorldPoint(MousePos);
        if (clicked)
        {
            gameObject.transform.position = MousePos;
            GameObject.Find("GameManager").GetComponent<GM>().ActiveReflector = this.gameObject;
        }
        else
        {

        }
    }
    void OnMouseDown()
    {
        if (clicked)
        {
            clicked = false;
        }
        else
        {
            clicked = true;
        }
    }

}
