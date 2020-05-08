using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RésolutionCtrl : MonoBehaviour
{
    [SerializeField]
    private GameObject personnage;
    [SerializeField]
    private GameObject résolution;


    List<GameObject> listeRésolutions;

    int coupMinimum = 0;

    // Start is called before the first frame update
    private void Start() {

        listeRésolutions = new List<GameObject>();
        listeRésolutions.Add(résolution);

        personnage.SetActive(false);

    }

    // Update is called once per frame
    private void Update() {

        if((coupMinimum == 0)) { 
            foreach(GameObject uneRésolution in listeRésolutions) {
                if(uneRésolution == null){
                    listeRésolutions.Remove(uneRésolution);
                } else {
                    if(!uneRésolution.GetComponent<ObjetRésolutionCtrl>().getEnMouvement()) {
                        if(uneRésolution.GetComponent<ObjetRésolutionCtrl>().getCompléterNiveau()) {
                                coupMinimum = uneRésolution.GetComponent<ObjetRésolutionCtrl>().getNombreDeCoup();
                                Destroy(uneRésolution);
                                Debug.Log("Réeussi");
                        } else {
                            cloner(uneRésolution);
                            Destroy(uneRésolution);
                        }
                    }
                }
            }
        } else {
            foreach(GameObject uneRésolution in listeRésolutions) {
                Destroy(uneRésolution);
            }
            personnage.SetActive(true);
            Debug.Log("Nombre de ocup minimum final: " + coupMinimum);
        }
    }

    private void cloner(GameObject unObjetACloner) {
        unObjetACloner.SetActive(false);
        GameObject clone1 = Instantiate(unObjetACloner) as GameObject;
        clone1.SetActive(true);
        clone1.GetComponent<ObjetRésolutionCtrl>().setNombreDeCoup(unObjetACloner.GetComponent<ObjetRésolutionCtrl>().getNombreDeCoup());
        clone1.GetComponent<ObjetRésolutionCtrl>().avancer();
        listeRésolutions.Add(clone1);

        GameObject clone2 = Instantiate(unObjetACloner) as GameObject;
        clone2.SetActive(true);
        clone2.GetComponent<ObjetRésolutionCtrl>().setNombreDeCoup(unObjetACloner.GetComponent<ObjetRésolutionCtrl>().getNombreDeCoup());
        clone2.GetComponent<ObjetRésolutionCtrl>().tournerGauche();
        listeRésolutions.Add(clone2);

        GameObject clone3 = Instantiate(unObjetACloner) as GameObject;
        clone3.SetActive(true);
        clone3.GetComponent<ObjetRésolutionCtrl>().setNombreDeCoup(unObjetACloner.GetComponent<ObjetRésolutionCtrl>().getNombreDeCoup());
        clone3.GetComponent<ObjetRésolutionCtrl>().tournerDroite();
        listeRésolutions.Add(clone3);

        // GameObject clone2 = Instantiate(unObjetACloner) as GameObject;
        // clone2.SetActive(true);
        // clone2.GetComponent<ObjetRésolutionCtrl>().tournerGauche();
        // if(clone2 != null)
        //     listeRésolutions.Add(clone2);
        //     clone2.GetComponent<ObjetRésolutionCtrl>().ajouterCoup();

        // GameObject clone3 = Instantiate(unObjetACloner) as GameObject;
        // clone3.SetActive(true);
        // clone3.GetComponent<ObjetRésolutionCtrl>().tournerDroite();
        // if(clone3 != null)
        //     listeRésolutions.Add(clone3);
        //     clone3.GetComponent<ObjetRésolutionCtrl>().ajouterCoup();


    }
}
