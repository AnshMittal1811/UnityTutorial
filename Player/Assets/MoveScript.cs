using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public Transform Goal;
    float speed = 0.5f;
    float accuracy = 1.0f;
    float rotSpeed = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 lookAtGoal = new Vector3(Goal.position.x,
                                         this.transform.position.y,
                                         Goal.position.z);
        Vector3 direction = lookAtGoal - this.transform.position;

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                Quaternion.LookRotation(direction), 
                                                Time.deltaTime*rotSpeed);

        if(Vector3.Distance(transform.position, lookAtGoal)>accuracy)
            this.transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
