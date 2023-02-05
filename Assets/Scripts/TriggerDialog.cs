using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class TriggerDialog : MonoBehaviour
{
    public Transform player;
    public float testFloat = 20f;
    public float testFloat1 = 0.05f;
    public GameObject Canvas;
    public GameObject Cube;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Canvas = GameObject.Find( "Canvas" ); 
        Cube = Canvas;
        Player = GameObject.Find( "Player" ); 
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    protected void OnTriggerEnter(Collider other)
    {
        Debug.Log( transform.name + ": Trigger3d" );

        Debug.Log(transform.name + "here is the if statement");

        Debug.Log(transform.name + ": it worked");
    }

    protected void OnCollisionEnter(Collider col){
        if(col.CompareTag("Player"))
        {
            Instantiate (Player, new Vector3(1,1,1),transform.rotation);
            Debug.Log("OnCollisionEnter was triggered.");
        }
        
        
    }

}