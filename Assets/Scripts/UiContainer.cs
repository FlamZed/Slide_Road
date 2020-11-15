using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiContainer : MonoBehaviour
{
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject losePanel;
    [SerializeField] GameObject winPanel;

    // Start is called before the first frame update
    void Start()
    {
        startPanel.SetActive(true);
    }

    public void HideStart()
    {
        startPanel.SetActive(false);
    }

    public void LousePanel()
    {
        losePanel.SetActive(true);
    }

    public void WinPanel()
    {
        winPanel.SetActive(true);
    }
}
