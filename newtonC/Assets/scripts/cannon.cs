using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using System.ComponentModel;
using UnityEngine.UI;

public class cannon : MonoBehaviour
{
    public GameObject projetil;
    public Transform direction; 
    public GameObject button;

    public GameObject selectorSpeed; 
    private float speed;

    private float yRotation = -155.0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.eulerAngles = new Vector3(0,0,yRotation); 
    }

    // Update is called once per frame
    void Update()
    {
        speed = selectorSpeed.GetComponent<Scrollbar>().value * 500 + 20;
        if(Input.GetKeyDown(KeyCode.Space)){
            fire();
        }
        if(Input.GetKey(KeyCode.W)){
            if(yRotation <=-150.0f){
                yRotation += 0.5f;
            }
        }
        if(Input.GetKey(KeyCode.S)){
            if(yRotation >= -200.0f){
                yRotation -= 0.5f;
            }
        }
        transform.eulerAngles = new Vector3(0,0,yRotation);
    }
    
    async void fire(){
        GameObject pj = Instantiate(projetil, direction.transform.position, direction.transform.rotation);
        pj.GetComponent<Rigidbody>().velocity = pj.transform.right * speed;
        if(speed == 520){
            await Task.Delay(1500);
            Destroy(pj);
        }
    }
}
