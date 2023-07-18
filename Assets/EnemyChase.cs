using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyChase : MonoBehaviour
{
    private Transform target; // Référence au transform du joueur
    public float speed = 5f; // Vitesse de déplacement de l'ennemi

    private Rigidbody enemyRigidbody;
    // Référence au transform du joueur

    public float raycastDistance = 10f; // Distance maximale du raycast
    public Animator animator;

    private void Awake()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void RotationUpdate()
    {
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            Vector3 eulerRotation = lookRotation.eulerAngles;


            transform.rotation = Quaternion.Euler(0f, eulerRotation.y, 0f);
            Vector3 velocity = direction * speed * Time.fixedDeltaTime;


            enemyRigidbody.velocity = velocity;
        }
    }

    private void Update()
    {

        PlayerAnimation();
        RotationUpdate();
        // Vérifier si le joueur existe
        if (target != null)
        {
            // Calculer la direction vers le joueur
            Vector3 direction = (target.position - transform.position).normalized;

            // Effectuer le raycast pour détecter les obstacles
            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction, out hit, raycastDistance))
            {

                // Vérifier si l'obstacle rencontré est le joueur
                if (hit.transform == target)
                {
                    // L'ennemi peut voir le joueur, le poursuivre
                    speed = 5.0f;
                    Debug.Log("see the player");
                    transform.position += direction * speed * Time.deltaTime;
                    Debug.DrawRay(transform.position, direction * raycastDistance, Color.green);

                }
                else
                {
                    speed = 0f;
                }
            }
        }

    }


    void PlayerAnimation()
    {
        if (speed == 0f)
        {
            animator.SetFloat("isRunning", 0f);
        }
        else
        {
            animator.SetFloat("isRunning", 5f);
        }
    }

}
