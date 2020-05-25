using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SceneCtrl : MonoBehaviour
{
    [SerializeField] GameObject UIgameplay;
    int niveau = 0;
    string niveauActuel = "Niveau1";

    public void AugmenterNiveau(){
        niveau += 1;
        PlayerPrefs.SetInt("niveau", niveau);
    }

    public void rejouer(){
        niveau = PlayerPrefs.GetInt("niveau");
        print(niveauActuel);
        if(niveau == 0)
            niveauActuel = "Niveau1";
        else if(niveau == 1)
            niveauActuel = "Niveau2"; 
        SceneManager.LoadScene(niveauActuel);
    }

    public void perdu(){
        SceneManager.LoadScene("ScenePerdu");
    }

    public void chargerScene(string sceneName) {
        if(sceneName == "Niveau1")
            PlayerPrefs.SetInt("niveau", 0);
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void quitterjeu() {
        Application.Quit();
    }

}
