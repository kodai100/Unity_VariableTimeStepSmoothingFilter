namespace kodai100.SmoothingFilter
{
    /// <summary>
    /// Naive implementation. Fixed time step version. 
    /// </summary>
    public class NaiveSmoothingFilter
    {
        private float smoothingResponse;

        public NaiveSmoothingFilter(float smoothingResponse)
        {
            this.smoothingResponse = smoothingResponse;
        }

        public float Calculate(float currentValue, float targetValue)
        {
            return currentValue * smoothingResponse + targetValue * (1 - smoothingResponse);
        }
    }
}