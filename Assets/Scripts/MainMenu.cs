using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject recordsPanel, menuPanel;
    [SerializeField] TMPro.TextMeshProUGUI textRecord;



    public void PlayButton()
    {
        SceneManager.LoadScene("Nivel1");
        audioSource.Play();
    }


    public void ShowRecords()
    {
        if (menuPanel.activeSelf)
        {
            menuPanel.SetActive(false);
            recordsPanel.SetActive(true);
        }
        textRecord.text = "1: " + SaveManager.LoadRecord()[0];

        textRecord.text += "2: " + SaveManager.LoadRecord()[1];

        textRecord.text += "3: " + SaveManager.LoadRecord()[2];

        textRecord.text += "4: " + SaveManager.LoadRecord()[3];

        textRecord.text += "5: " + SaveManager.LoadRecord()[4];
    }

    public void ShowMenu()
    {
        if (recordsPanel.activeSelf)
        {
            recordsPanel.SetActive(false);
            menuPanel.SetActive(true);
        }
    }
}
