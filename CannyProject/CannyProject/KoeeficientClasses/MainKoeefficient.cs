namespace CannyProject.KoeeficientClasses
{
    public class MainKoeefficient
    {
        //private readonly int _kernelSize = 5;
        //private readonly float _sigma = 1;   // for N=2 Sigma =0.85  N=5 Sigma =1, N=9 Sigma = 2    2*Sigma = (int)N/2
        public float maxHysteresisThresh { get; set; }
        public float minHysteresisThresh { get; set; }
        public int kernelSize { get; set; }
        public float sigma { get; set; }
    }
}
