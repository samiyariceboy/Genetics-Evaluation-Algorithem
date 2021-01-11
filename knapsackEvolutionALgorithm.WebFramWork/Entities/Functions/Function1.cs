using knapsackEvolutionALgorithm.Service.Entities.Common;
using System;
namespace knapsackEvolutionALgorithm.Service.Entities.Functions
{
    public class Function1 : IFunction
    {
        #region Propertes
        private readonly int _nCount;
        private readonly int _a;
        #endregion
        #region Ctors

        public Function1(int a = 10)
        {
            _a = a;
        }

        public double ComputeFitness(int nCount)
        {
            var result = Implement(nCount);
            return 1000 - result;
        }
        #endregion
        public double Implement(int nCount)
        {
            var s = 0.0;
            for (int x = 0; x < _nCount; x++)
                s += (Math.Pow(x, 2) - (_a * Math.Cos(2*(Math.PI)*x)));
            return (s + (_a * _nCount));
        }

        public IFunction Select(FunctionSelected selected)
        {
            if (selected == FunctionSelected.Function1)
            {
                return this;
            }
            return null;
        }

    }
}
