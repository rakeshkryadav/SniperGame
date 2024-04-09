using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    [SerializeField] private string animalName;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private Transform centerPos;
    [SerializeField] private int range = 3;
    public bool isdead = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Right
        Ray ray0 = new Ray(centerPos.transform.position, centerPos.transform.TransformDirection((Vector3.forward) * range) + centerPos.transform.right * 0.3f);
        Debug.DrawRay(centerPos.transform.position, centerPos.transform.TransformDirection((Vector3.forward) * range) + centerPos.transform.right * 0.3f, Color.green);
        
        // Center
        Ray ray1 = new Ray(centerPos.transform.position, centerPos.transform.TransformDirection(Vector3.forward * range));
        Debug.DrawRay(centerPos.transform.position, centerPos.transform.TransformDirection(Vector3.forward * range), Color.green);

        // Left
        Ray ray2 = new Ray(centerPos.transform.position, centerPos.transform.TransformDirection((Vector3.forward) * range) + centerPos.transform.right * -0.3f);
        Debug.DrawRay(centerPos.transform.position, centerPos.transform.TransformDirection((Vector3.forward) * range) + centerPos.transform.right * -0.3f, Color.green);

        if(Physics.Raycast(ray0, out RaycastHit hit0, range)){
            if(hit0.collider.tag == "Tree"){
                gameObject.transform.Rotate(-Vector3.up * rotateSpeed * Time.deltaTime);
            }
            else if(hit0.collider.tag == "Wall"){
                gameObject.transform.Rotate(-Vector3.up * 170);
            }
        }

        if(Physics.Raycast(ray1, out RaycastHit hit1, range)){
            if(hit1.collider.tag == "Tree"){
                gameObject.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
            }
            else if(hit1.collider.tag == "Wall"){
                gameObject.transform.Rotate(Vector3.up * 170);
            }
        }

        if(Physics.Raycast(ray2, out RaycastHit hit2, range)){
            if(hit2.collider.tag == "Tree"){
                gameObject.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
            }
            else if(hit2.collider.tag == "Wall"){
                gameObject.transform.Rotate(Vector3.up * 170);
            }
        }


        if(!isdead){
            gameObject.GetComponent<Animator>().Play(animalName + "_Movement");
            gameObject.transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
        }
        else{
            gameObject.GetComponent<Animator>().Play(animalName + "_Dead");
        }
    }
}
