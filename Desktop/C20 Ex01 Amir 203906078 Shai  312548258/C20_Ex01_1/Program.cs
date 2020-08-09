using System.Text;
using System;
namespace C20_Ex01_1
{
    /// <summary>
    /// program class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// This method gets binary numbers from the user.
        /// </summary>
        /// <returns>binary number from user (as string).</returns>
        public static string GetBinaryNumberFromUser()
        {
            bool v_binaryCheck = true;
            string binaryNumberInput = " ";

            // assume that the input going to be binary
            while (v_binaryCheck == true)
            {
                Console.WriteLine("Binary Number: ");
                binaryNumberInput = Console.ReadLine();
                if (binaryNumberInput.Length != 8)
                {
                    Console.WriteLine("This is not an 8 digit binary Number. Try again");
                    v_binaryCheck = true;
                    continue;
                }

                bool v_containsOnlyOnesAndZeros = CheckForOnesAndZeros(binaryNumberInput);
                if (!v_containsOnlyOnesAndZeros)
                {
                    Console.WriteLine("This is not a vaild binary Number. Try again");
                    v_binaryCheck = true;
                    continue;
                }

                v_binaryCheck = false; // if false  - no more checks needed - the number is binary
            }

            return binaryNumberInput;
        }

        /// <summary>
        /// This method checks if a binary number contains only  0's and 1's.
        /// </summary>
        /// <param name="i_binaryNumber"> string binary number. </param>
        /// <returns>true if binary or false if not. </returns>
        public static bool CheckForOnesAndZeros(string i_binaryNumber)
        {
            for (int i = 0; i < i_binaryNumber.Length; i++)
            {
                if (i_binaryNumber[i] != '0' && i_binaryNumber[i] != '1')
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// This function counts the number of zero's in a binary number.
        /// </summary>
        /// <param name="i_binaryNumber"> binary number.</param>
        /// <returns> number of zeros.</returns>
        public static int NumberOfZeros(StringBuilder i_binaryNumber)
        {
            int numberOfZeros = 0;
            for (int i = 0; i < i_binaryNumber.Length; i++)
            {
                if (i == '0')
                {
                    numberOfZeros++;
                }
            }

            return numberOfZeros;
        }

        /// <summary>
        /// This function counts the number of one's in a binary number.
        /// </summary>
        /// <param name="i_binaryNumber"> binary number.</param>
        /// <returns> number of one's.</returns>
        public static int NumberOfOnes(StringBuilder i_binaryNumber)
        {
            int numberOfOnes = 0;
            for (int i = 0; i < i_binaryNumber.Length; i++)
            {
                if (i == '1')
                {
                    numberOfOnes++;
                }
            }

            return numberOfOnes;
        }

        /// <summary>
        /// This function convert binary number to decimal.
        /// </summary>
        /// <param name="i_binaryNumber"> binary number.</param>
        /// <returns> decimal value.</returns>
        public static int ConvertBinaryToDecimal(int i_binaryNumber)
        {
            int numberForCalculations = i_binaryNumber;
            int baseValue = 1;
            int decimalValue = 0;
            while (numberForCalculations > 0)
            {
                int remainder = numberForCalculations % 10;
                decimalValue = decimalValue + (remainder * baseValue);
                numberForCalculations = numberForCalculations / 10;
                baseValue = baseValue * 2;
            }

            return decimalValue;
        }

        /// <summary>
        /// This function gets joined binary numbers and assign the avg values to the parameters.
        /// </summary>
        /// <param name="i_joinedBinaryNumbers"> joined binary numbers</param>
        /// <param name="io_avgZeros">average zeros parameter. </param>
        /// <param name="io_avgOnes"> average ones parameter.</param>
        public static void GetAverageZerosAndOnes(StringBuilder i_joinedBinaryNumbers, out double io_avgZeros, out double io_avgOnes)
        {
            int zeroCount = 0;
            int onesCount = 0;
            for (int i = 0; i < i_joinedBinaryNumbers.Length; i++)
            {
                if (i_joinedBinaryNumbers[i] == '0')
                {
                    zeroCount++;
                }
                else
                {
                    onesCount++;
                }
            }

            io_avgZeros = zeroCount / (i_joinedBinaryNumbers.Length / 8);
            io_avgOnes = onesCount / (i_joinedBinaryNumbers.Length / 8);
        }

        /// <summary>
        /// This method checks if a number is a power of two.
        /// </summary>
        /// <param name="i_number"> a number </param>
        /// <returns> true if the number is power of two or false if not</returns>
        public static bool IsPowerOfTwo(int i_number)
        {
            if (i_number == 0)
            {
                return false;
            }

            return (int)Math.Ceiling(Math.Log(i_number) / Math.Log(2)) == (int)Math.Floor(Math.Log(i_number) / Math.Log(2));
        }

        /// <summary>
        /// This function checks if the number is in ascending order.
        /// </summary>
        /// <param name="i_number"> a number. </param>
        /// <returns> if ascending order = true , not ascending = false.</returns>
        public static bool IsAscendingOrder(int i_number)
        {
            string i_stringNumber = i_number.ToString();
            bool v_isAscending = false;
            for (int i = 1; i < i_stringNumber.Length; i++)
            {
                if (i_stringNumber[i] > i_stringNumber[i - 1])
                {
                    v_isAscending = true;
                    continue;
                }
                else
                {
                    v_isAscending = false;
                    break;
                }
            }

            return v_isAscending;
        }

        /// <summary>
        /// This method return average number of the inputs sum.
        /// </summary>
        /// <param name="i_countOfInputs"> number of inputs.</param>
        /// <param name="i_sumOfDecimalInput"> sum of inputs.</param>
        /// <returns> average </returns>
        public static int GetAverageNumber(int i_countOfInputs, int i_sumOfDecimalInput)
        {
            return i_sumOfDecimalInput / i_countOfInputs;
        }

        /// <summary>
        /// This method shows the statistics of the inputs
        /// </summary>
        public static void ShowStatistics()
        {
            int integerBinary;
            int countNumbersThatArePowerOfTwo = 0;
            int countAscendingOrderNumbers = 0;
            int countOfInputs = 0;
            int sumOfDecimalInput = 0;
            StringBuilder stringBuilderNumber = new StringBuilder();

            string binaryNumber = GetBinaryNumberFromUser();
            countOfInputs++;

            stringBuilderNumber.Append(binaryNumber);
            bool v_integerBinary = int.TryParse(binaryNumber, out integerBinary);  // true if parsing succeded
            if (v_integerBinary == true)
            {
                int decimalNumber = ConvertBinaryToDecimal(integerBinary);
                sumOfDecimalInput = sumOfDecimalInput + decimalNumber;
                int averageOfInputs = GetAverageNumber(countOfInputs, sumOfDecimalInput); // average of inputs
                bool v_numIsPowerOfTwo = IsPowerOfTwo(decimalNumber);
                bool v_numIsAscending = IsAscendingOrder(decimalNumber);
                if (v_numIsPowerOfTwo == true)
                {
                    countNumbersThatArePowerOfTwo++; // counter of numbers that are "number of two".
                }

                if (v_numIsAscending == true)
                {
                    countAscendingOrderNumbers++;
                }

                Console.WriteLine("binary number: {0}", decimalNumber);
            }
        }
        /// <summary>
        /// Main Method.
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("Please type 4 numbers in binary format with 8 digits (ex: 00001111)");
            for (int i = 0; i < 4; i++)
            {
                ShowStatistics();
            }
        }
    }
}