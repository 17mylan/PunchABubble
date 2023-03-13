using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOn : MonoBehaviour
{
    public Manager manager;
    public ScoreManager scoreManager;
    public static Vector3 position;
    public static Vector3 malusPosition;
    private void Start()
    {
        manager = FindObjectOfType<Manager>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }
    private void OnMouseDown()
    {
        Renderer objectRenderer = gameObject.GetComponent<Renderer>();
        if (objectRenderer != null)
        {
            string materialName = objectRenderer.material.name;

            if(materialName == "Red (Instance)")
            {
                scoreManager.RemovePoints();
                manager.PlayErrorSound();
                malusPosition = transform.position;
                manager.PlayParticles("Malus");
            }


            if(materialName == "Yellow (Instance)")
            {
                scoreManager.AddPoints(20);
                position = transform.position;
                manager.PlayParticles("Bonus");
                manager.PlaySoundOnDie();
            }
            if(materialName == "Blue (Instance)")
            {
                scoreManager.AddPoints(30);
                position = transform.position;
                manager.PlayParticles("Bonus");
                manager.PlaySoundOnDie();
            }
            if(materialName == "Purple (Instance)")
            {
                scoreManager.AddPoints(40);
                position = transform.position;
                manager.PlayParticles("Bonus");
                manager.PlaySoundOnDie();
            }
            else
            {
                manager.PlaySoundOnDie();
                position = transform.position;
                manager.PlayParticles("Bonus");
                scoreManager.AddPoints(10);
            }
        }
        Destroy(gameObject);
    }
}