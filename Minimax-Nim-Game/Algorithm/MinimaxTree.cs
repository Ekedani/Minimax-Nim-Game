using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Windows.Forms.VisualStyles;

namespace Minimax_Nim_Game.Algorithm
{
    public class MinimaxNode
    {
        public readonly NimGameState State;
        public int Evaluation;
        public List<MinimaxNode> ChildrenNodes;

        public MinimaxNode(NimGameState state)
        {
            State = state;
            ChildrenNodes = new List<MinimaxNode>();
        }
    }

    public class MinimaxNimTree
    {
        private readonly MinimaxNode _rootNode;
        private readonly int _depthLimit;

        public MinimaxNimTree(NimGameState rootState, int depthLimit = 3)
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
            if (node.State.IsTerminal() || depth == _depthLimit * 2)
            {
                node.Evaluation = EvaluateState(node.State);
                if (depth % 2 != 0)
                {
                    node.Evaluation *= -1;
                }
            }
            else
            {
                var isMax = depth % 2 == 0;
                var childrenStates = node.State.GenerateChildrenStates();
                node.Evaluation = isMax ? int.MinValue : int.MaxValue;
                foreach (var nimGameState in childrenStates)
                {
                    var newChildrenNode = new MinimaxNode(nimGameState);
                    ProcessNode(newChildrenNode, depth + 1);
                    if (isMax)
                    {
                        if (node.Evaluation < newChildrenNode.Evaluation)
                        {
                            node.Evaluation = newChildrenNode.Evaluation;
                        }
                    }
                    else
                    {
                        if (node.Evaluation > newChildrenNode.Evaluation)
                        {
                            node.Evaluation = newChildrenNode.Evaluation;
                        }
                    }
                    node.ChildrenNodes.Add(newChildrenNode);
                }
            }
        }

        public NimGameState AiMakeMove()
        {
            NimGameState maxState = null;
            var maxEval = int.MinValue;
            foreach (var childrenNode in _rootNode.ChildrenNodes)
            {
                if (maxEval < childrenNode.Evaluation)
                {
                    maxState = childrenNode.State;
                    maxEval = childrenNode.Evaluation;
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