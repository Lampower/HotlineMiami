using Assets.Scripts.Entity;
using Assets.Scripts.Events;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Events.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;


public class Player : AbstractEntity, IFireable, IInteractable, IMoveable, IDamagable, IRotatable
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Transform _weaponPivot;
    [SerializeField] private GameObject _bullet;

    [SerializeField] private int runSpeed;

    [SerializeField] private int ammo;
    [SerializeField] private int currentAmmo;
    [SerializeField] private int maxAmmo;

    private void Update()
    {
        Move();

        Rotate();

        if (InputHandler.Instance.isClicked)
        {
            Fire();
        }
    }
    public void ApplyDamage(IFireable sender, int damage)
    {
        EntityGetDamageEvent evt = new EntityGetDamageEvent(
            damage,
            this,
            sender,
            transform.position
            );

        EntityGetDamageEvent.OnEntityDamage?.Invoke(evt);

        print($"{sender} Damaged {this}");
    }

    public void Fire()
    {
        Vector2 _direction = (InputHandler.Instance.mousePosOnScene - (Vector2)transform.position).normalized;
        GameObject bullet = Instantiate(_bullet);
        bullet.GetComponent<Bullet>().Init(_weaponPivot, _direction, 25, this);
    }
    public override void Interact(IInteractable interactingObject)
    {
       Debug.Log($"Interacted by {interactingObject.ToString()}");
    }

    public void Move()
    {
        Vector2 moveVector = InputHandler.Instance.movementVector;
        _rigidbody.velocity = new Vector2(moveVector.x * runSpeed, moveVector.y * runSpeed); ;
    }

    public void Rotate()
    {
        Vector2 _direction = (InputHandler.Instance.mousePosOnScene - (Vector2)transform.position).normalized;

        transform.up = _direction;
    }

}
