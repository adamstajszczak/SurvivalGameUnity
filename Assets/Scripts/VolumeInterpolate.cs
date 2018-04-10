using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeInterpolate : MonoBehaviour {
    public Transform player = null;
    public float maxDistance = 0f;
    public float minDistance = 0f;

    private AudioSource _aSource = null;
    private Transform _myTr = null;

    void Start()
    {
        _myTr = transform;
        _aSource = (AudioSource)GetComponent<AudioSource>();
        _aSource.volume = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(_myTr.position, player.position);
        if (distance < minDistance)
        {
            _aSource.volume = 0.9f;
        }
        else if (distance <= maxDistance)
        {
            _aSource.volume = Mathf.Abs(((distance - 30) / maxDistance) - 0.8f);
        }
        else if (distance >= maxDistance)
        {
            _aSource.volume = 0f;
        }
        else if (RespawnMenu.playerIsDead == true)
        {
            _aSource.volume = 0f;
        }
    }
}
