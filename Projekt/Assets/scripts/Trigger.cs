using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField]
    private bool point = true;
    private bool triggered = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !this.triggered)
        {
            this.triggered = true;
            if (point)
            {
                collision.GetComponent<PlayerController>().getPoint(1);
            }
            else
            {
                collision.GetComponent<PlayerController>().getPower();
            }
                
            
            Destroy(this.gameObject);
        }
    }
}
