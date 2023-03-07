using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Impact Config", menuName = "Guns/audio Config", order = 6)]
public class ImpactScriptableObject : ScriptableObject
{
    // Start is called before the first frame update
   [Range(0,1f)]
   public float Volume = 0.5f;
   
   public AudioClip FriendlyClip;
   public AudioClip EnemyClip;
   public AudioClip WallClip;

   public void PlayFriendlyCLip(AudioSource AudioSource)
   {
       if(FriendlyClip != null){
        AudioSource.PlayOneShot(FriendlyClip, Volume);
       }
   }

   public void PlayEnemyClipClip(AudioSource AudioSource)
   {
        if(EnemyClip != null)
        {
            AudioSource.PlayOneShot(EnemyClip, Volume);
        }
   }

   public void PlayWallClipClip(AudioSource AudioSource)
   {
        if(WallClip != null)
        {
            AudioSource.PlayOneShot(WallClip, Volume);
        }
   }

    
}
