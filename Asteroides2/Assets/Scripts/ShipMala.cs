using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMala : MonoBehaviour {


    public bool damage = false;

    public Transform SpawnBulletPosition;

    public Transform Bullet;

    public GameObject ShipMesh;
    public GameObject Bulley;
    public GameObject bullet;

    public int Life = 100;
    public int Speed = 1;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Shoot", 0, 3);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Shoot();
    }

    void Shoot()
    {
        Instantiate(bullet, Bulley.transform.position, Quaternion.identity);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Metheorite")
        {
            Damaged();
        }
    }

    void Damaged()
    {
        if (damage)
        {
            Life = (Life - 5);
        }
        damage = true;
        ShipMesh.GetComponent<Renderer>().material.color = Color.white;
        Invoke("NotDamaged", 0);
    }

    void NotDamaged()
    {
        damage = false;
        ShipMesh.GetComponent<Renderer>().material.color = Color.white;
    }
    
}
