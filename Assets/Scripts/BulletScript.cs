using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private int bulletSpeed = 500;
    [SerializeField] private float range = 0.1f;
    [SerializeField] private LineRenderer trajectory;
    private int speed = 0;
    // Start is called before the first frame update
    void Start()
    {
        trajectory.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward * range));
        if(Physics.Raycast(ray, out RaycastHit hit, range)){
            if(hit.collider.tag == "Animal"){
                var deadAnimal = hit.collider.gameObject.GetComponent<AnimalMovement>();
                deadAnimal.isdead = true;
                // Debug.Log("Animal Dead");
                Time.timeScale = 1;
                Destroy(gameObject);
            }
            else if(hit.collider.tag == "Tree"){
                Time.timeScale = 1;
                Destroy(gameObject);
            }
        }

        trajectory.SetPosition(0, gameObject.transform.position);
        trajectory.SetPosition(1, gameObject.transform.forward * 100f);

        gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if(speed <= bulletSpeed){
            speed += 10;
        }
        Invoke("DestroyBullet", 0.2f);
    }

    void DestroyBullet(){
        Time.timeScale = 1;
        Destroy(gameObject);
    }
}
