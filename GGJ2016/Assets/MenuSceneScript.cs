using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuSceneScript : MonoBehaviour {

    public void Play(){
        SceneManager.LoadScene("Main");
    }
}
