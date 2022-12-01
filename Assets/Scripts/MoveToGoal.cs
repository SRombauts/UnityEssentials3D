using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToGoal : MonoBehaviour
{
    public Transform goal;
    public float speed = 1.0f;
    public float accuracy = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update & LateUpdate are called once per frame, but the second is best to handle movements after physics etc
    void LateUpdate()
    {
        // Orient to the goal
        this.transform.LookAt(goal);
        Debug.DrawRay(this.transform.position, transform.forward, Color.blue);

        Vector3 direction = goal.position - this.transform.position;
        if (direction.sqrMagnitude > accuracy)
        {
            Debug.DrawRay(this.transform.position, direction, Color.red);

            this.transform.Translate(direction.normalized * Time.deltaTime * speed, Space.World);
        }
    }
}
