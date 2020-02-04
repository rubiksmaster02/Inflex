﻿using System;
using UnityEngine;
using UnityEngine.UI;

public class ComplexEnemy : MonoBehaviour
{
    public int CurrentEnemy { private get; set; }
    private Enemy self;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Text text;
    private double _distance, _rotation;
    private double _handler;
    private float _movementOverTime, _rotationOverTime;
    private float _currentX, _currentY;
    private float _x, _y;
    private float _speed, _rotationSpeed;
    private float _lifetime;

    private void Start()
    {
        self = MapButton.Map.Enemies[CurrentEnemy];

        _rotationSpeed = self.Rotation;
        _speed = self.Speed;
        text.text = self.KillKey;
        _x = self.XLocation;
        _y = self.YLocation;

        transform.localPosition = new Vector2(_x, _y);

        _rotation = 180d / Math.PI * Math.Atan2(_y, _x) + 90d;
        _distance = Math.Sqrt(_x * _x + _y * _y);
        if (gameObject.name == "Enemy0" || gameObject.name == "Enemy" + (MapButton.Map.Enemies.Count - 1))
        {
            InvokeRepeating(nameof(ContainToBounds), 0, 0.00002f);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void ContainToBounds()
    {
        gameObject.SetActive(_distance - (audioSource.time - self.SpawnTime) * _speed > 0 && audioSource.time > self.SpawnTime);
    }

    private void Update()
    {
        if(gameObject.activeSelf) ContainToBounds();
        if(MapButton.Map.Enemies.Count > CurrentEnemy + 1) GameControl.ContainmentList[CurrentEnemy + 1].Invoke();
        if(CurrentEnemy - 1 > 0) GameControl.ContainmentList[CurrentEnemy - 1].Invoke();
        
        _lifetime = audioSource.time - self.SpawnTime;
        _movementOverTime = _lifetime * _speed;
        _rotationOverTime = _lifetime * _rotationSpeed;

        _handler = Math.PI * (-1 * ((_rotation + _rotationOverTime) / 180d) - 1);
        _currentX = (float) ((_distance - _movementOverTime) * Math.Sin(_handler));
        _currentY = (float) ((_distance - _movementOverTime) * Math.Cos(_handler));

        transform.localPosition = new Vector2(_currentX, _currentY);
    }
}