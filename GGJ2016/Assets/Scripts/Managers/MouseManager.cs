using UnityEngine;
using System.Collections;

public class MouseManager : MonoBehaviour {
	public Texture2D cursorTexture;
	public Texture2D cursorTextureClick;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;
	void Update() {
		Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
		if (Input.GetMouseButton (0))
			Cursor.SetCursor(cursorTextureClick, hotSpot, cursorMode);
	}
	void Start(){
		Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
	}
}