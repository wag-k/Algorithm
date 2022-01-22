using System;
using System.Collections.Generic;

namespace Algorithm
{
    /// <summary>
    /// めぐる式２文探索
    /// [【めぐるのアルゴリズム講座】二分探索（整数）の書き方 難しさ：４](https://twitter.com/meguru_comp/status/697008509376835584)
    /// left は常に条件を満たさず、right は常に条件を満たす
    /// </summary>
    public static class BinarySearch<T>
    where T : IComparable
    {
        /// <summary>
        /// Delegate of criteia function
        /// Check wheter the index satisfy the condition
        /// </summary>
        /// <param name="index"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public delegate bool IsOK(IList<T> elements, int index, T key);

        /// <summary>
        /// Run binary search with default check method
        /// </summary>
        /// <param name="elements"></param>
        /// <param name="index"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int Search(IList<T> elements, T key){
            return Search(elements, key, DefaultIsOK);
        }

        /// <summary>
        /// Run binary search with designated check method
        /// </summary>
        /// <param name="elements"></param>
        /// <param name="index"></param>
        /// <param name="key"></param>
        /// <param name="isOK">Check method</param>
        /// <returns></returns>
        public static int Search(IList<T> elements, T key, IsOK isOK){
            int ng = -1;
            int ok = elements.Count;

            while(Math.Abs(ok-ng) > 1){
                int mid = (ok + ng) / 2;
                if(isOK(elements, mid, key)){
                    ok = mid;
                } else { 
                    ng = mid;
                }
                
            }
            return ok;
        }

        /// <summary>
        /// Default typical binary search condition check method
        /// </summary>
        /// <param name="index"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool DefaultIsOK(IList<T> elements, int index, T key)
        {
            return elements[index].CompareTo(key) >= 0;
        }
    }
}
