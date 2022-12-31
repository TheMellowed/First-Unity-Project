using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private Rigidbody myRB;
    public float moveSpeed;

    PlayerMovement playerController;
    public GameObject player;

    void Awake()
    {
        playerController = player.GetComponent<PlayerMovement>();
    }

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        myRB.velocity = (transform.forward * moveSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(playerController.transform.position);
    }
}
