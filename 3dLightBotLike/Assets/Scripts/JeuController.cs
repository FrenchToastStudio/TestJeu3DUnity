using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeuController : MonoBehaviour
{
    public GameObject UIgameplay;
    public GameObject personnage;
    public Animator animateur;
    // Start is called before the first frame update
    Vector3 destination;
    Vector3 positionDepart;

    bool go = false;
    bool mouvementEnCours;


    private List<String> sequence = new List<string>();

    public void setMouvementGauche(){
        sequence.Add("Gauche");  
    }

    public void setMouvementAvance(){
        sequence.Add("Avance");

                
    }

    public void setMouvementDroite(){
        sequence.Add("Droite");  
    }

    public void setMouvementSaut(){
        sequence.Add("Saut");  
    }

    public void LancerSequence(){
        go = true;
        printSequence();
        update();
    }

    public void printSequence(){
        foreach (String mouvement in sequence){
            print("mouvement ajouté: " + mouvement);
        }
    }

    void update(){

        positionDepart = personnage.transform.position;

        if(positionDepart == destination){
            animateur.SetBool("marche", false);
            print("personnage arrivé");
        }

        if (go){
            foreach (String mouvement in sequence){
                print("mouvement: " + mouvement);

                if(mouvement == "Avance"){
                    destination = positionDepart + (personnage.transform.forward * 1);
                    animateur.SetBool("marche", true);
                    StartCoroutine (deplacement (personnage, destination, 0.4f));
                    
                    
                } else if(mouvement == "Saut"){
                    animateur.SetBool("saute", true);
                    animateur.SetBool("estAuSol", false);
                    personnage.GetComponent<Rigidbody>().AddForce(Vector3.up * 5, ForceMode.Impulse);
                    personnage.GetComponent<Rigidbody>().AddForce(personnage.transform.forward * 1, ForceMode.Impulse);
                }




            }
        }




    }

    public IEnumerator deplacement (GameObject personnage, Vector3 end, float speed){
        
        while (personnage.transform.position != end){
            mouvementEnCours = true;
            personnage.transform.position = Vector3.MoveTowards(personnage.transform.position, end, speed * Time.deltaTime); 
            yield return new WaitForEndOfFrame ();
        }
        animateur.SetBool("marche", false);
        mouvementEnCours = false;
    }

}
