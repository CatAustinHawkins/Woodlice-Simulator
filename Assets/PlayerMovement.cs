using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f; //Controls velocity multiplier

    Rigidbody2D rb; //Tells script there is a rigidbody, we can use variable rb to reference it in further script

    public AudioSource audio1;

    public Slider HungerMeter;
    public Slider HydrationMeter;

    public float timer1;
    public float timer2;

    //timer 1 = food bar decrease
    //timer 2 = hydration bar decrease/increase

    public bool InHumidity1;
    public bool InHumidity2;
    public bool InHumidity0;

    public int random;

    public float HungerSliderValue = 1;
    public float HydrationSliderValue = 1;

    public float timer3;
    public TextMeshProUGUI text;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //rb equals the rigidbody on the player
        audio1 = GetComponent<AudioSource>();


    }


    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal"); // d key changes value to 1, a key changes value to -1
        float zMove = Input.GetAxisRaw("Vertical"); // w key changes value to 1, s key changes value to -1

        rb.velocity = new Vector3(xMove, zMove, 0) * speed; // Creates velocity in direction of value equal to keypress (WASD). rb.velocity.y deals with falling + jumping by setting velocity to y. 

        timer1 = timer1 + 1 * Time.deltaTime;
        timer2 = timer2 + 1 * Time.deltaTime;

        if(timer2 > 1f && InHumidity0)
        {
            HydrationSliderValue = HydrationSliderValue - 0.1f;
            timer2 = 0;
        }

        if (timer2 > 1f && InHumidity1 && HydrationSliderValue < 1.1f)
        {
            HydrationSliderValue = HydrationSliderValue + 0.05f;
            timer2 = 0;
        }

        if (timer2 > 1f && InHumidity2 && HydrationSliderValue < 1.1f)
        {
            HydrationSliderValue = HydrationSliderValue + 0.1f;
            timer2 = 0;
        }

        if(timer1 > 1f)
        {
            HungerSliderValue = HungerSliderValue - 0.05f;
            timer1 = 0;
        }
        HungerMeter.value = HungerSliderValue;
        HydrationMeter.value = HydrationSliderValue;

        if (HungerSliderValue == 0 || HungerSliderValue < 0 || HydrationSliderValue == 0 || HydrationSliderValue < 0)
        {
            SceneManager.LoadScene("Tutorial");
        }

        timer3 = timer3 + 1 * Time.deltaTime;
        text.text = timer3.ToString();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        if(other.tag == "Cucumber" || other.tag == "Mushroom" && HungerSliderValue < 1.35f)
        {
            HungerSliderValue = HungerSliderValue + 0.35f;
            if (!audio1.isPlaying)
            {
                audio1.Play();//Play Footstep noise
            }
        }
        if (other.tag == "HumidityLevel1")
        {
            InHumidity1 = true;
            InHumidity1 = false;
            InHumidity0 = false;
        }
        if (other.tag == "HumidityLevel0")
        {
            InHumidity0 = true;
            InHumidity1 = false;
            InHumidity2 = false;
        }
        if (other.tag == "HumidityLevel2")
        {
            InHumidity2 = true;
            InHumidity0 = false;
            InHumidity1 = false;
        }
    }

}
