using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class python_controller : MonoBehaviour
{
    
    [Header("Pythons Body")]
    public GameObject Body;
    public List<GameObject> BodyPart = new List<GameObject>();

    public List<GameObject> foods = new List<GameObject>();

    public Transform corner_left;
    public Transform corner_right;
    public Transform corner_forward;
    public Transform corner_back;

    [Header("Pythons Move")]
    public float speed = 5;
    public float bodySpeed = 5;
    public float steerSpeed = 100;
    public int Gap = 10;
    private List<Vector3> PositionsHistory = new List<Vector3>();



    public bool isAlive = true;


    public Vector3 direction = Vector3.forward;
    // Start is called before the first frame update
    void Start()
    {
        GrowSnake();
    }

    // Update is called once per frame
    void Update()
    {
        if(isAlive){
            // Move Forward
            transform.position += transform.forward * speed * Time.deltaTime;

            // steer
            float steerDirection = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up * steerDirection * 100 * Time.deltaTime);

            // store position history
            PositionsHistory.Insert(0, transform.position);

            // move body Parts
            moveBodyParts();
            isAlive = ! gonnaDie(transform.position);
        }
        sortFood();

    }

    private void GrowSnake(){
        GameObject body = Instantiate(Body);
        body.SetActive(false);  
        BodyPart.Add(body);
    }

    private void moveBodyParts(){
        int index = 0;
        foreach (var body in BodyPart)
        {
            Vector3 point = PositionsHistory[Mathf.Min(index * Gap, PositionsHistory.Count - 1)];
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * bodySpeed * Time.deltaTime;
            body.transform.LookAt(point);
            body.SetActive(true);
            index++;
        }
    }

    // Defindo quando o objeto se colidir com alguém
    private void OnTriggerEnter(Collider other) {
        if(other.tag.Equals("food")){
            GrowSnake();
            Destroy(other.gameObject);
        }
    }

    private async void sortFood(){
        int foodIndex = (int)Random.Range(0, foods.Count -1);
        float x = Random.Range(corner_back.position.x,corner_forward.position.x);
        float z = Random.Range(corner_left.position.z,corner_right.position.z);
        //System.Threading.Thread.Sleep(1000);
        Instantiate(foods[foodIndex], new Vector3(x,150,z), Quaternion.identity);
    }

    // Preve se o objeto vai colidir
    private bool gonnaDie(Vector3 direction){
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, 1)){
            return hit.transform.tag.Equals("body") == true || hit.transform.tag.Equals("rock") == true;
        }
        return false;
    }
}
