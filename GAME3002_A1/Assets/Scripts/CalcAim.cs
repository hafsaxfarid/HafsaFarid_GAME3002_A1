using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CalculationTools
{
    public class CalcAim
    {
        public static float GetRotationAngle(Vector3 vTarget, Vector3 vPos)
        {
            if (vTarget != Vector3.zero)
            {
                float fVal = GetLookAtValue(vTarget, vPos);
                fVal *= Mathf.Rad2Deg;

                return fVal;
            }


            return 0.0f;
        }


        public static float GetLookAtValue(Vector3 vTarget, Vector3 vPos)
        {
            Vector3 vTargetDirection = (vTarget - vPos);

            float fDotResult = Vector3.Dot(vTargetDirection, Vector3.forward);

            return Mathf.Acos((fDotResult) / (vTargetDirection.magnitude * Vector3.forward.magnitude)) * Mathf.Sin(vTargetDirection.x);

        }

        public static Quaternion RotateTowards(Vector3 vTarget, Vector3 vPos)
        {
            return Quaternion.Euler(0f, GetRotationAngle(vTarget, vPos), 0f);
        }

        public static Quaternion UpdateBallFacingPosition(Vector3 vTarget, Vector3 vPos)
        {
            return RotateTowards(vTarget, vPos);
        }
    }
}