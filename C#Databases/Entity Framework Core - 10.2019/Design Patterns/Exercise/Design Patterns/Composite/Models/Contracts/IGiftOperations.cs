using System;
using System.Collections.Generic;
using System.Text;

namespace Composite.Models.Contracts
{
    public interface IGiftOperations
    {
        void Add(GiftBase gift);

        void Remove(GiftBase gift);
    }
}
