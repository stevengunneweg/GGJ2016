using UnityEngine;
using System.Collections;

public class LightningSpellEffect : BaseSpellEffect {

    [SerializeField]
    private GameObject plane;

    private void Start(){
    }

    private void Update(){
        plane.transform.LookAt(Camera.main.transform, Vector3.up);
        plane.transform.Rotate(90, 0, 0);
        plane.transform.rotation = Quaternion.Euler(new Vector3(90, plane.transform.rotation.eulerAngles.y, plane.transform.rotation.eulerAngles.z));
    }

	public override void ApplyEffectToEnemy(Enemy enemy) {
        FindObjectOfType<FlashPanel>().Flash(Color.white, 0.2f);
        plane.SetActive(true);
		enemy.Stun(2.0f);
        LeanTween.alpha(plane, 0, 0.75f);
        StartCoroutine(DestroyRoutine());
	}

    private IEnumerator DestroyRoutine(){
        yield return new WaitForSeconds(0.75f);
        Destroy(gameObject);
    }
}
