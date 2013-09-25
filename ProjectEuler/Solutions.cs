using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ProjectEuler
{
    public sealed class Solutions
    {
        private static readonly Solutions instance = new Solutions();

        private Solutions() { }

        public static Solutions Instance
        {
            get
            {
                return instance;
            }
        }

        public string getSolution(int id)
        {
            MethodInfo method = this.GetType().GetMethod("problem" + id);
            try
            {
                object result = method.Invoke(this, null);
                return (string)result;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public string problem1()
        {
            int sum = 0;
            for (int i = 1; i < 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                }    
            }
            return sum.ToString();
        }

        public string problem2()
        {
            int fib = fibonacci(1), i = 1, sum = 0;
            while (fib < 4000000)
            {
                fib = fibonacci(i);
                if (fib % 2 == 0)
                {
                    sum += fib;    
                }
                i++;
            }
            return sum.ToString();
        }

        private int fibonacci(int i)
        {
            if (i == 1)
                return 1;
            if (i == 2)
                return 2;
            else
                return fibonacci(i-1) + fibonacci(i-2);
        }

        public string problem3()
        {
            long number = 600851475143;
            List<long> primeFactors = new List<long>();
            for (long i = 2; i <= number; i++)
            {
                if (isPrimeSimple(i))
                {
                    if (number % i == 0)
                    {
                        // We have a prime factor
                        primeFactors.Add(i);
                        number = number / i;
                    }
                }
            }

            return primeFactors.Last().ToString();
        }

        private bool isPrimeSimple(long candidate)
        {
            for (long i = 2; i < candidate; i++)
            {
                if (candidate % i == 0)
                    return false;
            }
            return true;
        }

        public string problem4()
        {
            int max = 0;
            for (int i = 999; i > 0; i--)
            {
                for (int j = 999; j > 0; j--)
                {
                    if (isPalindromeNumber(i*j))
                    {
                        if (max < i*j)
                        {
                            max = i * j;
                        }
                    }
                }
            }
            return max.ToString();
        }


        private bool isPalindromeNumber(int number)
        {
            string numberString = number.ToString();
            int length = numberString.Length;
            for (int i = 0; i < length/2; i++)
            {
                if (numberString[i] != numberString[length-1-i])
                {
                    return false;
                }
            }

            return true;
        }

        public string problem5()
        {
            bool flagDivisable = true;
            for (int number = 2520; number < 500000000; number++)
			{
                for (int i = 2; i <= 20; i++)
                {
                    if (number % i != 0)
                    {
                        flagDivisable = false;
                        break;
                    }
                }
                if (flagDivisable)
                {
                    return number.ToString();
                }
                flagDivisable = true;
            }
            return "N/A";
        }

        public string problem6()
        {
            int squareSum = 0;
            int sumSquare = 0;
            for (int i = 1; i <= 100; i++)
            {
                squareSum += i * i;
                sumSquare += i;
            }
            sumSquare = sumSquare * sumSquare;
            return (sumSquare-squareSum).ToString();
        }

        public string problem7()
        {
            int primeAmount = 0;
            int number = 2;
            while (primeAmount < 10001)
            {
                if (isPrimeSimple(number))
                {
                    primeAmount++;
                }
                number++;
            }
            return (number-1).ToString();
        }

        public string problem8()
        {
            string number = "7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450"; 
            int max = 0, product;
            for (int i = 0; i < number.Length-4; i++)
            {
                product = Convert.ToInt32(number[i].ToString()) * Convert.ToInt32(number[i + 1].ToString()) * Convert.ToInt32(number[i + 2].ToString()) * Convert.ToInt32(number[i + 3].ToString()) * Convert.ToInt32(number[i + 4].ToString());
                if (product > max)
                {
                    max = product;
                }
            }
            return max.ToString();
        }

        public string problem9()
        {
            int a = 0, b = 0;
            double c = 0;
            for (; a < 100000; a++)
            {
                for (b = 0; b <= a; b++)
                {
                    c = Math.Sqrt(a * a + b * b);
                    if (c % 1 == 0)
                    {
                        // a,b,c is pythagorean triplet
                        if (a+b+c == 1000)
                        {
                            return (a * b * c).ToString();
                        }
                    }
                }
            }
            return "N/A";
        }

        public string problem10()
        {
            long sum = 0;

            List<long> primes = sieveOfAtkin(2000000);
            sum = primes.Sum();

            return sum.ToString();
        }

        private List<long> sieveOfAtkin(long upperLimit)
        {
            bool[] isPrime = new bool[upperLimit + 1];
            double sqrt = Math.Sqrt(upperLimit);
            List<long> primes = new List<long>();

            for (long i = 1; i <= sqrt; i++)
            {
                for (long j = 1; j <= sqrt; j++)
                {
                    long n = 4 * i * i + j * j;
                    if (n <= upperLimit && (n % 12 == 1 || n % 12 == 5))
                    {
                        isPrime[n] ^= true;
                    }

                    n = 3 * i * i + j * j;
                    if (n <= upperLimit && n % 12 == 7)
                    {
                        isPrime[n] ^= true;
                    }

                    n = 3 * i * i - j * j;
                    if (i > j && n <= upperLimit && n % 12 == 11)
                    {
                        isPrime[n] ^= true;
                    }
                }
            }

            for (long n = 5; n <= sqrt; n++)
            {
                if (isPrime[n])
                {
                    long nn = n * n;
                    for (long k = nn; k <= upperLimit; k += nn)
                    {
                        isPrime[k] = false;
                    }
                }
            }

            primes.Add(2);
            primes.Add(3);

            for (long n = 5; n <= upperLimit; n++)
            {
                if (isPrime[n])
                {
                    primes.Add(n);
                }    
            }

            return primes;
        }
    }
}
