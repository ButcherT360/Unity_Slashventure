using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform player;
    public Camera followplayerCamera;
    public Camera KameraMap;
    public RectTransform BigMap, Border;
    public int currentOrthoCamSize = 12;

    private void Awake()
    {
        Camera Kamera = GetComponent<Camera>();

    }

    private void LateUpdate()
    {
        // minimap follow player
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
        // rotate minimap with player,  Aiheuttaa liiaan kovia käännöksiä ja kartan hyöty menee alas...
        //  transform.rotation = Quaternion.Euler(90f, player.transform.eulerAngles.y, 0f);
        // mutta jos kääntääkin pelaajaa seuraavaan kameran suuntaisesti eikä pelaajan niin se ei mene hassusti.
        transform.rotation = Quaternion.Euler(90f, followplayerCamera.transform.eulerAngles.y, 0f);

    }

    void Update()
    {

        // Muutetaan ison kartan kokoa
        if (Input.GetKeyDown(KeyCode.M) && (KameraMap.orthographicSize == 12 || KameraMap.orthographicSize == 63 || KameraMap.orthographicSize == 125))// || Input.GetKey(KeyCode.Tab))
        {
            KameraMap.orthographicSize = 500;  
            BigMap.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 700);
            BigMap.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 700);
            Border.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 708);
            Border.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 708);
            BigMap.ForceUpdateRectTransforms();
            Border.ForceUpdateRectTransforms();
        }
        else if (Input.GetKeyDown(KeyCode.M) && (KameraMap.orthographicSize == 500)) // || Input.GetKey(KeyCode.Tab))
        {
            KameraMap.orthographicSize = 200;
            BigMap.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 700);
            BigMap.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 700);
            Border.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 708);
            Border.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 708);
            BigMap.ForceUpdateRectTransforms();
            Border.ForceUpdateRectTransforms();
        }
        // muutetaan pientä karttaa
        else if (Input.GetKeyDown(KeyCode.M) && (KameraMap.orthographicSize == 200 || KameraMap.orthographicSize == 12 || KameraMap.orthographicSize == 63 || KameraMap.orthographicSize == 125)) // || Input.GetKey(KeyCode.Tab))
        {
            // tallennetaan pienen kartan nykyinen tila jotta siihen voi palata kun sulkee ison kartan.
            KameraMap.orthographicSize = currentOrthoCamSize;
            BigMap.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 150);
            BigMap.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 150);
            Border.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 158);
            Border.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 158);
            BigMap.ForceUpdateRectTransforms();
            Border.ForceUpdateRectTransforms();
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && KameraMap.orthographicSize == 12)// || Input.GetKey(KeyCode.Tab))
        {
            KameraMap.orthographicSize = 125;
            currentOrthoCamSize = 125;
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && KameraMap.orthographicSize == 125)// || Input.GetKey(KeyCode.Tab))
        {
            KameraMap.orthographicSize = 63;
            currentOrthoCamSize = 63;
        }
        else if (KameraMap.orthographicSize == 63 && Input.GetKeyDown(KeyCode.Tab))// || Input.GetKey(KeyCode.Tab))
        {
            KameraMap.orthographicSize = 12;
            currentOrthoCamSize = 12;
        }
    }
}