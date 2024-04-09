using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    [SerializeField] private ParticleSystem fireEffect;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float slowdownFactor = 0.01f;
    [SerializeField] private Transform muzzle;
    [SerializeField] private Transform cameraPos;
    [SerializeField] private int bulletRange = 100;
    [SerializeField] private GameObject player;
    [SerializeField] private float delayTime = 10f;
    public RaycastHit hit;
    public GameManagerScript gameManger;
    bool fireState = true;
    // Start is called before the first frame update

    void Awake(){
        fireEffect.Stop();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameManger.gamePause){
            Aiming();
            Scoping();
            Firing();
        }
    }

    void Aiming(){
        if(Physics.Raycast(cameraPos.position, transform.TransformDirection(Vector3.forward), out hit, bulletRange)){
            Debug.DrawRay(cameraPos.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
        }
    }

    void Scoping(){
        if(Input.GetMouseButtonDown(1)){
            player.GetComponent<Animator>().Play("Aim");
        }
        else if(Input.GetMouseButtonUp(1)){
            player.GetComponent<Animator>().Play("Aim Out");
        }
    }

    void Firing(){
        if(Input.GetMouseButtonDown(0) && fireState){
            Time.timeScale = slowdownFactor;
            fireEffect.Play();
            fireState = false;

            Instantiate(bullet, muzzle.position, muzzle.rotation);
            Invoke("Recharging", delayTime);
        }
    }

    void Recharging(){
        fireState = true;
    }
}
