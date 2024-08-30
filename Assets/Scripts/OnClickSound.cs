using UnityEngine;
using UnityEngine.EventSystems;

public class OnClickSound : MonoBehaviour, IPointerClickHandler
{
    public AudioClip sound;
    AudioManager am;
    private void Start()
    {
        am = FindObjectOfType<AudioManager>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        am.PlaySound(sound);
    }
}
