using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

  public bool damage = false;

  public Transform SpawnBulletPosition;

  public Transform Bullet;

    public Transform BulletRed;

    public GameObject ShipMesh;

    public int Life=100;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space)) {
          Shoot();
        }

        if (Input.GetButtonDown("Fire2") || Input.GetKeyDown(KeyCode.C))
        {
            ShootRed();
        }
    }

  void Shoot() {
    Instantiate(Bullet, SpawnBulletPosition.position, Quaternion.identity);
  }

    void ShootRed()
    {
        Instantiate(BulletRed, SpawnBulletPosition.position, Quaternion.identity);
    }


    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Metheorite") {
          Damaged();
        }
    }

  void Damaged() {
    if (damage) {
      Life=(Life-5);
    }
    damage = true;
    ShipMesh.GetComponent<Renderer>().material.color = Color.red;
    Invoke("NotDamaged", 5);
  }

  void NotDamaged() {
    damage = false;
    ShipMesh.GetComponent<Renderer>().material.color = Color.white;
  }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 0, 100, 50), new
         GUIContent("Vida: " + this.Life));
    }
}
