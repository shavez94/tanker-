using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class player : MonoBehaviour,IDragHandler,IPointerUpHandler,IPointerDownHandler
{
    public RectTransform pad;

    public Transform target;
    Vector3 move;
    public float movespeed;

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        transform.localPosition = Vector2.ClampMagnitude(eventData.position - (Vector2)pad.position, pad.rect.width * 0.5f);
        move = new Vector3(transform.localPosition.x, 0, transform.localPosition.y).normalized;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
        move = Vector3.zero;
        StartCoroutine("PlayerMove");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine("PlayerMove");
    }

    IEnumerator PlayerMove()
    {
        while(true)
        {
            target.Translate(move * movespeed * Time.deltaTime, Space.World);

            if (move != Vector3.zero)
                target.rotation = Quaternion.Slerp(target.rotation, Quaternion.LookRotation(move), 5 * Time.deltaTime);

            yield return null;
        }
    }




}
