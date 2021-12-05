using System;
using System.Collections.Generic;

namespace Minimax_Nim_Game.Algorithm
{
    public class MinimaxNode
    {
        public NimGameState State;
        public int Evaluation;

        public MinimaxNode(NimGameState state)
        {
            State = state;
        }
    }

    public class MinimaxNimTree
    {
        private MinimaxNode _rootNode;
        private int _depthLimit;

        public MinimaxNimTree(NimGameState rootState, int depthLimit = 2)
        {
            _rootNode = new MinimaxNode(rootState);
            _depthLimit = depthLimit;
        }

        private void GenerateTree()
        {
        }

        private void ProcessNode(int curDepth)
        {
        }

        private static int EvaluateState(NimGameState state)
        {
            var result = 0;
            foreach (var stateHeapSize in state.HeapSizes)
            {
                result ^= stateHeapSize;
            }

            return result == 0 ? 1 : -1;
        }
    }
}