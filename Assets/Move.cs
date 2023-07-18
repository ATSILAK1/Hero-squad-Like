using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    private Animator animator;
    public Rigidbody rigid;

    public float moveSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        nearestEnemy();
        playerMovement();



    }
    void playerMovement()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            animator.SetBool("isWalking", true);
            rigid.AddForce(transform.forward * moveSpeed, ForceMode.VelocityChange);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            animator.SetBool("isWalking", true);
            rigid.AddForce(-transform.right * moveSpeed, ForceMode.VelocityChange);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isWalking", true);
            rigid.AddForce(transform.right * moveSpeed, ForceMode.VelocityChange);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("isWalking", true);
            rigid.AddForce(-transform.forward * moveSpeed, ForceMode.VelocityChange);
        }
        else
            animator.SetBool("isWalking", false);
    }

    void nearestEnemy()
    {
        var enemies = GameObject.FindGameObjectsWithTag("enemy");
        float closestDistance = Mathf.Infinity;
        GameObject enemy = null;

        if (enemies != null)
        {
            foreach (var pos in enemies)
            {
                float distance = Vector3.Distance(pos.transform.position, transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    enemy = pos;
                }

            }
            Vector3 direction = (enemy.transform.position - transform.position).normalized;
            Quaternion lookDirection = Quaternion.LookRotation(direction);
            Vector3 eulerRotation = lookDirection.eulerAngles;
            transform.rotation = Quaternion.Euler(0f, eulerRotation.y, 0f);


        }
        else
        {
            return;
        }

    }
}
