using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballcontroller : MonoBehaviour
{
    enum BallStates
    {
        idle,
        moving
    }
    BallStates ballStates;
    // Start is called before the first frame update
    void Start()
    {
        ballStates = BallStates.idle;
    }

    // Update is called once per frame
    void Update()
    {
        switch(ballStates)
        {
            case BallStates.idle:
                break;
            case BallStates.moving:
                break;
        }
    }
}
