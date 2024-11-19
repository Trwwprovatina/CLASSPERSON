using System;

class NQueens
{
    static void Main()
    {
        // O χρήστης δίνει αριθμό βασίλισσων στην σκακιέρα.
        Console.Write("Enter the size of the chessboard (N for N-Queens): ");
        int N;
        while (!int.TryParse(Console.ReadLine(), out N) || N <= 0)
        {
            Console.WriteLine("Please enter a valid positive integer for N.");
            Console.Write("Enter the size of the chessboard (N): ");
        }

        // Αρχικοποίηση σκακιέρας με μηδέν σε όλες τις θέσεις, καθώς δεν έχει γίνει κάποια τοποθέτηση ακόμα.
        int[,] board = new int[N, N];
        
        // Πίνακας που καταγράφει τις θέσεις των βασίλισσων. Οι θέσεις τους, είναι αρχικοποιημένες στο -1, αφού αρχικά ο πίνακας έχει μηδενικά στοιχεία, αφού καμία βασίλισσα.
        int[] queenPositions = new int[N];
        for (int i = 0; i < N; i++) queenPositions[i] = -1;
        
        int row = 0;  // Ξεκινάμε να τοποθετούμε τις βασίλισσες από την πρώτη γραμμή.
        
        // Κύρια λούπα τοποθέτησης βασίλισσων.
        while (row >= 0 && row < N)
        {
            bool placed = false;
            for (int col = queenPositions[row] + 1; col < N; col++)
            {
                if (IsSafe(board, row, col, N))
                {
                    if (queenPositions[row] != -1) board[row, queenPositions[row]] = 0;
                    board[row, col] = 1;
                    queenPositions[row] = col;
                    placed = true;
                    break;
                }
            }

            if (placed)
            {
                row++;  // Μετακινούμαστε στην επόμενη γραμμή αν τοποθετήθηκε κάποια βασίλισσα επιτυχημένα.
            }
            else
            {
                // Κάνουμε ένα βήμα πίσω, αν δεν καταφέραμε να τοποθετήσουμε.
                if (queenPositions[row] != -1) board[row, queenPositions[row]] = 0;
                queenPositions[row] = -1;
                row--;  // Μετακίνηση στην προηγούμενη γραμμή.
            }
        }

        // Τύπωσε την λύση αν όλες τοποθετήθηκαν επιτυχώς.
        if (row == N)
        {
            Console.WriteLine("Solution found for N = " + N + ":");
            Console.WriteLine("[");

            // Εκτύπωση σκακιέρας.
            for (int i = 0; i < N; i++)
            {
                Console.Write("  [");
                for (int j = 0; j < N; j++)
                {
                    Console.Write(board[i, j]);
                    if (j < N - 1) Console.Write(", ");
                }
                Console.WriteLine("]" + (i < N - 1 ? "," : ""));
            }
            Console.WriteLine("]");
        }
        else
        {
            Console.WriteLine("No solution exists for N = " + N);
            Console.WriteLine("You must enter a larger value of N to find a solution.");
        }
    }
    
    // Μέθοδος για να ελέγξουμε αν μπορούμε να τοποθετήσουμε βασίλισσα στην σκακιέρα..
    static bool IsSafe(int[,] board, int row, int col, int N)
    {
        // Ελέγχω την στήλη για προηγούμενες γραμμές.
        for (int i = 0; i < row; i++)
            if (board[i, col] == 1) return false;

        // Ελέγχω πάνω αριστερά διαγώνιο.
        for (int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--, j--)
            if (board[i, j] == 1) return false;

        // Ελέγχω πάνω δεξιά διαγώνιο.
        for (int i = row - 1, j = col + 1; i >= 0 && j < N; i--, j++)
            if (board[i, j] == 1) return false;

        return true;
    }
}
   