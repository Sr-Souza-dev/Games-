using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class projetil : MonoBehaviour
{
    private Rigidbody myRigidbody;

    private GameObject[] planets;
    private Transform planet;

    public int potent = 24;

    private float forcaGMax;
    private double forcaGplanet;
    private Vector3 directionG;

    private double massPlanet = 0;
    private double distanceP;

    private double G = (6.67384f * Math.Pow(10,-11));

    
    void Start() {
        myRigidbody = GetComponent<Rigidbody>();
    }

    void Update() {
        planets = GameObject.FindGameObjectsWithTag("planets");

        forcaGMax = 0;
        foreach(GameObject planetAux in planets){
            massPlanet = planetAux.GetComponent<Rigidbody>().mass * Math.Pow(10,potent);
            distanceP = Vector3.Distance(planetAux.transform.position, transform.position) * 1.3f;
            forcaGplanet = ( G * massPlanet * GetComponent<Rigidbody>().mass) / Math.Pow(distanceP, 2);

            if(forcaGplanet > forcaGMax){
                forcaGMax = Convert.ToSingle(forcaGplanet);
                planet = planetAux.transform.GetChild(0);
            }
        }
        directionG = planet.position - transform.position;
        directionG = new Vector3(directionG.x * forcaGMax, directionG.y * forcaGMax, directionG.z * forcaGMax);

        myRigidbody.AddForce(directionG);
    }

    private void OnTriggerEnter(Collider other){
        if(other.tag.Equals("planets")){
            Destroy(gameObject);
        }
    } 
}
