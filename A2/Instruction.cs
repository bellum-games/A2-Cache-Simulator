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
        public uint currentPC;
        public uint target;

        public Instruction(char instructionType, uint currentPC, uint target)
        {
            this.instructionType = instructionType;
            this.currentPC = currentPC;
            this.target = target;
        }


        //Function that changes the Uniport/Biport
        static int GetPortState(int cacheType)
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
        //13 februarie restanta FLorea
        //Function that take the banchmark instruction and procesed
        public static Tuple<double, double, int, int, int, int> Simulation(List<Tuple<char, uint, uint>> Instructions, int IRMax, uint normalPC, int latenta, int NR_PORT, int N_PEN, int FR_IC, int FR, int SIZE_DC, int SIZE_IC, int IBS)
        {
            Queue<Instruction> data = new Queue<Instruction>();
            List<Instruction> instructionsFromBanchmark = new List<Instruction>();
            int numberOfAritmetical = 0;
            int numberOfBranches = 0;
            int numberOfStores = 0;
            int numberOfLoads = 0;
            int ticks = 0;

            Queue<Instruction> dataCache = new Queue<Instruction>(SIZE_DC);
            Queue<Instruction> instructionCache = new Queue<Instruction>(SIZE_IC);
            Queue<Instruction> instructionBufferSize = new Queue<Instruction>(IBS);

            for (int i = 0; i < FR_IC; i++)
            {
                instructionCache.Enqueue(new Instruction(Instructions[i].Item1, Instructions[i].Item2, Instructions[i].Item3));
            }

            for (int i = 0; i < FR; i++)
            {
                instructionBufferSize.Enqueue(instructionCache.Dequeue());
            }

            for (int i = 0; i < IRMax; i++)
            {
                instructionsFromBanchmark.Add(instructionBufferSize.Dequeue());
            }

            foreach (Instruction instruction in instructionsFromBanchmark)
            {
                while (instruction.currentPC != normalPC)
                {
                    //TODO: add the aritmetico-logic instruction to IC buffer, increment the number of instructions
                    //porcesed

                    data.Enqueue(instruction);
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
                data.Enqueue(instruction);
            }

            ticks = data.Count() / 2 * latenta;
            int memoryAccess = 0;
            Instruction[,] instructions = new Instruction[1000000, IRMax];

            for (int i = 0; i < data.Count; i++)
            {
                for (int j = 0; j < IRMax; j++)
                {
                    instructions[i, j] = data.Dequeue();
                }
            }

            foreach (Instruction instruction in instructions)
            {
                if (memoryAccess < GetPortState(NR_PORT))
                {
                    if (instruction.instructionType == Constants.STORE || instruction.instructionType == Constants.LOAD)
                    {
                        memoryAccess++;
                    }
                }
                else
                {
                    //problema:
                    if (instruction.instructionType == Constants.STORE || instruction.instructionType == Constants.LOAD)
                    {
                        memoryAccess = 0;
                        ticks += latenta;
                    }
                }
            }
            //TODO: Calculate all the metrics.
            double IRcalc = (double)data.Count() / ticks;
            double missCachePenalty = numberOfLoads * Constants.CACHE_MISS * N_PEN;
            ticks += N_PEN;
            return new Tuple<double, double, int, int, int, int>(IRcalc, missCachePenalty, ticks, numberOfBranches, numberOfLoads, numberOfStores);
        }
    }
}
