using UnityEngine;
using System.Collections;

public class LightningSpellEffect : BaseSpellEffect {

    [SerializeField]
    private GameObject plane;
    private Light Sun;
    private float  _sunOrgIntense;
    private bool blackout = false;
    private ParticleSystem particlesys;
    private Light impactLight;


    private void Start(){
        Sun = GameObject.Find("Directional Light").GetComponent<Light>();

        particlesys = transform.Find("Bottom/Particle System").GetComponent<ParticleSystem>();
        impactLight = transform.Find("Bottom/Point light").GetComponent<Light>();

        _sunOrgIntense = Sun.intensity;
        SetEffect();
    }

    private void Update(){
        if (blackout)
            Sun.intensity -= (Sun.intensity-0.5f) * (Time.deltaTime * 20);
        else
            Sun.intensity += (_sunOrgIntense- Sun.intensity) * (Time.deltaTime * 20);
        plane.transform.LookAt(Camera.main.transform, Vector3.up);
        plane.transform.Rotate(90, 0, 0);
        plane.transform.rotation = Quaternion.Euler(new Vector3(90, plane.transform.rotation.eulerAngles.y, plane.transform.rotation.eulerAngles.z));
    }

    public override void ApplyEffectToEnemy(Enemy enemy)
    {
        enemy.Stun(3.0f);
    }

    private IEnumerator DestroyRoutine(){
        blackout = true;
        impactLight.enabled = true;
        yield return new WaitForSeconds(0.2f);
        blackout = false;
        impactLight.enabled = false;
        yield return new WaitForSeconds(0.75f);
        Sun.intensity = _sunOrgIntense;
        Destroy(gameObject);
    }
    void SetEffect()
    {
        FindObjectOfType<FlashPanel>().Flash(Color.white, 0.2f);
        plane.SetActive(true);
        LeanTween.alpha(plane, 0, 0.75f);
        particlesys.Play();
        StartCoroutine(DestroyRoutine());

        Camera.main.transform.parent.GetComponent<CameraShaker>().Shake(0.20f, 0.4f);

    }
}
