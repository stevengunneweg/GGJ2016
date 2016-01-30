﻿using UnityEngine;
using System.Collections;

public class CameraMover : MonoBehaviour {
	
    private const LeanTweenType tweenType = LeanTweenType.easeOutQuad;
    private const float time = 0.2f;

    private bool tweening = false;
    Quaternion _targetRot;
    float _lerpTime = 1;
    float _startLerpTime = 0;

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

            float t = (Time.time - _startLerpTime) / _lerpTime;
            t = t * t * t * (t * (6f * t - 15f) + 10f);


            float diff = (_targetRot.eulerAngles.y - transform.rotation.eulerAngles.y);
            if (diff > 270)
                diff = -90;
            if (diff < -270)
                diff = 90;
            float angle = (diff) * t;
             if (diff > 0.05|| diff < -0.05)
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
        _startLerpTime = Time.time;
    }

    private void MoveLeft(){
        _targetRot = transform.rotation * Quaternion.Euler(0, -90, 0);
        tweening = true;
        _startLerpTime = Time.time;
    }
}