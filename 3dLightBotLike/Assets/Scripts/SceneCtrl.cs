using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SceneCtrl : MonoBehaviour
{

    //[SerializeField] private static GameObject UIgameplay;
    [SerializeField] Button loadSceneBtn;
    [SerializeField] GameObject UIgameplay;
    [SerializeField] GameObject textPerdu;
    void Start()
    {

    }

    public void rejouer(){
        Debug.Log("run scene1");
        SceneManager.LoadScene("Scene1");
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
