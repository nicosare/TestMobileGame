using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
    GameObject volumeWindow;
    
    public void GoToScene(string sceneName) => SceneManager.LoadScene(sceneName);

    public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    public void SetActiveVolumeWindow(bool active) => volumeWindow.SetActive(active);

    private void Awake()
    {
        volumeWindow = GameObject.FindGameObjectWithTag("VolumeWindow");
        SetActiveVolumeWindow(false);
    }
}
