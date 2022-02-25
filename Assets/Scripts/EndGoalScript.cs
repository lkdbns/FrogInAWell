using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGoalScript : MonoBehaviour
{
    public GameObject endScreen;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("We hit the end");
        if (collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            endScreen.GetComponent<EndController>().endLevel();
        }
    }
}
