using UnityEngine;
using System.Collections;
using System;

public class Enemy : MonoBehaviour {

	private float stunTimer;
	private Coroutine moveRoutine;

	public Vector3 _direction;
	public Quaternion _lookRotation;
	private float rotationSpeed = 5;

	private EnemyManager enemyManager;

    [SerializeField]
    private GameObject enemyModel;

    [SerializeField]
    private GameObject enemyRagdolModel;

    [SerializeField]
    private GameObject dizzyParticles;
    [SerializeField]
    private GameObject SoulPrefab;

    // Use this for initialization
    void Start () {
        enemyManager = FindObjectOfType<EnemyManager>();
	}

	private void Update(){
        dizzyParticles.SetActive(stunTimer > 0);
        dizzyParticles.transform.Rotate(Vector3.up, 3);

		//Rotate enemy to where he's going
		this.transform.rotation = Quaternion.Slerp(transform.rotation, this._lookRotation, Time.deltaTime * rotationSpeed);
	}
	
    public void Spawn(Vector3 position)
    {
        transform.localPosition = position;
		moveRoutine = StartCoroutine(MoveRoutine());
		Sound sound = new Sound (transform.root.gameObject.GetComponent<AudioSource> (), "SFX/" + "Spawn", 1f);
    }

	public void Pause() {
		StopCoroutine(moveRoutine);
	}
	public void Continue() {
		moveRoutine = StartCoroutine(MoveRoutine());
	}

	public void Stun(float time) {
		stunTimer = time;
        if(moveRoutine != null){
            StopCoroutine(moveRoutine);
        }
		moveRoutine = StartCoroutine(MoveRoutine());
	}

    public void Kill(bool gainExperience, bool playSound = true)
	{   
        stunTimer = 0;
		int rand = (int)UnityEngine.Random.Range(1, 40);
        if(playSound){
            if (rand == 36) {
                Sound sound = new Sound (transform.root.gameObject.GetComponent<AudioSource> (), "SFX/" + "WilhelmScream", 1f);
            } else {
                Sound sound = new Sound (transform.root.gameObject.GetComponent<AudioSource> (), "SFX/" + "Kill", 1f);
            }
        }
		
        if(gainExperience){
            PlayerManager.instance.AddExperience();
            GameObject soul = GameObject.Instantiate(SoulPrefab);
            soul.transform.position = transform.position;
        }

        Tile tile = enemyManager.GetTileOfEnemy(this);
        if(tile != null){
            tile.enemy = null;
        }

        StopAllCoroutines();
        LeanTween.cancel(gameObject);


        FallApart();
    }

    public void TryMove(){
        enemyManager.MoveEnemyToNewPosition(this);
    }

    public void ForceMove(Vector3 position){
        StopCoroutine(moveRoutine);
        Move(position, delegate {
            StartCoroutine(MoveRoutine());
        });
    }

    public void Move(Vector3 position, Action callback = null){

        Vector3 airPosition = transform.localPosition + (position - transform.localPosition) / 3;
        airPosition += new Vector3(0, 2.3f, 0);
        LeanTween.moveLocal(gameObject, transform.localPosition + new Vector3(0, 0.05f, 0), 0.5f).onComplete = delegate {
            PlaySound();
            LeanTween.moveLocal(gameObject, airPosition, 0.12f).setEase(LeanTweenType.easeOutSine).onComplete = delegate {
                LeanTween.moveLocal(gameObject, position, 0.25f).setEase(LeanTweenType.easeInSine).onComplete = callback;
            };
        };

    }
    private IEnumerator Shake(float seconds, float amount){
        float time = 0;

        while(time < seconds){
            Vector3 ownPosition = transform.localPosition;

            yield return new WaitForSeconds(0.01f);

            transform.localPosition = ownPosition + (UnityEngine.Random.insideUnitSphere * amount);
            time += Time.deltaTime;
        }

    }

    private IEnumerator MoveRoutine(){
        while(true){
            if (stunTimer > 0) {
				stunTimer -= Time.deltaTime;
				yield return new WaitForEndOfFrame();
			} else {
                Animation animation = GetComponentInChildren<Animation>();
                animation.Stop();
				yield return new WaitForSeconds(2);
                StartCoroutine(Shake(0.5f, 0.035f));
                animation.Play();
				yield return new WaitForSeconds(0.4f);
				TryMove();
			}
        }
    }

    private void FallApart(){
        Renderer[] renderers = enemyRagdolModel.transform.GetComponentsInChildren<Renderer>();

        Destroy(enemyModel.gameObject);
        enemyRagdolModel.SetActive(true);

        foreach(Renderer renderer in renderers){
            renderer.gameObject.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            Rigidbody body = renderer.gameObject.AddComponent<Rigidbody>();
            BoxCollider collider = renderer.gameObject.AddComponent<BoxCollider>();
            collider.size /= 5;

            if(body != null){
                body.AddForce(UnityEngine.Random.insideUnitSphere * 2 + Vector3.up, ForceMode.Impulse);
            }
        }

        StartCoroutine(FadeOut());


        Animator animator = transform.GetComponentInChildren<Animator>();
        Destroy(animator);
    }

    public IEnumerator FadeOut(){
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    public void Stampede(){
        Pause();
        Vector3 position = transform.localPosition;

        LeanTween.moveLocalY(gameObject, position.y + 1, 0.14f).setEase(LeanTweenType.easeOutSine).setLoopPingPong(5).onComplete = delegate {
        };
        StartCoroutine(StampedeSoundRoutine());
    }

    private IEnumerator StampedeSoundRoutine(){
        for(int i = 0; i < 5; i++)
        {
            Camera.main.transform.parent.GetComponent<CameraShaker>().Shake(0.15f, 0.20f);
            PlaySound();
            yield return new WaitForSeconds(0.28f);
        }
    }

    private void PlaySound(){
        int rand = (int)UnityEngine.Random.Range (1, 3);
        if (rand == 1) {
            new Sound (transform.root.gameObject.GetComponent<AudioSource> (), "SFX/" + "Hoo", 0.5f);
        } else {
            new Sound (transform.root.gameObject.GetComponent<AudioSource> (), "SFX/" + "Haa", 0.5f);
        }
    }
}
