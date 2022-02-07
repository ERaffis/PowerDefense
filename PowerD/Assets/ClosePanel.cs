using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanel : MonoBehaviour
{
    public GameObject raycastBlocker;
    public GameObject infoPanel;

    public void Close()
    {
        raycastBlocker.SetActive(false);
        Time.timeScale = 1;
        infoPanel.SetActive(false);
    }
}
