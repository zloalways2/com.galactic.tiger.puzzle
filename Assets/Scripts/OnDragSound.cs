using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnDragSound : MonoBehaviour,IBeginDragHandler,IEndDragHandler
{
    public AudioClip begin,end;
    AudioManager am;
    private void Start()
    {
        am = FindObjectOfType<AudioManager>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        am.PlaySound(begin);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        am.PlaySound(end);
    }
}
