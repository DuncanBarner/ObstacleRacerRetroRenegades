using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
    public float speed; //Platform move speed
    public int startingPoint; //Starting point of the platform index
    public Transform[] points; //An array of transform points (Positions where the platform moves)

    private int i; //counter variable to navigate array (index)


    // Start is called before the first frame update
    void Start()
    {
        //setting platform position to starting point index value
        transform.position = points[startingPoint].position; 
        
    }

    // Update is called once per frame
    void Update()
    {
       //checking distance of platform and target point
        if(Vector2.Distance(transform.position, points[i].position) < 0.02f){
            i++; //increase index
            if(i == points.Length)
            {
                i = 0; //Reset index
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }


}
