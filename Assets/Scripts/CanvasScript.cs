using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    [SerializeField] private Font DefaultFont = null;
    private string DialogueName = "DialogueTemp";

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("CanvasScript.Start()");

        //GameObject newGO = new GameObject("myTextGO");
        //newGO.transform.SetParent(this.transform);

        //Text myText = newGO.AddComponent<Text>();
        //myText.text = "Ta-dah!";
        
        //myText.GetComponent<RectTransform>().localPosition = Vector3.zero;
        //myText.font = DefaultFont;
    }


    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    // spawn a text element in the UI
        //    GameObject newGO = new GameObject(DialogueName);
        //    newGO.transform.SetParent(transform);

        //    Text myText = newGO.AddComponent<Text>();
        //    myText.text = "Ta-dah!";

        //    myText.GetComponent<RectTransform>().localPosition = Vector3.zero;
        //    myText.font = DefaultFont;
        //}
        //else if(Input.GetKeyDown(KeyCode.E))
        //{
        //    // destroy UI element
        //    Destroy(transform.Find(DialogueName).gameObject);
        //}
    }

    public void CloseMenu()
    {
        // destroy the menu
        //Destroy(this);
    }
}
