using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class soundmanager : MonoBehaviour
{
  public AudioMixerSnapshot Music;
  public AudioMixerSnapshot Rumble;
  public AudioMixerSnapshot BossNotes;    

private void OnTriggerEnter(Collider other)
 {
     if (other.CompareTag("MusicBoss"))
    {
        BossNotes.TransitionTo(3.0f);
    }

    if (other.CompareTag("Rumble"))
    {
        Rumble.TransitionTo(3.0f);
    }

    if (other.CompareTag("BackgroundMusic"))
    {
        Music.TransitionTo(3.0f);
    }

}


}
