using System.Collections.Generic;

namespace WorkflowProcessingModel.Factory.Utils
{
    class CollectionUtils
    {
        public static void AddUniqeElementToList<T>(List<T> currentDestList, List<T> currentSourceList)
        {
            T ElementToAdd = RandomGenerator.RandomElement<T>(currentSourceList);
            if (!currentDestList.Contains(ElementToAdd))
            {
                currentDestList.Add(ElementToAdd);
            }
            else
            {
                AddUniqeElementToList(currentDestList, currentSourceList);
            }
        }

        public static void AddUniqeElementToDictionary<T>(Dictionary<T, int> currentDictionary, List<T> currentList, int valueToAdd)
        {
            T ElementToAdd = RandomGenerator.RandomElement<T>(currentList);
            if (!currentDictionary.ContainsKey(ElementToAdd))
            {
                currentDictionary.Add(ElementToAdd, valueToAdd);
            }
            else
            {
                AddUniqeElementToDictionary(currentDictionary, currentList, valueToAdd);
            }
        }
    }
}
