using UnityEngine;

// inherits from Ball calss
 public class crazyBall : Ball
{
    
    protected override void FixedUpdate()
    {
    // Every frame there is a 2% chance that this statement will run
        if (Random.Range(0, 100) <= 2)
        {
  
            // the size of the ball will be randomly selected between these 2 values
            size = Random.Range(0.5f, 2);

            // this means that the bigger the ball gets the slower it is 
            speed = 0.2f / size;

        }
        // this calls the function that lets the ball move
        base.FixedUpdate();
    }
}

