using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;
    public Text loseText;
    public Text livesText;

    private Rigidbody rb;
    private int count;
    private int lives;
    private AudioSource Audio;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        lives = 3;
        SetCountText();
        SetLivesText();
        winText.text = "";
        loseText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            SetLivesText();
        }
        else
        {
            other.gameObject.CompareTag("Enemy");
            other.gameObject.SetActive(false);
            lives = lives - 1;
            SetCountText();
            SetLivesText();
        }
        if (count == 12)
        {
            transform.position = new Vector3(130.0f, transform.position.y, 98.0f);

        }

    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 24)
        {
            winText.text = "You Win!";
        }
    }
    void SetLivesText()
    {
      livesText.text = "Lives: " + lives.ToString();
        if (lives == 0)
        {
            loseText.text = "Game over!";
        }
    }
}
