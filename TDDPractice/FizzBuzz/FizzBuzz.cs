namespace TDDPractice.FizzBuzz
{
    public class FizzBuzz
    {
        public string Check(int number)
        {
            string ret = "";

            if (number % 3 == 0)
                ret += "Fizz";

            if (number % 5 == 0)
                ret += "Buzz";

            if(ret == "")
                return number.ToString();

            return ret;
        }
    }
}
