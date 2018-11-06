using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBlockFall : MonoBehaviour
{
    private int speed = 2;
    public bool Chosen = false, placed = false;
    private string inputButton;
    private Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        if(transform.position.x < 0)
        {
            inputButton = "P1Block";
        }
       else if (transform.position.x > 0)
        {
            inputButton = "P2Block";
        }


        // mControler.
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotL = new Vector3(0, 5, 0);
        Vector3 rotR = new Vector3(0, -5, 0);
        if (Input.GetMouseButtonDown(1))
        {
            Destroy(this.gameObject);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            GameObject child = this.transform.GetChild(0).gameObject;
            child.GetComponent<Collider>().isTrigger = false;
            child.GetComponent<Collider>().isTrigger = false;
            child.GetComponent<Collider>().isTrigger = false;


            //this.rb.isKinematic = true;
        }
        if (Chosen == true && placed == false && Input.GetKeyDown(KeyCode.Q))
        {
            //Use 90 degree turns get chuld 
           // GameObject child = this.transform.GetChild(0).gameObject;
           // child.transform.
            Quaternion temp = transform.rotation;
                temp.z += 0.5F; 
                transform.rotation = temp;
            Debug.Log("Rorate");
        }
        if (Chosen == true && placed == false && Input.GetKeyDown(KeyCode.E))
        {
            Quaternion temp = transform.rotation;
            temp.z += 0.5F;
            transform.rotation = temp;
            Debug.Log("Rorate");
        }
        if (Input.GetButtonDown(inputButton) && !placed){
 
     
                this.Chosen = true;
           
        }

    }
    void OnMouseDown()
    {
        this.Chosen = true;
    }
    void FixedUpdate()
    {
       
        if (Chosen == true && placed == false&& transform.position.x < 0)
        {
            rb = GetComponent<Rigidbody>();
            rb.GetComponent<Rigidbody>().isKinematic = false;
            float moveHorizontal = Input.GetAxis("Horizontal");
            Vector3 movement = new Vector3((moveHorizontal/4), 0.0f, 0.0f);
            this.transform.position += movement * speed;
            Debug.Log("use A,D");
            if (placed == false)
            {
                transform.Translate(0, -(Time.deltaTime*speed), 0);
            }
        }
        if (Chosen == true && placed == false && transform.position.x > 0)
        {
            rb = GetComponent<Rigidbody>();
            rb.GetComponent<Rigidbody>().isKinematic = false;
            float moveHorizontal = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3((moveHorizontal / 4), 0.0f, 0.0f);
            this.transform.position += movement * speed;
            Debug.Log("use left,right");
            if (placed == false)
            {
                transform.Translate(0, -(Time.deltaTime * 6), 0);
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        MissionControl mControler = GameObject.Find("GameController").GetComponent<MissionControl>();
        if (other.tag == "Ground" && placed != true || other.tag == "Block"&& placed != true)
        {
            placed = true;
            Chosen = false;
            if (mControler.turn == 1)
            {
                mControler.turn = 2;
                Debug.Log("turn2 now");
            }
            else if (mControler.turn == 2)
            {
                mControler.turn = 1;
                Debug.Log("turn1 now");
            }
            mControler.SpawnBlocks();
            return;
        }
        
    }
}
