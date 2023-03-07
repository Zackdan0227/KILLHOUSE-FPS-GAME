using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float life = 3;
    ParticleSystem particle;
    MeshRenderer bulletMesh;

    float timer = 0;
    float timerTotal = 3;
    bool isBulletTriggered = false;
    private void Start()
	{
        bulletMesh = GetComponent<MeshRenderer>();
        Invoke("DestroySelf", 2);
    }   
    void Awake()
    {
        // Destroy(gameObject, life);
    }

     void BulletTriggered()
    {
        isBulletTriggered = true;
        bulletMesh.enabled = false;
       
    }

    void DestroySelf()
	{
        // SpawnerManager.instance.RemoveBullet(this);
        Destroy(gameObject);
	}

    private void OnCollisionEnter(Collision collision) {
        //Check against targets and protect map objects
        if(collision.gameObject.tag != "Map" ){
            if(collision.gameObject.tag == "Friendly" ){
                //minus score
                GameManager.instance.Score--;    
                 Destroy(gameObject);
            }
            if(collision.gameObject.tag == "Enemy"){
                GameManager.instance.Score++;
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
            
        }else{
             Destroy(gameObject);
        }
        
       
    }
}
