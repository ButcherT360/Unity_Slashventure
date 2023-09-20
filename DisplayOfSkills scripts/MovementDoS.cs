using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MovementDoS : MonoBehaviour
{
    public Button W;
    public Button A;
    public Button S;
    public Button D;
    // yleinen nopeus joka näkyy unityssä mitä voi vaihtaa ajossa tai muuten.
    public int speed = 20;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        // Liikkuminen Eteen += forward, taakse -= forward, oikealle += right, vasemmalle -= right
        // Esc = Quit
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime * speed;
            W.image.color = W.colors.pressedColor;
        }
        else
        {
            W.image.color = W.colors.normalColor;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * Time.deltaTime * speed;
            S.image.color = S.colors.pressedColor;
        }
        else
        {
            S.image.color = S.colors.normalColor;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * Time.deltaTime * speed;
            D.image.color = D.colors.pressedColor;
        }
        else
        {
            D.image.color = D.colors.normalColor;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * Time.deltaTime * speed;
            A.image.color = A.colors.pressedColor;
        }
        else
        {
            A.image.color = A.colors.normalColor;
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
