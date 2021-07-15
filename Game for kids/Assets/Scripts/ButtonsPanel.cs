using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsPanel : MonoBehaviour
{
    public GameObject GameButtons;
    public GameObject GamePanel;
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Skip()
    {
        GamePanel.GetComponent<Panel>().NextLevel();
    }
}
