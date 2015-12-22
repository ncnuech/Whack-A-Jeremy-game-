using UnityEngine;
using System.Collections;

public class MouseFollow : MonoBehaviour {

    public Sprite hammerTexture;
    // Cursor
    CursorMode cursorThing;

    // Use this for initialization
	void Start () {
        cursorThing = CursorMode.Auto;
	}
	
	// Update is called once per frame
	void Update () {
        
        Vector2 mousePos = Input.mousePosition;
        //transform.position = mousePos;
        
        Cursor.SetCursor(hammerTexture.texture,mousePos, cursorThing);
    }

}
