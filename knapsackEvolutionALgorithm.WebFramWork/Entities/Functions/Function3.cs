using knapsackEvolutionALgorithm.Service.Entities.Common;
using System;

namespace knapsackEvolutionALgorithm.Service.Entities.Functions
{
    public class Function3 : IFunction
    {
        #region Properties

        #endregion
        #region Ctors
        public Function3()
        {
        }

        
        #endregion
        public double Implement(int nCount)
        {
            var s = 0.0;
            for (int x = 0; x < nCount; x++)
            {
                if (x > 5.12 || x < -5.12)
                    s += (10 * Math.Pow(x, 2));
                else if (x >= -5.12 || x <= 5.12)
                    s += (Math.Pow(x, 2) - (10 * Math.Cos(2 * Math.PI * x)));
            }
            return (10 * nCount) + s;
        }
        public double ComputeFitness(int nCount)
        {
            var implemt = Implement(nCount);
            return implemt;
        }

        public void LoadFunction()
        {
            throw new System.NotImplementedException();
        }
    }
}
