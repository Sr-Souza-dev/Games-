using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameras : MonoBehaviour
{
    public Camera[] cameras;
    // Start is called before the first frame update
    void Start()
    {
        habilitarCamera(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)){
            habilitarCamera(0);
        } else if(Input.GetKeyDown(KeyCode.A)){
            habilitarCamera(1);
        }
    }

    void habilitarCamera(int indice){
        if(cameras.Length > indice){
            cameras[indice].targetDisplay = 0;

            int aux = 1;
            for(int i=0; i<cameras.Length; i++){
                if(i == indice) continue;
                cameras[i].targetDisplay = aux++;
            }
        }
    }
}
