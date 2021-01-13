using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Ball : MonoBehaviour
{
    // declaring variables and setting values
    public float size = 1.0f;
    public float speed = 0.2f;
    float directionX = 1.0f;
    float directionY = 0.5f;

    public BallSpawner spawner;

    public AudioSource bangNoise;


   protected virtual void FixedUpdate()
    {

        // setting the tranfomation variable ???
        Vector3 scale = new Vector3();
        scale.x = size;
        scale.y = size;
        transform.localScale = scale;

        // this reads in the ball position, adds the velocity to the new variable 
        // and then sets the postion to the value of value of new position
        Vector3 position = transform.localPosition;
        position.x += speed * directionX;
        position.y += speed * directionY;
        transform.localPosition = position;
    }
    
    // this is run by unity whenever the ball interacts with an object
    void OnCollisionEnter2D(Collision2D other)
    {

    // if the ball interacts with any of the following game objects 
    // it run the code for said object 
        switch (other.gameObject.name)
        {
            case "Bat": // If the object is hit then
                directionY = -directionY;// Inverts to oppisote direction
                bangNoise.Play(); //plays the audio
                break; // end case 
            case "T Wall":
                directionY = -directionY;
                break;
            case "L Wall":
            case "R Wall":
                directionX = -directionX;
                break;
            case "Goal":
                spawner.lives--; // decreases lives value by 1
                // this sends new text to show to the UI element which displays lives left
                GameObject.Find("Canvas/Lives").GetComponent<Text>().text = "Lives Left: " + spawner.lives;
                spawner.DespawnBall(this); // calls despawn function 
                // if the player has more than 0 lives then a new ball is spawned
                if (spawner.lives > 0)
                {
                    spawner.ballChance();
                }
                //else calls fucntion to sidaply game over text
                else
                    spawner.endGame(); 
                break; 
        }

        // if the ball interacts with anything with a "Brick" tag
        switch (other.gameObject.tag)
        {
            case "Brick":
                directionY = -directionY;
                other.gameObject.GetComponent<Brick>().DespawnBrick();  
                bangNoise.Play();
                break;
        }
    }

    // this sets the direction of the ball
    public void SetDirection(int angleInDegrees)
    {
        float angleInRadians = angleInDegrees * Mathf.Deg2Rad;
        directionX = Mathf.Cos(angleInRadians);
        directionY = Mathf.Sin(angleInRadians);

    }
}



