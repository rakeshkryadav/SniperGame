using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int walkSpeed = 1;
    [SerializeField] private int runSpeed = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float currentSpeed;
        if(Input.GetKey(KeyCode.LeftShift)){
            currentSpeed = runSpeed;
        }
        else{
            currentSpeed = walkSpeed;
        }
        gameObject.transform.Translate(0f, 0f, Input.GetAxis("Vertical") * currentSpeed * Time.deltaTime);
    }
}
