using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Add this script to a gameobjects to remove them when offscreen

public class DestroyOffscreen : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Deletes this gameobject when collided with Eraser
        if(collision.gameObject.tag == "Eraser")
        {
            Destroy(gameObject);
        }
    }
}
