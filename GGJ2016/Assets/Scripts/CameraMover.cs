using UnityEngine;
using System.Collections;

public class CameraMover : MonoBehaviour {
	
    private const LeanTweenType tweenType = LeanTweenType.easeOutQuad;
    private const float time = 0.2f;

    private bool tweening = false;
    Quaternion _targetRot;

	private void Update () {
        if (!tweening)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                MoveRight();
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                MoveLeft();
            }
        }
        else {

            float diff = (_targetRot.eulerAngles.y - transform.rotation.eulerAngles.y);
            if (diff > 270)
                diff = -90;
            if (diff < -270)
                diff = 90;
            float angle = (diff) * (Time.deltaTime * 10);
             if (diff > 0.01|| diff < -0.01)
                transform.rotation *= Quaternion.Euler(0, angle, 0);
            else {
                transform.rotation = _targetRot;
                tweening = false;
            }
        }
        //Debug.Log(transform.rotation.eulerAngles);
    }


    private void MoveRight(){
        _targetRot =  transform.rotation * Quaternion.Euler(0, 90, 0);
        tweening = true;
    }

    private void MoveLeft(){
        _targetRot = transform.rotation * Quaternion.Euler(0, -90, 0);
        tweening = true;
    }
}
