using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Game()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Finished()
    {
        SceneManager.LoadScene("Finished");
    }
    public void Loose()
    {
        SceneManager.LoadScene("NoTime");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
