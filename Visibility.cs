using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visibility : MonoBehaviour
{
    
    //  For this class to work rendering mode of the     !!! 
    //  material of this gameObject must be set to fade   !!!

    public bool isVisible = true;
    
    private float time = 0.05f;    
    private float alphaVal;    
    private Renderer rend;    
    private Color color;
    
    void Start()
    {
        rend = GetComponent<Renderer>();
        color = rend.material.color;
        alphaVal = color.a;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) ChangeObjectVisibility();
        
        if(!isVisible && alphaVal>0)
        {
            alphaVal -= time;
            color.a = alphaVal;
            rend.material.color = color;

        }
        
        else if(isVisible && alphaVal<1)
        {
            alphaVal += time;
            color.a = alphaVal;
            rend.material.color = color;
            
        }
        else if(alphaVal<0) alphaVal = 0;
        else if(alphaVal>1) alphaVal = 1;
    }
    
    public void ChangeObjectVisibility()
    {
        isVisible = !isVisible;
        /*gameObject.SetActive(isVisible);*/
    }
}
