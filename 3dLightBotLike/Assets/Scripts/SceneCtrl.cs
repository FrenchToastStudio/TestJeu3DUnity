using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SceneCtrl : MonoBehaviour
{
    [SerializeField] private GameObject UIgameplay;
    [SerializeField] private UiController UiController;

    public void perdu(){
        SceneManager.LoadScene("ScenePerdu");
    }

    public void chargerScene(string sceneName) {
        SceneManager.LoadSceneAsync(sceneName);
        UiController.reset();
    }

    public void quitterjeu() {
        Application.Quit();
    }

}
