using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class AniManager : MonoBehaviour
{

    [SerializeField] private PlayableAsset asset;

    private void Start()
    {
        GetComponent<PlayableDirector>().playableAsset = null;

        GetComponent<PlayableDirector>().playableAsset = asset;
        print(GetComponent<PlayableDirector>().playableAsset.name);
        GetComponent<PlayableDirector>().Play();
    }
}