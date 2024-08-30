using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public enum MusicViewType
{
    Music,
    Sounds
}

public class MusicView : MonoBehaviour, IPointerClickHandler
{
    public Transform begin, end;
    public Sprite sprite_off, sprite_on;
    AudioManager am;
    public Image thumb;
    public MusicViewType type;
    bool state;

    bool interpolated = false;
    float interp_time;
    private void Start()
    {
        am = FindObjectOfType<AudioManager>();
    }
    private void Update()
    {
        if (!interpolated)
            return;
        interp_time += Time.deltaTime * 20;
        if (interp_time > 1.0f)
        {
            interp_time = 1.0f;
            interpolated = false;
        }
        thumb.transform.position = Vector3.Lerp(begin.position, end.position, interp_time);
    }
    void Recalc()
    {
        if (state)
        {
            thumb.sprite = sprite_on;
        }
        else
        {
            thumb.sprite = sprite_off;
        }
        if (type == MusicViewType.Music)
        {
            am.UpdateMusicVolume(state);
        }
        if (type == MusicViewType.Sounds)
        {
            am.UpdateSoundsVolume(state);
        }
    }
    public void Init(AudioManager amanager,bool v)
    {
        am = amanager;
        state = v;
        if (state)
        {
            thumb.transform.position = end.position;
        }
        else
        {
            thumb.transform.position = begin.position;
        }
        if (!state)
        {
            (begin, end) = (end, begin);
        }
        Recalc();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        interp_time = 0.0f;
        interpolated = true;
        state = !state;
        (begin, end) = (end, begin);
        Recalc();
    }
}
