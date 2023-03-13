using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip, errorSound;
    public GameObject explosionPrefab, malusExplosion;
    public ClickOn clickOn;
    private void Start()
    {
        clickOn = FindObjectOfType<ClickOn>();
    }
    
    public void PlayParticles(string _string)
    {
        if(_string == "Bonus")
            Instantiate(explosionPrefab, ClickOn.position, Quaternion.identity);
        else if(_string == "Malus")
            Instantiate(malusExplosion, ClickOn.malusPosition, Quaternion.identity);
    }
    public void PlaySoundOnDie()
    {
        audioSource.PlayOneShot(audioClip);
    }
    public void PlayErrorSound()
    {
        audioSource.PlayOneShot(errorSound);
    }
}
