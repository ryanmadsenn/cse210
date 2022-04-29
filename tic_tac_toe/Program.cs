using System;

const string x = "X";
const string o = "O";
const string blank = " ";

string[] gameBoard = new string[] {blank, blank, blank, blank, blank, blank, blank, blank, blank};

void Main(){

    while (GameDone(gameBoard) == false) {
        // Display game board.
        DisplayBoard(gameBoard);

        // Figure out whose turn it is and assing that value to player.
        bool turn = IsXTurn(gameBoard);
        string player = "";

        if (IsXTurn(gameBoard) == true) {
            player = x;
        } else {
            player = o;
        }

        bool validInput = false;

        // Prompt player for move.
        while (validInput == false) {
            try {
                Console.Write($"{player}>");
                string stringMove = Console.ReadLine();
                int move = Convert.ToInt32(stringMove);

                if (gameBoard[move-1] != " ") {
                    Console.WriteLine("Space is already taken.");
                } else {
                    gameBoard[move-1] = player;
                    validInput = true;
                }
            } 
            catch {
                Console.WriteLine("Not a valid space.");
            }
        }
    }
}


bool GameDone(string[] board) {
    // Check columns.
    for (int i=0; i<3; i++) {
        string space1 = board[0 + i];
        string space2 = board[3 + i];
        string space3 = board[6 + i];

        if(space1 != blank && space2 != blank && space3 != blank && space1 == space2 && space2 == space3) {
            DisplayBoard(board);
            Console.WriteLine("The game was won by " + board[0 + i]);
            return true;
        }
    }

    // Check rows.
    for (int i=0; i<7; i=i+3) {
        string space1 = board[0 + i];
        string space2 = board[1 + i];
        string space3 = board[2 + i];

        if(space1 != blank && space2 != blank && space3 != blank && space1 == space2 && space2 == space3) {
            DisplayBoard(board);
            Console.WriteLine("The game was won by " + board[0 + i]);
            return true;
        }
    }

    // Check diaganols.
    for (int i=0; i<3; i=i+2) {
        string space1 = board[0 + i];
        string space2 = board[4];
        string space3 = board[8 - i];

        if(space1 != blank && space2 != blank && space3 != blank && space1 == space2 && space2 == space3) {
            DisplayBoard(board);
            Console.WriteLine("The game was won by " + board[0 + i]);
            return true;
        }
    }

    // Check for tie.
    int filledSpaces = 0;

    for (int i=0; i<9; i++) {

        if(board[i] != " ") {
            filledSpaces++;
        }

        Console.WriteLine(filledSpaces);

        if(filledSpaces == 9) {
            Console.WriteLine("Equals 9 statement entered.");
            DisplayBoard(board);
            Console.WriteLine("It's a tie.");
            return true;
        }
    }

    return false;

}


void DisplayBoard(string[] board) {
    Console.WriteLine($"\n {board[0]} | {board[1]} | {board[2]} ");
    Console.WriteLine("---+---+---");
    Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
    Console.WriteLine("---+---+---");
    Console.WriteLine($" {board[6]} | {board[7]} | {board[8]}\n");
}

bool IsXTurn(string[] board) {

    int emptySpaces = 0;

    foreach (string space in board) {
        if (space == " ") {
            emptySpaces++;
        }
    }

    if (emptySpaces % 2 == 0) {
        return false;
    } else {
        return true;
    }
}

Console.WriteLine("\nTIC-TAC-TOE\n");
Console.WriteLine("You know the rules. Enter a number from 1 to 9 where numbers "); 
Console.WriteLine("correspond to the following spaces. X goes first.\n");
Console.WriteLine(" 1 | 2 | 3 ");
Console.WriteLine("---+---+---");
Console.WriteLine(" 4 | 5 | 6 ");
Console.WriteLine("---+---+---");
Console.WriteLine(" 7 | 8 | 9 \n");
Console.WriteLine("The current board is:");
Main();
