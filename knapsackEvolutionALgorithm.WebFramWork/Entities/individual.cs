using knapsackEvolutionALgorithm.Service.Entities.Common;
using System.Collections.Generic;
using System.Linq;

namespace knapsackEvolutionALgorithm.Service.Entities
{
    public class Individual : BaseChromosome<bool, int>
    {
        #region Ctors
        public Individual(IList<Item> items)
        {
            Generate = new bool[items.Count];
            Fitness = 0;
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="generate">پاسخ تصادفی 0 و 1</param>
        /// <param name="items">اشیا</param>
        /// <param name="knapsakCapacity">ظرفیت کوله پشتی</param>
        public Individual(bool[] generate, IList<Item> items, int knapsackCapacity)
        {
            Generate = generate;
            var value = 0;
            var weight = 0;

            for (int i = 0; i < generate.Count(); i++)
            {
                value += generate[i].Equals(true) ? items[i].Value : 0;
                weight += generate[i].Equals(true) ? items[i].Weight : 0;
            }
            Fitness = weight <= knapsackCapacity ? value : 0;
        }
        #endregion
    }
}
