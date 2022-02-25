using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boostPlatform : MonoBehaviour
{
    [SerializeField] private float boost = 500.0f;
    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            print("TEST\n");
            player.GetComponent<Rigidbody>().AddRelativeForce(player.transform.forward * boost);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject == player)
        {
            print("TEST\n");
            player.GetComponent<Rigidbody>().AddRelativeForce(player.transform.forward * boost);
        }
    }




}
