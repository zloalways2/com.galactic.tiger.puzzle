using UnityEngine;
using UnityEngine.EventSystems;

public class Quit : MonoBehaviour,IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Application.Quit();
    }
}
