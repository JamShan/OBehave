﻿using System;
using System.Collections.Generic;

namespace OBehave
{
    class Selector<TContext>
        : Node<TContext>
    {
        IList<Node<TContext>> nodes;

        public Selector(IList<Node<TContext>> nodes)
        {
            if (nodes == null)
                throw new ArgumentNullException(BehaviorTreeResource.NodesCannotBeNull);

            if (nodes.Count == 0)
                throw new ArgumentException(BehaviorTreeResource.NodesCannotBeEmpty);
            
            this.nodes = nodes;
        }

        public bool Update(TContext context)
        {
            foreach (var node in nodes)
            {
                if (node.Update(context))
                    return true;
            }

            return false;
        }        
    }
}