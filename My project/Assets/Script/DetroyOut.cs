using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetroyOut : MonoBehaviour
{
    void OnTriggerExit(Collider other){
        Destroy(other.gameObject);
    }
}
