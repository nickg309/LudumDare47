using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBullet : MonoBehaviour
{
    public float bulletSpeed;
    Vector3 target;

    public void Shoot(Vector3 incTarget)
    {
        target = incTarget;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            collision.gameObject.GetComponent<ZombieControls>().TakeDamage(5);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            if (collision.gameObject.GetComponent<ZombieControls>().health <= 0)
            {
                PlayerControls.scoreValue += 100;
                int i = Random.Range(1, 101);
                if (i > 90)
                {
                    GameObject healthOrb = ObjectPooler.SharedInstance.GetPooledHealthOrb();
                    if (healthOrb != null)
                    {
                        healthOrb.transform.position = collision.gameObject.transform.position;
                        healthOrb.transform.rotation = collision.gameObject.transform.rotation;
                        healthOrb.SetActive(true);
                    }
                }
                collision.gameObject.SetActive(false);
                SoundBoard.SharedSoundBoard.ZombieDeath();
            }
            else
            {
                SoundBoard.SharedSoundBoard.BulletHit();
            }
            gameObject.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        if (target!=null)
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, target, bulletSpeed * Time.deltaTime);
        }
        
        if (transform.position == target)
        {
            gameObject.SetActive(false);
        }
    }
}