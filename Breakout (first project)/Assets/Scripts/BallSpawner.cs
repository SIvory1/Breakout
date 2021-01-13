using UnityEngine;
using UnityEngine.UI;


public class BallSpawner : MonoBehaviour {

    // declaring variables and setting value

    public Text gameOver;

    public Ball ballTemplate;

    public crazyBall crazyBallTemplate = null;

    public int lives = 3;

    public void SpawnBall(Ball templateToCopy)
    {
        // gets a clone of the template game object 
        Ball ballClone = Instantiate(templateToCopy);

        // sets the ball clones position to that of the ball spawner
        ballClone.transform.position = transform.position;

        // sets the direction of the ball
        int angle = 60;

        // this calls the function that calculates the angle 
         ballClone.SetDirection(angle);

        // this activates the ball clone
         ballClone.gameObject.SetActive(true);

    }
    
    // this calls the fucntion that spawns balls when game starts 
    void Start()
    {
        ballChance();
    }

   public void ballChance()
    {
        //  25% chance that a crazyBall will spawn 
        if (Random.Range(0, 100) <= 25)
        { 
            SpawnBall(crazyBallTemplate);
        }
        // spawns Ball
        else
            SpawnBall(ballTemplate);
    }
    
    public void DespawnBall(Ball ballToDespawn)
    {
       // destroy the Ball object
        Destroy(ballToDespawn.gameObject);
    }

    public void endGame()
    {
        //activates Game Over text 
            gameOver.gameObject.SetActive(true);   
    }

   
}
        


