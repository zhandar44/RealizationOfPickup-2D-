using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGamemanager : MonoBehaviour {
    public int Speed = 10;
    public GameObject head=null;
    private bool isEquip = false;
    private Transform PlayHead;

    private void Awake()
    {
        PlayHead = transform.Find("/Player/Head").GetComponent<Transform>();
    }

    // Use this for initialization
    void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
        
		if (isEquip)
        {
            head.transform.position = PlayHead.position;
        }
	}

    private void FixedUpdate()
    {
        float movHorizontal = 0 ;
        //float movVertical = 0;
        if (Input.GetKey(KeyCode.D))
        {
            movHorizontal = 1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movHorizontal = -1f;

        }
        
        

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    movVertical += 5;
        //}
        this.transform.Translate(new Vector3(movHorizontal*Speed, 0, 0)*Time.deltaTime);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Equip"&&head == null)
        {
            Debug.Log("get");
            if (Input.GetKeyDown(KeyCode.E))
            {               
                collision.gameObject.SetActive(false);
                collision.gameObject.tag = "IsEquip";
                Debug.Log("geted");
                GetItem(collision);
            }
               
                
        }
        //switch (collision.tag)
        //{
        //    case "Equip":
        //        break;
        //}
        
    }
    private void GetItem(Collider2D collision)
    {                         
        head = collision.gameObject;
        collision.transform.parent = PlayHead;
        isEquip = true;
        collision.gameObject.SetActive(true);
                  
    }
    private void PutOffItem(Collision2D collision)
    {
        collision.gameObject.SetActive(false);
        head = null;
        isEquip = false;
    }

}
