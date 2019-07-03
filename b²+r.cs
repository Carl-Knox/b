using System;       // MicroSoft Visual Studio Express 2015 for Windows Desktop 
using System.Numerics;          // needed for BigInteger 
using System.Windows.Forms;     // needed for Clipboard

namespace B                     // B=b²+r; n≡B (%x) 
{   class Program
    {   [STAThread]             // needed for Clipboar
        static void Main(string[] args)
        {
        /* Variables ****************************************************************/
            BigInteger a, b, n, r, x;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
 
         /* Assign Data **************************************************************/
            n = 224869951114090657;     // 675730721 332780417  (~29.5 seconds)
            a = x = iSqrt(n);
            r = n - (a * a);
            if (x % 2 == 0) x--;
            b = a - x;
            Console.WriteLine("\t n≡b²+r (%x)  Factoring\n {0}", n);
         
        /* Algorithm ****************************************************************/
            while ((((b*b)+r)% x) != 0) { x -= 2; b += 2; } // n≡b²+r (%x)
        
        /* Output Data **************************************************************/
            Console.WriteLine("\n p = {0}\n q = {1}", n/x, x);
            Console.WriteLine(" Press <Enter> to write to Paste Buffer");
            Console.Read(); Console.Read();
            sb.Append(n/x + "\n"); sb.Append(x + "\n");     // store in a string
            Clipboard.SetText(sb.ToString());               // output to clipboard
            Console.Read();
        } // end of Main
        
        /* Methods ******************************************************************/
        private static BigInteger iSqrt(BigInteger num)
        { // Finds the integer square root of a positive number
            if (0 == num) { return 0; }             // Avoid zero divide
            BigInteger n = (num / 2) + 1;           // Initial estimate, never low
            BigInteger n1 = (n + (num / n)) >> 1;   // right shift to divide by 2
            while (n1 < n)
            {   n = n1;
                n1 = (n + (num / n)) >> 1;          // right shift to divide by 2
            }
            return n;
        } // end iSqrt()
    } // end Program
} // end namespace        
