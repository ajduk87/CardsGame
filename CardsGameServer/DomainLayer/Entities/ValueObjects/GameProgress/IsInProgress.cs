using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.DomainLayer.Entities.ValueObjects.GameProgress
{
    public class IsInProgress : ValueObject<IsInProgress>
    {
        public bool Content;

        public IsInProgress(bool Content)
        {
            this.Content = Content;
        }

        public static explicit operator IsInProgress(bool isInProgress)
        {
            return new IsInProgress(isInProgress);
        }

        public static implicit operator bool(IsInProgress isInProgress)
        {
            return isInProgress.Content;
        }
    }
}
