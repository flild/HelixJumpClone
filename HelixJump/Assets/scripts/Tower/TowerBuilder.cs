using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private byte _levelCount;
    [SerializeField] private GameObject _beam;
    [SerializeField] private float _additionalScale;
    [SerializeField] private StartPlatform _startPlatform;
    [SerializeField] private Platform[] _platforms; 
    [SerializeField] private FinishPlatform _finishPlatform;
    private float _startAndFinishAdditionalScale = 1.0f;

    public float BeamScaleY => _levelCount / 2f + _startAndFinishAdditionalScale + _additionalScale/2f;


    private void Awake()
    {
        Build();
    }

    private void Build()
    {
        GameObject beam = Instantiate(_beam, transform);
        beam.transform.localScale = new Vector3(2, BeamScaleY, 2);

        Vector3 spawnPosition = beam.transform.position;
        spawnPosition.y += beam.transform.localScale.y - _additionalScale;

        SpawnPlatform(_startPlatform, ref spawnPosition, transform);

        for (int i = 0; i<_levelCount; i++)
        {
            SpawnPlatform(_platforms[Random.Range(0,_platforms.Length)],ref spawnPosition,transform);
        }

        SpawnPlatform(_finishPlatform, ref spawnPosition, transform);

    }

    private void SpawnPlatform(Platform platform, ref Vector3 spawnPosition, Transform parent)
    {
        spawnPosition.y -= 1;
        Instantiate(platform, spawnPosition, Quaternion.Euler(0, Random.Range(0, 180), 0), parent);
        
    }
}
