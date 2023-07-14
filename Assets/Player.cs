using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float jumpPower;

    public GameObject[] playerHP = new GameObject[3];

    Rigidbody2D rigid2D;

    int dieCnt = 0;
    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;

        transform.Translate(new Vector2(h, 0));

        if(dieCnt >= 3)
        {
            Debug.Log("GameOver");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            rigid2D.AddForce(new Vector3(0, jumpPower, 0), ForceMode2D.Impulse);
        }
        if (collision.gameObject.CompareTag("NotGround"))
        {
            playerHP[dieCnt].SetActive(false);
            dieCnt += 1;
            transform.position = new Vector3(-20, 0, 0);
        }
    }
}
