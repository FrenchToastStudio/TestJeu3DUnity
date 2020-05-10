using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SceneCtrl : MonoBehaviour
{
    [SerializeField] GameObject UIgameplay;
    void Start()
    {

    }

    public void rejouer(){
        SceneManager.LoadScene("Niveau1");
    }

    public void perdu(){
        SceneManager.LoadScene("ScenePerdu");
    }



    public void chargerScene(string sceneName) {
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void quitterjeu() {
        Application.Quit();
    }

}
