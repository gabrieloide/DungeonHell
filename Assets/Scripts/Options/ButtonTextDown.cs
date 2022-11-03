using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonTextDown : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject text;

    private void Start()
    {
        text = transform.GetChild(0).gameObject;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        text.transform.position -= new Vector3(0,30,0);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        text.transform.position += new Vector3(0,30,0);
        AudioManager.instance.PlaySoundButton();
    }
}
