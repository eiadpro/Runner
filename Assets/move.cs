using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class move : MonoBehaviour
{
    
    [SerializeField] float speed = 9f;
    [SerializeField] Transform Ground;
    [SerializeField] LayerMask ground;
    [SerializeField] TextMeshProUGUI s;
    [SerializeField] AudioSource j;
    [SerializeField] AudioSource p;
    [SerializeField] AudioSource e;
    [SerializeField] AudioSource w;
    [SerializeField] AudioSource d;
     Animator a;
    
    int coins = 0;
     Rigidbody rb;
    bool dead = false;
    // Start is called before the first frame update
    void Start()
    {
      rb= GetComponent<Rigidbody>();
        a = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        rb.velocity = new Vector3(x * speed, rb.velocity.y, z * speed);
        if (Input.GetKeyDown(KeyCode.Space)&&isground())
        {
            jump();
            j.Play();
        }
        print(transform.position.y);
        if (transform.position.y <= -9f&&!dead)
        {
            a.SetBool("fall", true);
            Die();
        }
        if (Input.GetKey(KeyCode.W))
        {
            a.SetBool("W", true);
        }
        else
        {
            a.SetBool("W", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            a.SetBool("S", true);
        }
        else
        {
            a.SetBool("S", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            a.SetBool("A", true);
        }
        else
        {
            a.SetBool("A", false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            a.SetBool("D", true);
        }
        else
        {
            a.SetBool("D", false);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            a.SetBool("Space", true);
            a.SetBool("SpaceW", true);
            a.SetBool("SpaceS", true);
        }
        else
        {
            a.SetBool("Space", false);
            a.SetBool("SpaceW", false);
            a.SetBool("SpaceS", false);
        }
    }

    bool isground()
    {
        return Physics.CheckSphere(Ground.position, 0.1f, ground);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemybody"))
        {
            a.SetBool("dead", true);
            Die();
        }
        if (collision.gameObject.CompareTag("head"))
        {

            Destroy(collision.transform.parent.gameObject);
            e.Play();
            jump();
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            w.Play();
            GetComponent<move>().enabled = false;
            Invoke(nameof(next), 1.5f);
            
            
        }
    }
    public void next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {

            Destroy(other.gameObject);
            coins++;
            s.text = "coins: " + coins;
            p.Play();
        }
    }
    public void Die()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<move>().enabled = false;
        Invoke(nameof(reload), 1.2f);
        dead = true;
        d.Play();

    }
    public void reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 5f, rb.velocity.z);
    }
}
