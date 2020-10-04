using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menuPanel, gamePanel;

    public void TogglePanels()
    {
        menuPanel.SetActive(!menuPanel.activeInHierarchy);
        gamePanel.SetActive(!gamePanel.activeInHierarchy);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene("Main");
    }

}