using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class Alignments
    {
        public class Alignment
        {
            readonly string name;
            public Alignment(string name) 
            {
                this.name = name;
            }
        }
        // TODO: add the rest of the possible clan alignments

        public static Alignment Mantis = new Alignment("Mantis");
        public static Alignment Crab = new Alignment("Crab");
        public static Alignment Crane = new Alignment("Crane");
        public static Alignment Dragon = new Alignment("Dragon");
        public static Alignment Lion = new Alignment("Lion");
        public static Alignment Phoenix = new Alignment("Phoenix");
        public static Alignment Scorpion = new Alignment("Scorpion");
        public static Alignment Spider = new Alignment("Spider");
        public static Alignment Unicorn = new Alignment("Unicorn");
        public static Alignment Imperial = new Alignment("Imperial");
        public static Alignment Unaligned = new Alignment("Unaligned");
    }
}
