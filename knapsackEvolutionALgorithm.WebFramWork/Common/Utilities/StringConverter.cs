using knapsackEvolutionALgorithm.Service.Entities;
using System.Collections.Generic;
using System.Linq;

namespace knapsackEvolutionALgorithm.Service.Common
{
    public static class StringConverter
    {
        public static List<Item> ConvertToItemList(this string input)
        {
            var inputArray = input.Split('\n');
            var ItemList = new List<Item>();
            for (int i = 0; i < inputArray.Count(); i++)
            {
                var item = inputArray[i].Split(',');
                ItemList.Add(
                        new Item(int.Parse(item[i]), int.Parse(item[i]))
                    );
            }
            return ItemList;
        }
    }
}
