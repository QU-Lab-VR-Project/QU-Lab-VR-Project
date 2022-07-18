using UnityEngine;
using System;
using Random=UnityEngine.Random;
using UnityEngine.UI;
using TMPro;

public class ContentController : MonoBehaviour {

    public API api;
    public TextMeshProUGUI spanValue;

    System.DateTime startTime;
    System.DateTime endTime;

    float speed = 10.0f;

    public void LoadContent(string name) {
        //DestroyAllChildren();
        startTime = System.DateTime.Now;
        api.GetBundleObject(name, OnContentLoaded, transform);


    }

    void OnContentLoaded(GameObject content) {
        // change position
        int pX = Random.Range(-1061, 621);
        int pZ = Random.Range(-889,455);
        if (content.name == "StylShip_Unity(Clone)"){
            content.transform.position = new Vector3(pX, 12, pZ);
        } else if (content.name == "10_ships(Clone)") {
            content.transform.position = new Vector3(pX, -2, pZ);
        }
        else {
            content.transform.position = new Vector3(pX, 90, pZ);
        }
        
        endTime = System.DateTime.Now;
        Debug.Log("Loaded: " + content.name);
        Debug.Log("start time is : " + startTime);
        Debug.Log("end time is : " + endTime);
        
        System.TimeSpan span = endTime - startTime;
        Debug.Log("span is : " + span.Milliseconds + " ms");
        spanValue.text = "time span value: " + span.Milliseconds + " ms";

    }

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }

    void DestroyAllChildren() {
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
    }

}
