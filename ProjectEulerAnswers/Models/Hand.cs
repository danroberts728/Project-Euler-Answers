using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectEulerAnswers.Models
{
    public class Hand
    {
        public List<Card> CardsSorted { get; set; }
        public Hand(string handString)
        {
            List<Card> cardsUnsorted = new List<Card>();
            foreach (string c in handString.Split(' '))
            {
                cardsUnsorted.Add(new Card(c));
            }
            CardsSorted = cardsUnsorted.OrderBy(c => c.Value).ToList();
        }

        public enum Suit
        {
            Heart, Diamond, Club, Spade
        }

        public bool IsRoyalFlush
        {
            get
            {
                bool valuesWork = CardsSorted[0].Value == 10 && CardsSorted[1].Value == 11 && CardsSorted[2].Value == 12 && CardsSorted[3].Value == 13 && CardsSorted[4].Value == 14;
                bool suitsWork = CardsSorted[0].Suit == CardsSorted[1].Suit &&
                    CardsSorted[1].Suit == CardsSorted[2].Suit &&
                    CardsSorted[2].Suit == CardsSorted[3].Suit &&
                    CardsSorted[3].Suit == CardsSorted[4].Suit;
                return suitsWork && valuesWork;
            }
        }

        public bool IsStraightFlush
        {
            get
            {
                bool valuesWork = CardsSorted[0].Value == CardsSorted[1].Value + 1 &&
                    CardsSorted[1].Value == CardsSorted[2].Value + 1 &&
                    CardsSorted[2].Value == CardsSorted[3].Value + 1 &&
                    CardsSorted[3].Value == CardsSorted[4].Value + 1;
                Suit matchingSuit = CardsSorted[0].Suit;
                bool suitsWork = CardsSorted.Where(c => c.Suit == matchingSuit).Count() == 5;
                return !IsRoyalFlush && suitsWork && valuesWork;
            }
        }

        public bool IsFourOfAKind
        {
            get
            {
                int firstCardValue = CardsSorted[0].Value;
                int lastCardValue = CardsSorted[4].Value;
                return !IsStraightFlush && !IsRoyalFlush && CardsSorted.Where(c => c.Value == firstCardValue).Count() == 4 ||
                    CardsSorted.Where(c => c.Value == lastCardValue).Count() == 4;
            }
        }

        public bool IsFullHouse
        {
            get
            {
                int firstCardValue = CardsSorted[0].Value;
                int lastCardValue = CardsSorted[4].Value;
                bool firstOption = CardsSorted.Where(c => c.Value == firstCardValue).Count() == 3 &&
                    CardsSorted.Where(c => c.Value == lastCardValue).Count() == 2;
                bool secondOption = CardsSorted.Where(c => c.Value == firstCardValue).Count() == 2 &&
                    CardsSorted.Where(c => c.Value == lastCardValue).Count() == 3;
                return !IsFourOfAKind && !IsStraightFlush && !IsRoyalFlush && (firstOption || secondOption);
            }
        }

        public bool IsFlush
        {
            get
            {
                Suit matchingSuit = CardsSorted[0].Suit;
                return !IsFullHouse && !IsFourOfAKind && !IsStraightFlush && !IsRoyalFlush && CardsSorted.Where(c => c.Suit == matchingSuit).Count() == 5;
            }
        }

        public bool IsStraight
        {
            get
            {
                return !IsFlush && !IsFullHouse && !IsFourOfAKind && !IsStraightFlush && !IsRoyalFlush && 
                   CardsSorted[0].Value + 1 == CardsSorted[1].Value &&
                   CardsSorted[1].Value + 1 == CardsSorted[2].Value &&
                   CardsSorted[2].Value + 1 == CardsSorted[3].Value &&
                   CardsSorted[3].Value + 1 == CardsSorted[4].Value;
            }
        }

        public bool IsThreeOfAKind
        {
            get
            {
                bool firstOption = CardsSorted.Where(c => c.Value == CardsSorted[0].Value).Count() == 3;
                bool secondOption = CardsSorted.Where(c => c.Value == CardsSorted[1].Value).Count() == 3;
                bool thirdOption = CardsSorted.Where(c => c.Value == CardsSorted[2].Value).Count() == 3;
                return !IsStraight && !IsFlush && !IsFullHouse && !IsFourOfAKind && !IsStraightFlush && !IsRoyalFlush && (firstOption || secondOption || thirdOption);
            }
        }

        public bool IsTwoPairs
        {
            get
            {
                // YY YY N
                bool firstOption = CardsSorted[0].Value == CardsSorted[1].Value && CardsSorted[2].Value == CardsSorted[3].Value;
                // YY N YY
                bool secondOption = CardsSorted[0].Value == CardsSorted[1].Value && CardsSorted[3].Value == CardsSorted[4].Value;
                // N YY YY
                bool thirdOption = CardsSorted[1].Value == CardsSorted[2].Value && CardsSorted[3].Value == CardsSorted[4].Value;
                return !IsThreeOfAKind && !IsStraight && !IsFlush && !IsFullHouse && !IsFourOfAKind && !IsStraightFlush && !IsRoyalFlush && (firstOption || secondOption || thirdOption);
            }
        }

        public bool IsOnePair
        {
            get
            {
                return !IsTwoPairs && !IsThreeOfAKind && !IsStraight && !IsFlush && !IsFullHouse && !IsFourOfAKind && !IsStraightFlush && !IsRoyalFlush && (
                    // YY NNN
                    CardsSorted[0].Value == CardsSorted[1].Value ||
                    // N YY NN
                    CardsSorted[1].Value == CardsSorted[2].Value ||
                    // NN YY N
                    CardsSorted[2].Value == CardsSorted[3].Value ||
                    // NNN YY
                    CardsSorted[3].Value == CardsSorted[4].Value
                    );
            }
        }

        public bool IsHighCard
        {
            get
            {
                return !IsOnePair && !IsTwoPairs && !IsThreeOfAKind && !IsStraight && !IsFlush && !IsFullHouse && !IsFourOfAKind && !IsStraightFlush && !IsRoyalFlush;
            }
        }

        public int HandStrength
        {
            get
            {
                if (IsRoyalFlush) { return 1000; }
                else if (IsStraightFlush) { return 900; }
                else if (IsFourOfAKind) { return 800; }
                else if (IsFullHouse) { return 700; }
                else if (IsFlush) { return 600; }
                else if (IsStraight) { return 500; }
                else if (IsThreeOfAKind) { return 400; }
                else if (IsTwoPairs) { return 300; }
                else if (IsOnePair) { return 200; }
                else if (IsHighCard) { return 100; }
                else { throw new Exception(); }
            }
        }

        public bool Beats(Hand otherHand)
        {
            int player1HandStrength = HandStrength;
            int player2HandStrength = otherHand.HandStrength;
            if (player1HandStrength > player2HandStrength)
            {
                return true;
            }
            else if (player1HandStrength < player2HandStrength)
            {
                return false;
            }
            else
            {
                if (player1HandStrength == 1000 && player2HandStrength == 1000)
                {
                    // Royal Flush
                    throw new Exception();
                }
                else if (player1HandStrength == 900)
                {
                    // Straight Flush. Highest Card wins
                    return CardsSorted[4].Value > otherHand.CardsSorted[4].Value;
                }
                else if (player1HandStrength == 800)
                {
                    // Four of a Kind. Highest 4-card wins
                    int player1HighCardValue = CardsSorted[0].Value == CardsSorted[1].Value
                        ? CardsSorted[1].Value
                        : CardsSorted[4].Value;
                    int player2HighCardValue = otherHand.CardsSorted[0].Value == otherHand.CardsSorted[1].Value
                        ? otherHand.CardsSorted[1].Value
                        : otherHand.CardsSorted[4].Value;
                    return player1HighCardValue > player2HighCardValue;
                }
                else if (player1HandStrength == 700)
                {
                    // Full House. Highest 3-card wins
                    int player1HighCardValue = CardsSorted[2].Value;
                    int player2HighCardValue = otherHand.CardsSorted[2].Value;
                    return player1HighCardValue > player2HighCardValue;
                }
                else if (player1HandStrength == 600)
                {
                    // Flush. Highest card wins
                    int player1HighestUniqueCard = 0;
                    int player2HighestUniqueCard = 0;
                    if (CardsSorted[4].Value != otherHand.CardsSorted[4].Value)
                    {
                        player1HighestUniqueCard = CardsSorted[4].Value;
                        player2HighestUniqueCard = CardsSorted[4].Value;
                    }
                    else if (CardsSorted[3].Value != otherHand.CardsSorted[3].Value)
                    {
                        player1HighestUniqueCard = CardsSorted[3].Value;
                        player2HighestUniqueCard = CardsSorted[3].Value;
                    }
                    else if (CardsSorted[3].Value != otherHand.CardsSorted[2].Value)
                    {
                        player1HighestUniqueCard = CardsSorted[2].Value;
                        player2HighestUniqueCard = CardsSorted[2].Value;
                    }
                    else if (CardsSorted[3].Value != otherHand.CardsSorted[1].Value)
                    {
                        player1HighestUniqueCard = CardsSorted[1].Value;
                        player2HighestUniqueCard = CardsSorted[1].Value;
                    }
                    else if (CardsSorted[3].Value != otherHand.CardsSorted[0].Value)
                    {
                        player1HighestUniqueCard = CardsSorted[0].Value;
                        player2HighestUniqueCard = CardsSorted[0].Value;
                    }
                    return player1HighestUniqueCard > player2HighestUniqueCard;
                }
                else if (player1HandStrength == 500)
                {
                    // Straight. Highest card wins
                    int player1HighestUniqueCard = 0;
                    int player2HighestUniqueCard = 0;
                    if (CardsSorted[4].Value != otherHand.CardsSorted[4].Value)
                    {
                        player1HighestUniqueCard = CardsSorted[4].Value;
                        player2HighestUniqueCard = CardsSorted[4].Value;
                    }
                    else if (CardsSorted[3].Value != otherHand.CardsSorted[3].Value)
                    {
                        player1HighestUniqueCard = CardsSorted[3].Value;
                        player2HighestUniqueCard = CardsSorted[3].Value;
                    }
                    else if (CardsSorted[3].Value != otherHand.CardsSorted[2].Value)
                    {
                        player1HighestUniqueCard = CardsSorted[2].Value;
                        player2HighestUniqueCard = CardsSorted[2].Value;
                    }
                    else if (CardsSorted[3].Value != otherHand.CardsSorted[1].Value)
                    {
                        player1HighestUniqueCard = CardsSorted[1].Value;
                        player2HighestUniqueCard = CardsSorted[1].Value;
                    }
                    else if (CardsSorted[3].Value != otherHand.CardsSorted[0].Value)
                    {
                        player1HighestUniqueCard = CardsSorted[0].Value;
                        player2HighestUniqueCard = CardsSorted[0].Value;
                    }
                    return player1HighestUniqueCard > player2HighestUniqueCard;
                }
                else if (player1HandStrength == 400)
                {
                    // Three of a Kind. Highest 3-card wins
                    // Always the third card when sorted
                    int player1HighCardValue = CardsSorted[2].Value;
                    int player2HighCardValue = otherHand.CardsSorted[2].Value;
                    return player1HighCardValue > player2HighCardValue;
                }
                else if (player1HandStrength == 300)
                {
                    // Two Pairs
                    // Highest unique pair wins. If each has the same two pair, then the highest other card wins
                    int player1HighPairValue = GetTwoPairHighCard(CardsSorted);
                    int player2HighPairValue = GetTwoPairHighCard(otherHand.CardsSorted);
                    int player1LowPairValue = GetTwoPairLowCard(CardsSorted);
                    int player2LowPairValue = GetTwoPairLowCard(otherHand.CardsSorted);
                    if(player1HighPairValue > player2HighPairValue)
                    {
                        return true;
                    }
                    else if (player1LowPairValue > player2LowPairValue)
                    {
                        return false;
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }
                }
                else if (player1HandStrength == 200)
                {
                    // One Pair
                    // Highest pair wins. If each has the same pair, then the highset other card wins
                    int player1HighPairValue = GetOnePairHighCard(CardsSorted);
                    int player2HighPairValue = GetOnePairHighCard(otherHand.CardsSorted);
                    if(player1HighPairValue > player2HighPairValue)
                    {
                        return true;
                    }
                    else if (player1HighPairValue < player2HighPairValue)
                    {
                        return false;
                    }
                    else
                    {
                        // Highest Card wins
                        if (CardsSorted[4] != otherHand.CardsSorted[4])
                        {
                            return CardsSorted[4].Value > otherHand.CardsSorted[4].Value;
                        }
                        else if (CardsSorted[3] != otherHand.CardsSorted[3])
                        {
                            return CardsSorted[3].Value > otherHand.CardsSorted[3].Value;
                        }
                        else if (CardsSorted[2] != otherHand.CardsSorted[2])
                        {
                            return CardsSorted[2].Value > otherHand.CardsSorted[2].Value;
                        }
                        else if (CardsSorted[1] != otherHand.CardsSorted[1])
                        {
                            return CardsSorted[1].Value > otherHand.CardsSorted[1].Value;
                        }
                        else if (CardsSorted[0] != otherHand.CardsSorted[0])
                        {
                            return CardsSorted[0].Value > otherHand.CardsSorted[0].Value;
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                }
                else if (player1HandStrength == 100)
                {
                    // Highest Card wins
                    if(CardsSorted[4] != otherHand.CardsSorted[4])
                    {
                        return CardsSorted[4].Value > otherHand.CardsSorted[4].Value;
                    }
                    else if (CardsSorted[3] != otherHand.CardsSorted[3])
                    {
                        return CardsSorted[3].Value > otherHand.CardsSorted[3].Value;
                    }
                    else if (CardsSorted[2] != otherHand.CardsSorted[2])
                    {
                        return CardsSorted[2].Value > otherHand.CardsSorted[2].Value;
                    }
                    else if (CardsSorted[1] != otherHand.CardsSorted[1])
                    {
                        return CardsSorted[1].Value > otherHand.CardsSorted[1].Value;
                    }
                    else if (CardsSorted[0] != otherHand.CardsSorted[0])
                    {
                        return CardsSorted[0].Value > otherHand.CardsSorted[0].Value;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
        }

        private int GetOnePairHighCard(List<Card> cardsSorted)
        {
            if (cardsSorted[4].Value == cardsSorted[3].Value)
            {
                return cardsSorted[4].Value;
            }
            else if (cardsSorted[3].Value == cardsSorted[2].Value)
            {
                return cardsSorted[3].Value;
            }
            else if (cardsSorted[2].Value == cardsSorted[1].Value)
            {
                return cardsSorted[2].Value;
            }
            else if (cardsSorted[1].Value == cardsSorted[0].Value)
            {
                return cardsSorted[1].Value;
            }
            else
            {
                throw new Exception();
            }
        }

        private int GetTwoPairHighCard(List<Card> cardsSorted)
        {
            if (cardsSorted[4].Value == cardsSorted[3].Value)
            {
                return cardsSorted[4].Value;
            }
            else
            {
                return cardsSorted[3].Value;
            }
        }

        private int GetTwoPairLowCard(List<Card> cardsSorted)
        {
            if (cardsSorted[0].Value == cardsSorted[1].Value)
            {
                return cardsSorted[0].Value;
            }
            else
            {
                return cardsSorted[1].Value;
            }
        }

        public class Card
        {
            public Card(string code)
            {
                string valueChar = code.Substring(0, 1);
                string suitChar = code.Substring(1, 1);
                int value = 0;
                if (!int.TryParse(valueChar, out value))
                {
                    if (valueChar == "T")
                    {
                        value = 10;
                    }
                    else if (valueChar == "J")
                    {
                        value = 11;
                    }
                    else if (valueChar == "Q")
                    {
                        value = 12;
                    }
                    else if (valueChar == "K")
                    {
                        value = 13;
                    }
                    else if (valueChar == "A")
                    {
                        value = 14;
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
                }
                Value = value;
                // Get Suit
                if (suitChar == "H")
                {
                    Suit = Suit.Heart;
                }
                if (suitChar == "D")
                {
                    Suit = Suit.Diamond;
                }
                if (suitChar == "C")
                {
                    Suit = Suit.Club;
                }
                if (suitChar == "S")
                {
                    Suit = Suit.Spade;
                }
            }
            public Suit Suit { get; set; }
            public int Value { get; set; }
        }
    }
}