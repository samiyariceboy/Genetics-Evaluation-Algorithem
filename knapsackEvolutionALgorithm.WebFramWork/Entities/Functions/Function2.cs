using knapsackEvolutionALgorithm.Service.Entities.Common;
using System;

namespace knapsackEvolutionALgorithm.Service.Entities.Functions
{
    public class Function2 : IFunction
    {
        #region Properties and Fields
        private readonly int _a;
        private readonly int _b;
        private readonly int _c;
        #endregion

        #region Ctors
        public Function2(int a, int b, int c)
        {
            _a = a;
            _b = b;
            _c = c;
        }

        #endregion
        public double Implement(int nCount)   
        {
            return _a * Math.Exp(_b * SQRT1()) - Math.Exp(PART2());
            #region nested Method
            double SQRT1()
            {
                var s = 0.0;
                for (int x = 0; x < nCount; x++)
                   s += Math.Pow(x, 2);
                return Math.Sqrt((1 / nCount) * s);
            }
            double PART2()
            {
                var s = 0.0;
                for (int x = 0; x < nCount; x++)
                    s += Math.Cos(_c * x); 
                return ((1/ nCount) * s);
            }
            #endregion
        }

        public double ComputeFitness(int nCount)
        {
            var implemt = Implement(nCount);
            return implemt;
        }

        public void LoadFunction()
        {

        }

    }
}
