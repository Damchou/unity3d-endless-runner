using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    public GameObject Turf;
    public GameObject player;



    private float oldx;
    private int howmanymissed;
    private float turfPositionY;

    // Use this for initialization
    void Start () {
        Regenerate();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (player.transform.position.x >= oldx + 1)
        {
            if (Random.Range(1, 7) > 3 || howmanymissed > 1)
            {
                if (Random.Range(1, 8) == 2)
                {
                    turfPositionY = turfPositionY = +Random.Range(-3, 3);
                }
                
                Instantiate(Turf, new Vector2(oldx + 22, turfPositionY), gameObject.transform.rotation);
                howmanymissed = 0;
            }
            else
            {
                howmanymissed++;
            }

            oldx = player.transform.position.x;
        }



    }

    // Destroys every "Ground" tagged object to clear the map
    public void DestroyAll()
    {
        GameObject[] turfs = GameObject.FindGameObjectsWithTag("Ground");
        foreach (GameObject turf in turfs)
            GameObject.Destroy(turf);
    }

    // Regenerates the starting zone
    public void Regenerate()
    {
        for(int i = -2; i < 10; i++)
        {
            Instantiate(Turf, new Vector2(i, 1), Quaternion.identity);
        }

        oldx = 0;
    }
}
