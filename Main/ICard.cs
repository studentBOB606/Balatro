using System;
using System.Collections.Generic;
using System.Text;
using Cards;

namespace KlasUitwerking
{
    public interface ICard
    {
        void PrintMe();
        string MakeAsString();
        bool SatisfiesSuit(Suit suit);
    }
}