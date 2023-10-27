using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 6f;
    Rigidbody2D rb;
    public Vector3 MoveIn;
    public float dashDistance = 100f;
    public Collider2D dashCollider;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    
       
    }

    // Update is called once per frame
    void Update()
    {
        MoveIn.x = Input.GetAxis("Horizontal");
        MoveIn.y = Input.GetAxis("Vertical");
        transform.position += MoveIn * moveSpeed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Dash();
        }

        if (transform.GetComponent<Collider2D>() == dashCollider)
        {
            transform.position += transform.forward * dashDistance;
        }
        else
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }
   private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        { GameOver(col);
            Debug.Log("Nhan vat da bi tieu diet ");
        }
            }
    private void Dash()
    {
        transform.GetComponent<Collider2D>().enabled = false;
        dashCollider.enabled = true;
        dashCollider.isTrigger = true;
    }
  
    void GameOver(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        { Destroy(gameObject); }
    }
}
