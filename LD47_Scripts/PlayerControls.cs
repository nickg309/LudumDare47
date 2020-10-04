using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerControls : MonoBehaviour
{
    public static int scoreValue;
    public int health, orbHeal, score;
    public GameObject eventSystem, crossHairs, gameOverPanel, audioSource;
    public float speed;
    private Camera cam;
    public Text scoreDisplay, healthDisplay;
    bool paused;
    Vector3 target;
    Animator playerAnim;

    void Start()
    {
        Time.timeScale = 1;
        paused = false;
        UnityEngine.Cursor.visible = false;
        cam = Camera.main;
        playerAnim = gameObject.GetComponent<Animator>();
    }

    public void Damage(int incDamage)
    {
        health -= incDamage;
        SoundBoard.SharedSoundBoard.ZombieBite();
        if (health < 0)
        {
            health = 0;
        }
    }

    private void OnGUI()
    {
        Vector3 point = new Vector3();
        Event currentEvent = Event.current;
        Vector2 mousePos = new Vector2();
        mousePos.x = currentEvent.mousePosition.x;
        mousePos.y = cam.pixelHeight - currentEvent.mousePosition.y;

        point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));
        target = point;
        crossHairs.transform.position = point;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "HealingOrb")
        {
            SoundBoard.SharedSoundBoard.HealthOrb();
            health += orbHeal;
            if(health > 100)
            {
                health = 100;
            }
            collision.gameObject.SetActive(false);
        }
    }

    void PauseGame()
    {
        paused = true;
        Time.timeScale = 0;
        UnityEngine.Cursor.visible = true;
    }

    void Update()
    {
        scoreDisplay.text = scoreValue.ToString();
        healthDisplay.text = health.ToString();
        if (health <= 0 && paused == false)
        {
            SoundBoard.SharedSoundBoard.PlayerDeath();
            PauseGame();
            gameOverPanel.SetActive(true);
        }
        if (Input.GetKey(KeyCode.W)&&paused==false)
        {
            gameObject.transform.position = gameObject.transform.position + new Vector3(0,speed,0);
            playerAnim.SetBool("Moving", true);
        }
        if (Input.GetKey(KeyCode.A) && paused == false)
        {
            gameObject.transform.position = gameObject.transform.position + new Vector3(-speed, 0, 0);
            playerAnim.SetBool("Moving", true);
        }
        if (Input.GetKey(KeyCode.S) && paused == false)
        {
            gameObject.transform.position = gameObject.transform.position + new Vector3(0, -speed, 0);
            playerAnim.SetBool("Moving", true);
        }
        if (Input.GetKey(KeyCode.D) && paused == false)
        {
            gameObject.transform.position = gameObject.transform.position + new Vector3(speed, 0, 0);
            playerAnim.SetBool("Moving", true);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && paused == false)
        {
            GameObject bulletPistol = ObjectPooler.SharedInstance.GetPooledBullet();
            if (bulletPistol != null)
            {
                bulletPistol.transform.position = gameObject.transform.position;
                bulletPistol.transform.rotation = gameObject.transform.rotation;
                bulletPistol.SetActive(true);
                bulletPistol.GetComponent<PistolBullet>().Shoot(target);
                audioSource.GetComponent<SoundBoard>().Shoot();
            }
        }
        if (Input.GetKeyUp(KeyCode.W)||Input.GetKeyUp(KeyCode.A)||Input.GetKeyUp(KeyCode.S)||Input.GetKeyUp(KeyCode.D))
        {
            playerAnim.SetBool("Moving", false);
        }
    }
}