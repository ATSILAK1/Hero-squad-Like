using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    private int Hp = 100;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void takeDamage(int damage)
    {
        Hp -= damage;
        if (Hp <= 0)
        {
            Hp = 0;
            Destroy(gameObject);

        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Bullet") && !gameObject.CompareTag("Player"))
        {

            Debug.Log("hit enemy");
            Destroy(collider.gameObject);
        }

        if (collider.CompareTag("Player"))
        {
            takeDamage(10);
        }
    }

}
