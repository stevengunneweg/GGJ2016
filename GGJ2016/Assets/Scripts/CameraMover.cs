using UnityEngine;
using System.Collections;

public class CameraMover : MonoBehaviour {
	
    private const LeanTweenType tweenType = LeanTweenType.easeOutQuad;
    private const float time = 0.2f;

    private bool tweening = false;

	private void Update () {
        if(!tweening){
            if(Input.GetKeyDown(KeyCode.A)){
                MoveRight();
            }else if(Input.GetKeyDown(KeyCode.D)){
                MoveLeft();
            }
        }
        //Debug.Log(transform.rotation.eulerAngles);
	}


    private void MoveRight(){
        transform.rotation *= Quaternion.Euler(0, 90, 0);
    }

    private void MoveLeft(){
        transform.rotation *= Quaternion.Euler(0, -90, 0);
    }
}
