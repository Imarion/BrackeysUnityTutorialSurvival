using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISimple : MonoBehaviour
{
    public float Distance;
    public Transform Target;
    public float lookAtDistance = 25.0f;
    public float attackRange = 15.0f;
    public float moveSpeed = 2.0f;
    public float Damping = 6.0f;

    private MeshRenderer mr;

    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Distance = Vector3.Distance(Target.position, transform.position);
        if (Distance < lookAtDistance) {
            mr.material.color = Color.yellow;
            lookAt();
        }

        if (Distance > lookAtDistance) {
            mr.material.color = Color.green;
        }

        if (Distance < attackRange) {
            mr.material.color = Color.red;
            attack();
        }
    }

    private void lookAt() {
        Quaternion rotation = Quaternion.LookRotation(Target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);
    }

    private void attack() {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}
