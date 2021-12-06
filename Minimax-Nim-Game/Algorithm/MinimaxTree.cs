using System.Collections.Generic;

namespace Minimax_Nim_Game.Algorithm
{
    public class MinimaxNode
    {
        public readonly NimGameState State;
        public int AlphaEval;
        public int BetaEval;
        public List<MinimaxNode> ChildrenNodes;

        public MinimaxNode(NimGameState state)
        {
            State = state;
            ChildrenNodes = new List<MinimaxNode>();
            AlphaEval = int.MinValue;
            BetaEval = int.MaxValue;
        }
    }

    public class MinimaxNimTree
    {
        private readonly MinimaxNode _rootNode;
        private readonly int _depthLimit;

        public MinimaxNimTree(NimGameState rootState, int depthLimit = 4)
        {
            _rootNode = new MinimaxNode(rootState);
            _depthLimit = depthLimit;
            GenerateTree();
        }

        private void GenerateTree()
        {
            ProcessNode(_rootNode, 0);
        }

        private void ProcessNode(MinimaxNode node, int depth)
        {
            var isMax = depth % 2 == 0;
            if (node.State.IsTerminal() || depth == _depthLimit * 2)
            {
                if (!isMax)
                {
                    node.BetaEval = EvaluateState(node.State);
                    node.BetaEval *= -1;
                }
                else
                {
                    node.AlphaEval = EvaluateState(node.State);
                }
            }
            else
            {
                var childrenStates = node.State.GenerateChildrenStates();
                foreach (var nimGameState in childrenStates)
                {
                    var newChildrenNode = new MinimaxNode(nimGameState);
                    newChildrenNode.AlphaEval = node.AlphaEval;
                    newChildrenNode.BetaEval = node.BetaEval;
                    ProcessNode(newChildrenNode, depth + 1);
                    if (isMax)
                    {
                        if (node.AlphaEval < newChildrenNode.BetaEval)
                        {
                            node.AlphaEval = newChildrenNode.BetaEval;
                        }
                    }
                    else
                    {
                        if (node.BetaEval > newChildrenNode.AlphaEval)
                        {
                            node.BetaEval = newChildrenNode.AlphaEval;
                        }
                    }
                    node.ChildrenNodes.Add(newChildrenNode);
                    if (node.AlphaEval >= node.BetaEval)
                    {
                        break;
                    }
                }
            }
        }
        
        public NimGameState AiMakeMove()
        {
            NimGameState maxState = null;
            var maxEval = int.MinValue;
            foreach (var childrenNode in _rootNode.ChildrenNodes)
            {
                if (maxEval < childrenNode.BetaEval)
                {
                    maxState = childrenNode.State;
                    maxEval = childrenNode.BetaEval;
                }
            }

            return maxState;
        }

        private static int EvaluateState(NimGameState state)
        {
            var result = 0;
            var resultSum = 0;
            foreach (var stateHeapSize in state.HeapSizes)
            {
                result ^= stateHeapSize;
                resultSum += stateHeapSize;
            }
            
            //Misere Nim
            if (resultSum == 1)
            {
                result = 0;
            }
            
            return result != 0 ? 1 : -1;
        }
    }
}