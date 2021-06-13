using UnityEngine;
using UnityEngine.UI;

namespace kodai100.SmoothingFilter
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private float initialValue = 10;
        [SerializeField] private float targetValue = 1;

        [SerializeField] private float smoothingFactor = 0.5f;

        [SerializeField] private GameObject plotSphereNaive;
        [SerializeField] private GameObject plotSphereRobust;

        [SerializeField] private Button nextButton;

        private VariableTimeStepSmoothingFilter robustFilter;
        private float currentValueOfRobustFilter;
        private float positionRobust;

        private NaiveSmoothingFilter naiveFilter;
        private float currentValueOfNaiveFilter;
        private float positionNaive;

        private void Start()
        {
            naiveFilter = new NaiveSmoothingFilter(smoothingFactor);
            currentValueOfNaiveFilter = initialValue;
            Instantiate(plotSphereNaive, new Vector3(positionNaive, currentValueOfNaiveFilter, 0), Quaternion.identity);

            robustFilter = new VariableTimeStepSmoothingFilter(smoothingFactor, 1f);
            currentValueOfRobustFilter = initialValue;
            Instantiate(plotSphereRobust, new Vector3(positionRobust, currentValueOfRobustFilter, -1),
                Quaternion.identity);

            nextButton.onClick.AddListener(Next);
        }

        private void Next()
        {
            // wait for robust result
            if (positionNaive < positionRobust)
            {
                currentValueOfNaiveFilter = naiveFilter.Calculate(currentValueOfNaiveFilter, targetValue);
                positionNaive += 1;
                Instantiate(plotSphereNaive, new Vector3(positionNaive, currentValueOfNaiveFilter, 0),
                    Quaternion.identity);
            }

            var deltaTime = Random.Range(0.2f, 0.8f);
            currentValueOfRobustFilter = robustFilter.Calculate(currentValueOfRobustFilter, targetValue, deltaTime);
            positionRobust += deltaTime;
            Instantiate(plotSphereRobust, new Vector3(positionRobust, currentValueOfRobustFilter, -1),
                Quaternion.identity);
        }
    }
}