using System;
using System.Collections.Generic;
using ThreeHandPoker.Interfaces;
using ThreeHandPoker.Models;

namespace ThreeHandPoker
{
    public class BaseHandler : baseRules, IHandler
    {
        protected IHandler _handler;
        public BaseHandler()
        {
            _handler = null;
        }

        public void SetNextHandler(IHandler handler)
        {
            _handler = handler;
        }

        public override void calc(PlayerHand player)
        {
            throw new NotImplementedException();
        }

        public override bool isHand(PlayerHand player)
        {
            throw new NotImplementedException();
        }

        public void Process(PlayerHand player)
        {
            if (isHand(player))
            {
               calc(player);
            }
            else if (_handler != null)
            {
                _handler.Process(player);
            }
        }
    }
}
