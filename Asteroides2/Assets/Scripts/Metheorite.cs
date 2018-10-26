using UnityEngine;
using System.Collections;

public class Metheorite : MonoBehaviour {

  private int Life = 5;

    public int Score;

    public Transform ExplosionParticleSystem;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

  void OnTriggerEnter(Collider other) {
    if (other.gameObject.tag == "Bullet") {
      TakeDamage(other.gameObject);
    }

        if (other.gameObject.tag == "BulletRed")
        {
            TakeDamage(other.gameObject);
        }
    }

  void TakeDamage(GameObject bullet) {
    Destroy(bullet);
    Life--;
    Score = (Score + 100);
    gameObject.GetComponent<Renderer>().material.color = Color.yellow;
    CancelInvoke("ResetColor");
    Invoke("ResetColor", 1);
    if (Life <= 0) {
      Instantiate(ExplosionParticleSystem, transform.position, Quaternion.identity);
      Destroy(gameObject);
        }
    }

    void TakeDamageRed(GameObject bulletRed)
    {
        Destroy(bulletRed);
        Life=(Life-2);
        Score = (Score + 100);
        gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        CancelInvoke("ResetColor");
        Invoke("ResetColor", 1);
        if (Life <= 0)
        {
            Instantiate(ExplosionParticleSystem, transform.position, Quaternion.identity);
            Destroy(gameObject);
            
        }
    }

    void ResetColor() {
    gameObject.GetComponent<Renderer>().material.color = Color.white;
  }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 30, 100, 50), new
         GUIContent("Puntaje: " + this.Score));
    }

    
}
