using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedAI : MonoBehaviour
{
    public float Distance;
    public Transform Target;
    public float lookAtDistance = 25.0f;
    public float chaseRange = 15.0f;
    public float attackRange = 1.5f;
    public float moveSpeed = 2.0f;
    public float Damping = 6.0f;
    public float attackRepeatTime = 1.0f;

    public int TheDamage = 40;

    public CharacterController controller;
    public float gravity = 20.0f;

    private MeshRenderer mr;
    private Vector3 MoveDirection = Vector3.zero;

    private float attackTime;

    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        attackTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (RespawnMenu.playerIsDead == false)
        {
            Distance = Vector3.Distance(Target.position, transform.position);
            if (Distance < lookAtDistance)
            {
                lookAt();
            }

            if (Distance > lookAtDistance)
            {
                mr.material.color = Color.green;
            }

            if (Distance < attackRange)
            {
                attack();
            }
            else if (Distance < chaseRange)
            {
                chase();
            }
        }
    }

    private void lookAt()
    {
        mr.material.color = Color.yellow;
        Quaternion rotation = Quaternion.LookRotation(Target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);
    }

    private void chase()
    {
        mr.material.color = Color.red;
        
        //transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        Vector3 moveDirection = transform.forward;
        moveDirection *= moveSpeed;
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    private void attack() {
        if (Time.time > attackTime)
        {
            Target.SendMessage("ApplyDamage", TheDamage, SendMessageOptions.DontRequireReceiver);
            Debug.Log("The ennemy has attacked");
            attackTime = Time.time + attackRepeatTime;
        }
    }

    public void ApplyDamage(int TheDamage) {
        // enrage the ennemy
        chaseRange += 30.0f;
        moveSpeed += 2.0f;
        lookAtDistance += 40.0f;
    }
}
