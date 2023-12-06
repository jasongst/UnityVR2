using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class BallSpawner : MonoBehaviour
{

    public InputActionReference spawnBallAction;

    [SerializeField]
    private GameObject m_Ball;

    public void Awake()
    {
        spawnBallAction.action.performed += ctx =>
        {
            SpawnBall();
        };
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnBall()
    {
        Debug.Log("SpawnBall");
        GameObject ball = Instantiate(m_Ball, new Vector3(0.0299999993f,1.26900005f,-1.02600002f), Quaternion.identity);
    }
}
