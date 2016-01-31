using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GoToNextScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(NextRoutine());
	}

    private IEnumerator NextRoutine(){
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Menu");
    }
}
