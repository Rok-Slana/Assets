using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public Vector3 startingPoint;
    public Vector3 endingPoint;
    
    public float speed;
    private Vector3 movement;
    
    public bool switchSide = false;
    
    void Start()
    { 
        this.transform.position = startingPoint;
        movement = endingPoint * speed;
    }

    void Update()
    {
        //always move object
        if(transform.position.x > endingPoint.x && !switchSide || transform.position.x < startingPoint.x && switchSide) this.transform.Translate(movement * speed);     
        
        //switch direction when position on one of two given points
        if(transform.position.x <= endingPoint.x || transform.position.x >= startingPoint.x)    SwitchDirection();
    }
    
    private void SwitchDirection()
    {
        switchSide = !switchSide;
        movement*=-1;
    }
}
