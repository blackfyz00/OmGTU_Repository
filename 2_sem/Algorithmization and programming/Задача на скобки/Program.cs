class Program
{
    static void Main(string[] args)
    {
        string str = Console.ReadLine();
        bool answ = false;
        Stack<string> stack = new Stack<string>();
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] == '(') { stack.Push("("); }
            if (str[i] == '[') { stack.Push("["); }
            if (str[i] == '{') { stack.Push("{"); }

            if (str[i] == ')')
            {
                if (Are_Stack_Find(stack, '(') == true) answ = true;
                else { answ = false; break; }
            }
            if (str[i] == ']')
            {
                if (Are_Stack_Find(stack, '[') == true) answ = true;
                else { answ = false; break; }
            }
            if (str[i] == '}')
            {
                if (Are_Stack_Find(stack, '{') == true) answ = true;
                else { answ = false; break; }
            }
        }

        if (answ == true)
            Console.WriteLine("Скобки расставлены правильно");
        else
            Console.WriteLine("Скобки расставлены неправильно");
    }

    static bool Are_Stack_Find(Stack<string> stack, char s)
    {
        if (stack.Count == 0)
            return false;
        else
        {
            if (stack.Pop() == Convert.ToString(s))
                return true;
            else return false;
        }
    }
}