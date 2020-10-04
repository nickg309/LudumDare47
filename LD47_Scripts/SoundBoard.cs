using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBoard : MonoBehaviour
{
    public AudioClip button, shoot, bulletHit, zombieBite, zombieDeath, playerDeath, healthOrb;
    AudioSource speaker;
    public static SoundBoard SharedSoundBoard;

    void Awake()
    {
        SharedSoundBoard = this;
    }

    void Start()
    {
        speaker = GetComponent<AudioSource>();
    }

    public void ButtonSound()
    {
        speaker.clip = button;
        speaker.Play();
    }

    public void Shoot()
    {
        speaker.clip = shoot;
        speaker.Play();
    }

    public void BulletHit()
    {
        speaker.clip = bulletHit;
        speaker.Play();
    }

    public void ZombieBite()
    {
        speaker.clip = zombieBite;
        speaker.Play();
    }

    public void ZombieDeath()
    {
        speaker.clip = zombieDeath;
        speaker.Play();
    }

    public void PlayerDeath()
    {
        speaker.clip = playerDeath;
        speaker.Play();
    }

    public void HealthOrb()
    {
        speaker.clip = healthOrb;
        speaker.Play();
    }

}