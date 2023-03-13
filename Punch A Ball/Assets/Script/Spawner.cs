using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Spawner : MonoBehaviour
{
    public GameObject objectPrefab;
    public float zoneRange = 5;
    public float delay = .5f;
    public List<Material> objectMaterials;
    public int cooldownDelay = 2;
    public int endGameTimer = 20;
    public TextMeshProUGUI timerText;
    public TextMeshPro bigTimerText;

    private void Start()
    {
        StartCoroutine(BeforeGame());
        timerText.text = "Timer: " + endGameTimer + " sec";
        bigTimerText.text = endGameTimer.ToString();
    }
    IEnumerator BeforeGame()
    {
        yield return new WaitForSeconds(4);
        StartCoroutine(Spawn());
        StartCoroutine(EndGame());
    }
    IEnumerator Spawn()
    {
        Vector3 randomPosition = new Vector3(
            transform.position.x + Random.Range(-zoneRange, zoneRange),
            transform.position.y + 1f,
            transform.position.z + Random.Range(-zoneRange, zoneRange));
        GameObject spawnedObject = Instantiate(objectPrefab, randomPosition, Quaternion.identity);
        if (objectMaterials != null && objectMaterials.Count > 0) {
            int randomIndex = Random.Range(0, objectMaterials.Count);
            Renderer objectRenderer = spawnedObject.GetComponent<Renderer>();
            if (objectRenderer != null) {
                objectRenderer.material = objectMaterials[randomIndex];
            }
        }
        StartCoroutine(DestroyObject(spawnedObject));
        yield return new WaitForSeconds(delay);
        StartCoroutine(Spawn());
    }
    IEnumerator DestroyObject(GameObject objectToDestroy)
    {
        yield return new WaitForSeconds(cooldownDelay);
        if (objectToDestroy != null)
            Destroy(objectToDestroy);
    }
    IEnumerator EndGame()
    {
        while (endGameTimer > 0)
        {
            yield return new WaitForSeconds(1);
            endGameTimer--;
            timerText.text = "Timer: " + endGameTimer + " sec";
            bigTimerText.text = endGameTimer.ToString();
            if(endGameTimer == 0)
                SceneManager.LoadScene("NoTime");
        }
    }
}
