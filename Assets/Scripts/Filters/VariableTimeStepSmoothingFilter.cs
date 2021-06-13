using UnityEngine;

namespace kodai100.SmoothingFilter
{
    /// <summary>
    /// Robust implementation. Variable time step version. 
    /// </summary>
    public class VariableTimeStepSmoothingFilter
    {
        private float minusLambda;

        public VariableTimeStepSmoothingFilter(float smoothingResponse, float fixedDeltaTime = 1f / 60f)
        {
            minusLambda = Mathf.Log(smoothingResponse) / fixedDeltaTime;
        }

        public float Calculate(float currentValue, float targetValue, float currentDeltaTime)
        {
            return currentValue * Mathf.Exp(minusLambda * currentDeltaTime) +
                   targetValue * (1 - Mathf.Exp(minusLambda * currentDeltaTime));
        }
    }
}