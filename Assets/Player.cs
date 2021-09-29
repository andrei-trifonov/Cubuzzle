using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

public bool onAir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider col){
    if (col.tag == "Blocks")
    onAir =false;

    }

    void OnTriggerExit(Collider col){
    if (col.tag == "Blocks")
        onAir = true;

    }

    void OnTriggerStay(Collider col)
{ if (col.tag == "Blocks");
onAir = false;

 }

}
