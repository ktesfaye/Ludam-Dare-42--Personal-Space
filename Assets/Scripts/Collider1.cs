using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider1 : MonoBehaviour {

    public bool entered = false;
    public int count = 0;

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            count++;
            entered = true;
            Debug.Log("Enemy collided into Player's Zone 1.");
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            count--;
            entered = false;
            Debug.Log("Enemy has left Player's Zone 1.");
        }
    }
}
