using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class MagoController : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed;
    private bool viradoDireita = true;
    public Animator anim;
    int numChaves=0;
    public GameObject aberta;
    public GameObject fechada;
    int cena;
    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        cena = SceneManager.GetActiveScene().buildIndex;

    }

    // Update is called once per frame
    void Update()
    {
        if (numChaves == 3)
        {
            
        }
    }

    private void FixedUpdate()
    {
        float movimento = Input.GetAxis("Horizontal");
        anim.SetFloat("Velocidade", Mathf.Abs(movimento));
        rb.velocity = new Vector2(movimento * speed, rb.velocity.y);
        if ((movimento < 0 && viradoDireita) || (movimento > 0 && !viradoDireita)) Flip();

    }



    void Flip()
    {
        viradoDireita = !viradoDireita;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Chave")
        {
            numChaves = numChaves + 1;
            Destroy(collision.gameObject);
            
        }

        if(numChaves == 3)
        {
            aberta.SetActive(true);
            fechada.SetActive(false);
        }

        if(collision.gameObject.tag == "kill")
        {
            SceneManager.LoadScene(cena);
        }

        if (collision.gameObject.tag == "Porta")
        {
            if(cena == 0) SceneManager.LoadScene(cena + 1);

            if(cena == 1) SceneManager.LoadScene(0);


            
            
        }
    }
}
