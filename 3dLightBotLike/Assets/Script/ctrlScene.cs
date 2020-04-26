using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ctrlFinNiveau : MonoBehaviour
{

    [SerializeField] Button loadSceneBtn;

    public void chargerScene(string sceneName) {
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void quitterjeu() {
        Application.Quit();
    }

}
