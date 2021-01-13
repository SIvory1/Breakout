using UnityEngine;
using UnityEngine.UI;

public class Bat : MonoBehaviour
{

    // declaring variables and setting values
    public KeyCode moveRightKey = KeyCode.RightArrow;
    public KeyCode moveLeftKey = KeyCode.LeftArrow;
    public float speed = 0.2f;
    float direction = 0.0f;
    bool canMoveRight = true;
    bool canMoveLeft = true;

    // this reads in the bat position, adds the velocity to the new variable 
    // and then sets the postion to the value of value of new position
    void FixedUpdate()
    {
        Vector3 position = transform.localPosition;
        position.x += speed * direction;
        transform.localPosition = position;
    }

    void Update()
    {
        bool isRightPressed = Input.GetKey(moveRightKey);
        bool isLeftPressed = Input.GetKey(moveLeftKey);

        if (isRightPressed && canMoveRight)
        {
            direction = 1.0f;
        }
        else if (isLeftPressed && canMoveLeft)
        {
            direction = -1.0f;
        }
        else
        {
            // when the player isnt moving the bat its direction is 0
            direction = 0.0f;
        }
    }

    // this stops the bats from going outside of the play range
    // if it collides with the walls one of the movement conditions 
    // is set to false
    void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.name)
        {
            case "R Wall":
                canMoveRight = false;
                break;
            case "L Wall":
                canMoveLeft = false;
                break;
        }
    }
    // when the bats are removed from the wall, the direction is set to true
    void OnCollisionExit2D(Collision2D other)
    {
        switch (other.gameObject.name)
        {
            case "R Wall":
                canMoveRight = true;
                break;
            case "L Wall":
                canMoveLeft = true;
                break;
        }
    }
    
    }
