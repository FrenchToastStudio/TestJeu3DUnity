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
    private Vector3 positionDepart;

    private bool enMarche = false;
    private bool enMouvement = false;
    private bool enSaut = false;
    private bool peutSauter = false;
    private bool àDétruire = false;
    private bool peuÊtreCloner = false;

    [SerializeField]
    private float uniteDeplacement;
    [SerializeField]
    private float hauteurSaut;
    [SerializeField]
    private float uniteDeplacementSaut;

    void Update() {

        if (peutSauter && !enSaut){
            peutSauter = false;
            enMarche = false;
            sauter();
        }

        if (enMarche){
            transform.position = Vector3.MoveTowards(transform.position, destination, 1f * Time.deltaTime);
        }


    }

    void LateUpdate() {
        if (transform.position.x == destination.x && transform.position.z == destination.z ) {
            enMarche = false;
            enMouvement = false;
            enSaut = false;
            peutSauter = false;
        }

        if(!enMarche && !peutSauter && !enSaut) {
            enMouvement = false;
        }

    }

    private void OnCollisionEnter(Collision collision){
        if(enSaut)
            enSaut = false;

        if(collision.gameObject.tag == "sol") {
            if(enMarche) {
                enMarche = false;
                peutSauter = true;
            } else {
                enMarche = false;
                àDétruire = true;
            }
        }

        if(collision.gameObject.tag == "fin") { 
            compléterNiveau = true;
            enMarche = false;
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
        ajouterCoup();
        enMouvement = true;
        enMarche = true;
        positionDepart = this.transform.position;
        destination = transform.position + (transform.forward);
    }

    public void tournerGauche() { 
        tourne(rotationGauche);
        avancer();
    }

    public void tournerDroite() { 
        tourne(rotationDroite);
        avancer();
    }

    public void sauter() {
        enMouvement = true;
        enSaut = true;
        this.transform.position = positionDepart;
        GetComponent<Rigidbody>().AddForce(Vector3.up * hauteurSaut, ForceMode.Impulse);
        GetComponent<Rigidbody>().AddForce(transform.forward * uniteDeplacement, ForceMode.Impulse);
    }

    public void tourne (float rotation){
        ajouterCoup();
        transform.Rotate(Vector3.up, rotation);
    }

    public void setUniteDeplacement(float unFloat) {
        uniteDeplacement = unFloat;
    }

    public void setHauteurSaut(float unFloat) {
        hauteurSaut = unFloat;
    }

    public void setNombreDeCoup(int unInt) {
        nombreDeCoup = unInt;
    }
    public void setUniteDeplacementSaut(float unFloat) {
        uniteDeplacementSaut = unFloat;
    }

    public bool getEnMouvement() {
        return enMouvement;
    }

    public bool getÀDétruire() {
        return àDétruire;
    }

}
