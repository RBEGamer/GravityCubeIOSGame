using UnityEngine;
using System.Collections;
using System.Collections.Generic; // required for list



public class AudioManager : MonoBehaviour 
{
    public List<SoundSummary> audioClips; // list which contains the whole audio in game

	public static string objectTag = "AudioManager";

    Dictionary<System.Guid, AudioSource> globalAudioSourceDictionary = new Dictionary<System.Guid, AudioSource>();

    // enum which contains all possible sounds which can be played
    // === IMPORTANT ===
    // if you want to insert a new sound, make sure to add the name of it in this enum!
    public enum AudioClipManaged
    {
        //
        // === SOUNDS ===
        //
        laser,
        laserAus,
        levelFrameDrehen,
		youWin,
		youLose,
		youLose2,
		youLose3,
        intro1,
		intro2,
		schuss,
		teleport,
		tür,
		ui_Click,
		ui_Reload,
		schalter,
        cube_auftreffen,
		cube_farbwechsel,
        jumpCubeDrehung,
        jumpCubeJump,
        jumpCubeHighJump,
        youWin2,
        youWin3,
      idle1,
      idle2,
      grrIdle3,
      idle4,
      idle5,
      spawn1,
      spawn2,
      spawn3,
      credits,
    }

	void Update()
	{
		// remove unused AudioSources
		DeleteTrashAudioSources();
	}

    public System.Guid Play(AudioClipManaged clipName, GameObject go = null)
    {
        // check each audio element in the list of audioClips
        foreach (SoundSummary audioSummary in this.audioClips)
        {
            // compare the name with the passed parameter's name
            if (audioSummary.name == clipName)
            {
                if (go != null)
                {
                    // anheften an go
                    return (CreateAndPlayNewAudioSource(audioSummary, go));
                }
                else 
                {
                    return (CreateAndPlayNewAudioSource(audioSummary, AudioManager.GetScriptObject()));
                    // an den spieler anhefeten
                }
            }
        }

        // loop is finished, no audio has been found
        return (System.Guid.NewGuid());
    }
	public bool StopSound(AudioClipManaged audioClipName)
	{
		// check each audio element in the list of audioClips
		//audioSourceSound.Stop ();
		// get the clip from the audioClips list
        // get the clip from the audioClips list
        AudioClip clip = GetAudioClipByName(audioClipName);

        foreach (KeyValuePair<System.Guid, AudioSource> element in globalAudioSourceDictionary)
        {
            if (element.Value != null && element.Value.clip != null)
            {
                if (clip.name == element.Value.clip.name)
                {
                    // element has been found, stop it
                    element.Value.Stop();
                    element.Value.loop = false;
                    return (true);
                }
            }
        }

		// loop is finished, no audio has been found
		return (false);
	}

    public bool StopSound(System.Guid guid)
    {
        if (this.globalAudioSourceDictionary[guid] != null)
        {
            globalAudioSourceDictionary[guid].Stop();
            return (true);
        }

        return (false);
    }

    public bool StopSound(AudioClipManaged audioClipName, GameObject go)
    {
        AudioClip clip = GetAudioClipByName(audioClipName);

        foreach (AudioSource audioSource in go.GetComponents<AudioSource>())
        {
            if (clip.name == audioSource.clip.name)
            {
                audioSource.Stop();
            }
        }

        return (false);
    }

	public AudioClip GetAudioClipByName(AudioClipManaged soundName)
	{
		foreach (SoundSummary audioSummary in this.audioClips)
		{
			if (audioSummary.name == soundName)
			{
				return (audioSummary.clip);
			}
		}

		// no clip could be found, return an empty one
		return (new AudioClip());
	}

	private System.Guid CreateAndPlayNewAudioSource(SoundSummary soundSummary, GameObject go)
	{
        if (go == null)
        {
            Debug.LogWarning("Unknown error");
        }

		// create new audio-component and add it to the player
		AudioSource audioSource = go.AddComponent<AudioSource>();
		
		// add the parameters to the source
		audioSource.clip = soundSummary.clip;
		audioSource.volume = soundSummary.volume;
		audioSource.spatialBlend = soundSummary.panLevel;
		audioSource.priority = soundSummary.priority;
		audioSource.loop = soundSummary.loop;
     
		// play the new created sound
		audioSource.Play();

        // create new guid and store guid + audiosource reference in dictionary
        System.Guid guid = System.Guid.NewGuid();
        this.globalAudioSourceDictionary.Add(guid, audioSource);

        return (guid);
	}

	public bool IsAudioSoundPlaying(System.Guid guid)
	{

        if (this.globalAudioSourceDictionary[guid] != null)
        {
            return (this.globalAudioSourceDictionary[guid].isPlaying);
        }

        return (false);
	}

    public bool IsAudioSoundPlaying(AudioClipManaged audioClipName)
    {
        // get the clip from the audioClips list
        AudioClip clip = GetAudioClipByName(audioClipName);

        foreach (KeyValuePair<System.Guid, AudioSource> element in globalAudioSourceDictionary)
        {
            if (element.Value != null && element.Value.clip != null)
            {
                if (clip.name == element.Value.clip.name)
                { 
                    // element has been found, return the state of isPlaying
                    return (element.Value.isPlaying);
                }
            }
        }

        return (false);
    }

    public bool IsAudioSoundPlaying(AudioClipManaged audioClipName, GameObject go)
    {
        AudioClip clip = GetAudioClipByName(audioClipName);

        foreach (AudioSource audioSource in go.GetComponents<AudioSource>())
        {
            if (clip.name == audioSource.clip.name)
            {
                return (audioSource.isPlaying);
            }
        }

        return (false);
    }

	public void DeleteTrashAudioSources()
	{
        foreach (KeyValuePair<System.Guid, AudioSource> element in globalAudioSourceDictionary)
        {
            if (element.Value != null && element.Value.isPlaying == false)
            {
                // element has been found, return the state of isPlaying
                DestroyObject(element.Value);
                globalAudioSourceDictionary.Remove(element.Key);
                return;
            }
        }        
	}

	public static GameObject GetScriptObject()
	{
		// returns the object where the script is assigned
		return (GameObject.FindGameObjectWithTag (AudioManager.objectTag));
	}

	public static AudioManager GetObjectTag()
	{
		GameObject go = GameObject.FindGameObjectWithTag (AudioManager.objectTag);
		AudioManager audioManager = go.GetComponent<AudioManager>();

		return (audioManager);
	}

	public static void SetGameObjectTag(string tag)
	{
		AudioManager.objectTag = tag;
	}
}