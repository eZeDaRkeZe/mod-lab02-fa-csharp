using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fans
{
    public class State
    {
        public string Name;
        public Dictionary<char, State> Transitions;
        public bool IsAcceptState;
    }


    public class FA1
    {
        public static State q0 = new State()
        {
            Name = "q0",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public static State q1 = new State()
        {
            Name = "q1",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public static State q2 = new State()
        {
            Name = "q2",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };
        public static State q3 = new State()
        {
            Name = "q3",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };

        public static State q4 = new State()
        {
            Name = "q4",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };

        State InitialState = q0;

        public FA1()
        {
            q0.Transitions['0'] = q1;
            q0.Transitions['1'] = q3;
            q1.Transitions['0'] = q4;
            q1.Transitions['1'] = q2;
            q2.Transitions['0'] = q4;
            q2.Transitions['1'] = q2;
            q3.Transitions['0'] = q2;
            q3.Transitions['1'] = q0;
            q4.Transitions['0'] = q4;
            q4.Transitions['1'] = q4;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                current = current.Transitions[c];
                if (current == null)
                {
                    return null;
                }
            }
            return current.IsAcceptState;
        }
    }

    public class FA2
    {
        public bool? Run(IEnumerable<char> s)
        {
            return false;
        }
    }

    public class FA3
    {
        public bool? Run(IEnumerable<char> s)
        {
            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            String s = "01111";
            FA1 fa1 = new FA1();
            bool? result1 = fa1.Run(s);
            Console.WriteLine(result1);
            FA2 fa2 = new FA2();
            bool? result2 = fa2.Run(s);
            Console.WriteLine(result2);
            FA3 fa3 = new FA3();
            bool? result3 = fa3.Run(s);
            Console.WriteLine(result3);
        }
    }
}