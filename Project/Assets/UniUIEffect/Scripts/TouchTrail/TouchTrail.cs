using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///   touch trail,based on MeleeWeaponTrail
/// </summary>
class TouchTrail : MonoBehaviour
{
    public Transform trans;
    public Camera camera;

    Vector3 mPrePosition;
    void Update()
    {
        if (enabled)
        {
            if (mPrePosition == Vector3.zero)
            {
                mPrePosition = trans.localPosition;//init the value
                return;
            }

            Vector3 curPosition = TransformUtility.GetRelativeMousePosition(camera, trans.parent);
            trans.localPosition = curPosition;

            float theDistanceSqr = (mPrePosition - curPosition).sqrMagnitude;
            if (theDistanceSqr > 0.1f)
            {
                trans.LookAt(transform.TransformPoint(curPosition - mPrePosition));
                trans.localEulerAngles = Vector3.zero;//reset the rotate angle

                Vector3 dir = curPosition - mPrePosition;
                float angle = Vector2.Angle(dir, new Vector2(1, 0));
                if (dir.y < 0)
                    angle = -angle;

                trans.Rotate(new Vector3(0, 0, angle));

                mPrePosition = curPosition;
            }
        }
    }

}
