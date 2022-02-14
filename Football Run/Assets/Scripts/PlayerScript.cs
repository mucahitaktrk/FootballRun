using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private Slider levelSlider = null;

    private bool fail = false;
    private Animator animator;

    private int winIndex;
    public bool winController = false;

    [SerializeField] private GameObject ball;
    public GameObject go;
    private Rigidbody ballRb;
    float time = 0;

    [SerializeField] private GameObject[] endPanel = null;
    void Start()
    {
        endPanel[0].SetActive(false);
        endPanel[1].SetActive(false);
        ball = GameObject.Find("Ball");
        ballRb = ball.GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        winIndex = Random.Range(1, 3);
    }


    void FixedUpdate()
    {
        if (!fail && !winController)
        {
            levelSlider.value = transform.position.z;
            rb.velocity = Vector3.forward * speed;
            Camera.main.transform.DOMoveZ(transform.position.z - 2.5f, 0.7f);
            if (Input.GetMouseButton(0))
            {
                rb.velocity = Vector3.forward * speed * 2.5f;
                Camera.main.transform.DOMoveZ(transform.position.z - 5.0f, 0.6f);
                transform.DORotate(new Vector3(0, 0, 0), 1.0f);
                if (transform.position.x >= -1.3f)
                {
                    transform.DORotate(new Vector3(0, 0, 15), 1.0f);
                    rb.velocity = new Vector3(-speed, 0, speed * 2.5f);
                }
            }
            else
            {
                transform.DORotate(new Vector3(0, 0, 0), 1.0f);
                if (transform.position.x <= 1.3f)
                {
                    transform.DORotate(new Vector3(0, 0, -15), 1.0f);
                    rb.velocity = new Vector3(speed, 0, speed * 2.5f);
                }
            }
            return;
        }
        else if (winController)
        {
            endPanel[1].SetActive(true);
            if (transform.position.z < 105f)
            {
                rb.AddForce(0, 0, 300);
            }

            time += Time.deltaTime;
            if (time > 1.5f)
            {
                ballRb.useGravity = true;
                ballRb.isKinematic = false;
                ball.transform.parent = go.transform;
            }
            rb.velocity = Vector3.zero;
        }
        else if (fail)
        {
            endPanel[0].SetActive(true);
            if (transform.position.x < 1.3f)
            {
                rb.AddForce(100, 0, 0);
            }
            rb.velocity = Vector3.zero;
        }
    }

    private void Win()
    {
        if (winIndex == 1)
        {
            animator.SetBool("Win1", winController);
        }
        else if(winIndex == 2)
        {
            animator.SetBool("Win2", winController);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            fail = true;
            animator.SetBool("Fail", fail);
        }
        else if (other.gameObject.layer == 9)
        {
            winController = true;
            Win();
        }
    }

    public void Button()
    {
        SceneManager.LoadScene(0);
    }
}
