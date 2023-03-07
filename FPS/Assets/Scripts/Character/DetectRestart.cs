using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class DetectRestart : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEvent stopTimer;
    public GameObject[] targets;
    // Update is called once per frame

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Exit"))
        {
            print("in restart");
            targets = GameObject.FindGameObjectsWithTag("Enemy");
            if (targets.Length == 0)
            {
                stopTimer.Invoke();
            }
            
        }
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Y))
            {
                print("restart");
                GameManager.instance.GameOver();
            }
    }

}
