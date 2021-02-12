This is a C# port of Cactus Kev's 5 card poker hand evaluator wrapped in a .NET REST API.  The API documentation is provided via swagger @ /swagger/index.html.

Projects:
Quicken.Poker - Core classes & contracts
Quicken.Poker.FastEvalService - Fast poker hand evaluator
Quicken.Poker.REST - ASP.Net MVC Web API project / REST API
Quicken.Poker.FastEvalService.Tests - NUnit Test scenarios for the HandEvaluator Service

Core evaluator code is in: Quicken.Poker.FastEvalService.FastHandEvaluator.cs

Portions of this program are based on work by the following:

Kevin Suffecool (2001)
Paul Senzee (2006)


Sample Requests (POST to: /PokerService/Evaluate):

Input:
//*****
[
  {
    "name": "One",
    "cards": [
      "AH","2H","3H","4H","5H"
    ]
  }
]
//*****

Output (If you're ever all alone in a hand it means you've won):

[
  {
    "hand": {
      "name": "One",
      "cards": [
        "AH",
        "2H",
        "3H",
        "4H",
        "5H"
      ]
    },
    "isWinner": true,
    "class": {
      "value": 1,
      "description": "Straight Flush"
    }
  }
]

Input:
//*****
[
  {
    "name": "One",
    "cards": [
      "AS","2H","7H","4H","5H"
    ]
  },
{
    "name": "Two",
    "cards": [
      "7H","2S","AH","4H","5H"
    ]
  }
]

//*****
Output (it's a tie, both are winners):
[
  {
    "hand": {
      "name": "One",
      "cards": [
        "AS",
        "2H",
        "7H",
        "4H",
        "5H"
      ]
    },
    "isWinner": true,
    "class": {
      "value": 9,
      "description": "High Card"
    }
  },
  {
    "hand": {
      "name": "Two",
      "cards": [
        "7H",
        "2S",
        "AH",
        "4H",
        "5H"
      ]
    },
    "isWinner": true,
    "class": {
      "value": 9,
      "description": "High Card"
    }
  }
]

Input:
//*****
[
  {
    "name": "One",
    "cards": [
      "AH","2H","3H","4H","2C"
    ]
  },
{
    "name": "Two",
    "cards": [
      "AH","3S","3H","4H","2H"
    ]
  }
]
//*****

Output (Pair over pair, 3's win):
[
  {
    "hand": {
      "name": "One",
      "cards": [
        "AH",
        "2H",
        "3H",
        "4H",
        "2C"
      ]
    },
    "isWinner": false,
    "class": {
      "value": 8,
      "description": "One Pair"
    }
  },
  {
    "hand": {
      "name": "Two",
      "cards": [
        "AH",
        "3S",
        "3H",
        "4H",
        "2H"
      ]
    },
    "isWinner": true,
    "class": {
      "value": 8,
      "description": "One Pair"
    }
  }
]