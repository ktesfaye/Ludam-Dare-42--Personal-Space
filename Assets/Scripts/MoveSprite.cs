using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveSprite : MonoBehaviour {
 
    public GameObject test;
    Skill movement;
    float xDir;
    float yDir;
    PartyGoer paul;

    public float speed = 200000f;

	// Use this for initialization
	void Start () {
        paul = test.GetComponent<PartyGoer>();
	}
	
	// Update is called once per frame
	void Update () {

		/*if (Input.GetKeyDown(KeyCode.Q))
        {
            xDir = 0;
            yDir = 0;
            move(paul, movement);
        }*/
	}
    //call from game manager
    public void move(PartyGoer paul, direction dir)
    {
        if (dir == direction.stay)
        {
            return;
        }
        if (dir == direction.left)
        {
            xDir = -1.25f;
            yDir = 0;
        }
        if (dir == direction.right)
        {
            xDir = 1.25f;
            yDir = 0;
        }
        if (dir == direction.up)
        {
            xDir = 0;
            yDir = 1.25f;
        }

        if (dir == direction.down)
        {
            xDir = 0;
            yDir = -1.25f;
        }

        Vector2 start = paul.transform.position;
        Vector2 end = start + new Vector2(xDir, yDir);

        //if Board(positions[end]) ==

        paul.transform.position = end;
        //paul.transform.position = Vector2.MoveTowards(start, end, speed * Time.deltaTime);
        start.Set(0, 0);
        end.Set(0, 0);
    }
}
