using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer mixer;
    public AudioSource musicsource, soundssource;
    public void PlaySound(AudioClip sound)
    {
        soundssource.PlayOneShot(sound);
    }
    private void Load()
    {
        if (!PlayerPrefs.HasKey("music"))
        {
            PlayerPrefs.SetInt("music", 7);
        }
        if (!PlayerPrefs.HasKey("sounds"))
        {
            PlayerPrefs.SetInt("sounds", 7);
        }
        UpdateMusicVolume(PlayerPrefs.GetInt("music")==1);
        UpdateSoundsVolume(PlayerPrefs.GetInt("sounds")==1);
    }
    public void UpdateMusicVolume(bool state)
    {
        PlayerPrefs.SetInt("music", state ? 1 : 0);
        if (state)
        {
            mixer.SetFloat("music", 0);
        }
        else
            mixer.SetFloat("music", -80);
    }
    public void UpdateSoundsVolume(bool state)
    {
        PlayerPrefs.SetInt("sounds", state?1:0);
        if (state)
        {
            mixer.SetFloat("sounds", 0);
        }
        else
            mixer.SetFloat("sounds", -80);
    }
    private void Start()
    {
        Load();
        var mviews = FindObjectsOfType<MusicView>(true);
        foreach (var viewobj in mviews) {
            var view = viewobj.GetComponent<MusicView>();
            if (view.type == MusicViewType.Music)
                view.Init(this, PlayerPrefs.GetInt("music")==1);
            if (view.type == MusicViewType.Sounds)
                view.Init(this, PlayerPrefs.GetInt("sounds")==1);
        }
    }
}
