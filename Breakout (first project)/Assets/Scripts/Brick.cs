using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{

    // this function despawns the brick
    public void DespawnBrick()
    {
        gameObject.SetActive(false);
    }
}
