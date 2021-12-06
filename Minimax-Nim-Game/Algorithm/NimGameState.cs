using System;
using System.Collections.Generic;
using System.Linq;

namespace Minimax_Nim_Game.Algorithm
{
    public class NimGameState
    {
        public readonly int[] HeapSizes;

        public NimGameState(int[] heapSizes)
        {
            HeapSizes = heapSizes;
        }

        public NimGameState()
        {
            HeapSizes = new[] {1, 3, 5, 7};
        }

        public bool IsTerminal()
        {
            var result = 0;
            foreach (var heapSize in HeapSizes) result += heapSize;

            return result == 1;
        }

        public List<NimGameState> GenerateChildrenStates()
        {
            var childrenStates = new List<NimGameState>();
            for (var i = 0; i < HeapSizes.Length; i++)
            for (var j = 0; j < HeapSizes[i]; j++)
            {
                var newHeapSizes = new int[HeapSizes.Length];
                Array.Copy(HeapSizes, newHeapSizes, HeapSizes.Length);
                newHeapSizes[i] = j;
                if (newHeapSizes.Sum() == 0) continue;

                childrenStates.Add(new NimGameState(newHeapSizes));
            }

            return childrenStates;
        }

        public override string ToString()
        {
            var result = "[ ";
            foreach (var heapSize in HeapSizes) result += Convert.ToString(heapSize) + " ";

            return result += "]";
        }
    }
}