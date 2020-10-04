using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieControls : MonoBehaviour
{
    public int health, damage;
    public float speed;
    public GameObject player;

    public void TakeDamage(int incDamage)
    {
        health -= incDamage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerControls>().Damage(damage);
            Vector3 moveDirection = gameObject.transform.position - collision.transform.position;
            collision.rigidbody.AddForce(moveDirection.normalized * -0.5f, ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        gameObject.transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
}