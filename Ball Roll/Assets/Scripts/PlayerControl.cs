using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    private Rigidbody rb;
    private int count;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        countText.text = "Count: " + count.ToString()+ "/25";
        winText.text = "";
    }
 
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float movevVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, movevVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        
            }
    }
    void SetCountText() {
        countText.text = "Count: " + count.ToString()+"/25";
        if (count == 25) {
            winText.text = "You Win";
        }
    }
}
