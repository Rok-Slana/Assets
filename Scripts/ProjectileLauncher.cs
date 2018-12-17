using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileLauncher : MonoBehaviour
{
    //Final Text Holder
    public Text powerText;
    //Select your Fire Button of choice in the inspector
    public KeyCode fireButton;
    //Set max force applied to the projectile
    public float applyForce;
    //Set the direction of the applied force
    public Vector3 direction;
    //String for storing new Power value
    private string newPowerText;
    //Set max power multiplier here
    private float maxPower = 1.0f;
    //Current power stored here
    private float power = 0;
    //final force applied to the projectile
    private Vector3 fireForce;
    
    void Update()
    {
        //Check if player is holding the fire button & fire
        if(Input.GetKey(fireButton)) SetForce();
        if(Input.GetKeyUp(fireButton))
        {
            Fire();
            power = 0;
            DisplayPowerText();
        }       
    }
    
    //Get fire power mulitplier
    private void SetForce()
    {
        if(power<maxPower)          power+=Time.deltaTime;
        else if(power>=maxPower)    power = 1;
        DisplayPowerText();
    }
    
    //Translate current power to text on screen
    private void DisplayPowerText(){
            newPowerText = power.ToString();
            powerText.text = newPowerText;
    }
    
    //Add force to the projctile
    private void Fire()
    {
        fireForce = direction*applyForce*power;
        gameObject.GetComponent<Rigidbody>().AddForce(fireForce);
    }
    
    
}
