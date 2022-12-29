using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2
{
    internal class Instruction
    {
        public char instructionType;
        public int currentPC;
        public int target;

        //Function that changes the Uniport/Biport
        int ChangePortState(int cacheType)
        {
            //Check if the option uniport is selected
            if (cacheType == Constants.UNIFIED)
            {
                return 1;
            }
            //Else select the biport
            else
            {
                return 2;
            }
        }

        //Function that take the banchmark instruction and procesed
        void Simulation(Instruction[] instructionsFromBanchmark, int IRMax, int normalPC)
        {
            Instruction[,] instructions = new Instruction[1000000, IRMax];
            int numberOfAritmetical = 0;
            int numberOfBranches = 0;
            int numberOfStores = 0;
            int numberOfLoads = 0;

            foreach (Instruction instruction in instructionsFromBanchmark)
            {
                while (instruction.currentPC != normalPC)
                {
                    //TODO: add the aritmetico-logic instruction to IC buffer, increment the number of instructions
                    //porcesed
                    normalPC++;
                    numberOfAritmetical++;

                }

                if (instruction.instructionType == Constants.BRANCH)
                {
                    //TODO: add the branch instruction to IC buffer, increment the number of branch instructions
                    //porcesed
                    normalPC = instruction.target;
                    numberOfBranches++;
                }
                if (instruction.instructionType == Constants.STORE)
                {
                    //TODO: add the store instruction to IC buffer, increment the number of store instructions
                    //porcesed
                    normalPC++;
                    numberOfStores++;
                }
                if (instruction.instructionType == Constants.LOAD)
                {
                    //TODO: add the store instruction to IC buffer, increment the number of load instructions
                    //porcesed
                    normalPC++;
                    numberOfLoads++;
                }
            }
            //TODO: Calculate all the metrics.
        }
    }
}
