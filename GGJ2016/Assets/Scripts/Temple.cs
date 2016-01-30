using UnityEngine;
using System.Collections;

public class Temple : MonoBehaviour {

    private void Update(){
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            RaiseTemple();
        }else if(Input.GetKeyDown(KeyCode.DownArrow)){
            LowerTemple();
        }
    }

    public void RaiseTemple(){
        LeanTween.moveLocalY(gameObject, transform.localPosition.y + 1.6f, 1).setEase(LeanTweenType.easeOutQuad);
        ShakeCamera();
    }

    public void LowerTemple(){
        LeanTween.moveLocalY(gameObject, transform.localPosition.y - 1.6f, 1).setEase(LeanTweenType.easeOutQuad);
        ShakeCamera();
    }

    private void ShakeCamera(){
        Camera.main.GetComponent<CameraShaker>().Shake(0.13f, 0.8f);
    }
}
