using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetRésolutionCtrl : MonoBehaviour
{
    private bool compléterNiveau = false;
    private int nombreDeCoup = 0;
    private float rotationGauche = -90.0f;
    private float rotationDroite = 90.0f;
    private Vector3 destination;

    private float uniteDeplacement;
    private float hauteurSaut;
    private float uniteDeplacementSaut;


    private void OnCollisionEnter(Collision collision){

        if(collision.gameObject.tag == "sol") {
            Destroy(this);
        }
        if(collision.gameObject.tag == "fin") { 
            compléterNiveau = true;
        }
    }

    public bool getCompléterNiveau() {
        return compléterNiveau;
    }

    public int getNombreDeCoup() { 
        return nombreDeCoup;
    }

    public void ajouterCoup() {
        nombreDeCoup += 1;
    }

    public void avancer() {
        destination = transform.position + (transform.forward);
        this.transform.position = destination;
    }

    public void tournerGauche() { 
        tourne(rotationGauche);
        avancer();
    }

    public void tournerDroite() { 
        tourne(rotationGauche);
        avancer();
    }

    public void sauter() {
        destination = transform.position + (transform.forward);
        destination = new Vector3(destination.x, this.transform.position.y + hauteurSaut, destination.z)
        this.transform.position = destination;
    }

    public void sauterGauche() {
        tourne(rotationGauche);
        sauter();
    }

    public void sauterDroite() {
        tourne(rotationDroite);
        sauter();
    }

    public void tourne (float rotation){
        transform.Rotate(Vector3.up, rotation);
    }

    public void setUniteDeplacement(float unFloat) {
        uniteDeplacement = unFloat;
    }

    public void setHauteurSaut(float unFloat) {
        hauteurSaut = unFloat;
    }


    public void setUniteDeplacementSaut(float unFloat) {
        uniteDeplacementSaut = unFloat;
    }

}
