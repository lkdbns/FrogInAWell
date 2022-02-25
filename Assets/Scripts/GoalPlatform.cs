using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPlatform : MonoBehaviour
{
    private GameObject player;
    EndController controller;

    private void OnTriggerEnter(Collider other)
    {
        if (other == player.GetComponent<Collider>())
            controller.gameOver();
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
