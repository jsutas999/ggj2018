using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelBar : MonoBehaviour {
    public float fuel = 1;
    Vector2 pos = new Vector2(Screen.width-220, Screen.height-40);
    Vector2 size  = new Vector2(200,20);
    Texture2D progressBarEmpty;
    Texture2D progressBarFull;
 
 void OnGUI()
    {

        // draw the background:
        GUI.Label(new Rect(pos.x, pos.y - 20, 100, 50), "Fuel");
        GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), progressBarEmpty);

        // draw the filled-in part:
        GUI.BeginGroup(new Rect(0, 0, size.x * fuel, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), progressBarFull);
        GUI.EndGroup();

        GUI.EndGroup();

    }

    void Update()
    {
        // for this example, the bar display is linked to the current time,
        // however you would set this value based on your desired display
        // eg, the loading progress, the player's health, or whatever.
        //fuel = 1 - (Time.time * 0.05f);
        //if (Input.GetKey(KeyCode.W))
        //{

        //}

        //if (Input.GetKeyUp(KeyCode.W))
        //{

        //}
        
    }

    
}
