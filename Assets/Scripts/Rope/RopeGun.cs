using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RopeState
{
    Disabled,
    Fly,
    Active
}

public class RopeGun : MonoBehaviour
{
    public Hook Hook;
    public Transform Spawn;
    public float Speed;
    public Transform RopeStart;
    public RopeRenderer RopeRenderer;
    public PlayerMove PlayerMove;

    private SpringJoint SpringJoint;
    private float _length;

    private RopeState CurrentRopeState;

    private void Update()
    {
        if (Input.GetMouseButtonDown(2)) // средн€€ кнопка мыши
        {
            Shot();
        }
        if (CurrentRopeState == RopeState.Fly)
        {
            float distance = Vector3.Distance(RopeStart.position, Hook.transform.position);
            if (distance > 15f)
            {
                Hook.gameObject.SetActive(false);
                CurrentRopeState = RopeState.Disabled;
                RopeRenderer.Hide();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(CurrentRopeState == RopeState.Active && PlayerMove.Grounded == false)
            {
                PlayerMove.Jump();
            }
            DestroySpring();
        }
        if(CurrentRopeState == RopeState.Fly || CurrentRopeState == RopeState.Active)
        {
            RopeRenderer.Draw(RopeStart.position, Hook.transform.position, _length);
        }
    }

    private void Shot()
    {
        _length = 1f;

        if (SpringJoint)
        {
            Destroy(SpringJoint);
        }
        Hook.gameObject.SetActive(true);
        Hook.DeleteFixedJoint();
        Hook.transform.SetPositionAndRotation(Spawn.position, Spawn.rotation);
        Hook.Rigidbody.velocity = Spawn.forward * Speed;
        CurrentRopeState = RopeState.Fly;
    }

    public void CreateSpring()
    {
        if (SpringJoint == null)  // проверка, чтобы несколько раз не приминили компонент
        {
            SpringJoint = gameObject.AddComponent<SpringJoint>(); // как создадим джоинт, надо сохранить еЄ в переменную
            SpringJoint.connectedBody = Hook.Rigidbody;
            SpringJoint.anchor = RopeStart.localPosition;
            SpringJoint.autoConfigureConnectedAnchor = false;
            SpringJoint.connectedAnchor = Vector3.zero;
            SpringJoint.spring = 100f;
            SpringJoint.damper = 5f;

            _length = Vector3.Distance(RopeStart.position, Hook.transform.position);
            SpringJoint.maxDistance = _length;

            CurrentRopeState = RopeState.Active;
        }
    }

    public void DestroySpring() // сделал публичным, чтобы отключать на барьерах HookDeactivate
    {
        if (SpringJoint)
        {
            Destroy(SpringJoint);
            CurrentRopeState = RopeState.Disabled;
            Hook.gameObject.SetActive(false);
            RopeRenderer.Hide();
        }
    }
}
