public static Tuple<double, double, int, int, int, int> Simulation(List<Tuple<char, uint, uint>> Instructions, int IRMax, uint normalPC, int latenta, int NR_PORT, int N_PEN, int FR_IC, int FR, int SIZE_DC, int SIZE_IC, int IBS)
{
    Queue<Instruction> data = new Queue<Instruction>();
    List<Instruction> instructionsFromBanchmark = new List<Instruction>();
    int numberOfAritmetical = 0;
    int numberOfBranches = 0;
    int numberOfStores = 0;
    int numberOfLoads = 0;
    int ticks = 0;

    // Initialize caches
    Dictionary<uint, Instruction> dataCache = new Dictionary<uint, Instruction>(SIZE_DC);
    Dictionary<uint, Instruction> instructionCache = new Dictionary<uint, Instruction>(SIZE_IC);
    Queue<Instruction> instructionBufferSize = new Queue<Instruction>(IBS);

    // Load initial data into instruction cache
    for (int i = 0; i < FR_IC; i++)
    {
        instructionCache.Add(Instructions[i].Item2, new Instruction(Instructions[i].Item1, Instructions[i].Item2, Instructions[i].Item3));
    }

    // Load initial data into instruction buffer
    for (int i = 0; i < FR; i++)
    {
        instructionBufferSize.Enqueue(instructionCache[Instructions[i].Item2]);
    }

    // Process benchmark instructions
    for (int i = 0; i < IRMax; i++)
    {
        Instruction instruction = instructionBufferSize.Dequeue();
        instructionsFromBanchmark.Add(instruction);

        // Aritmetical instruction
        if (instruction.currentPC != normalPC)
        {
            data.Enqueue(instruction);
            normalPC++;
            numberOfAritmetical++;
        }
        // Branch instruction
        else if (instruction.instructionType == Constants.BRANCH)
        {
            normalPC = instruction.target;
            numberOfBranches++;
        }
        // Store instruction
        else if (instruction.instructionType == Constants.STORE)
        {
            // Check if data is already in data cache
            if (dataCache.ContainsKey(instruction.target))
            {
                dataCache[instruction.target] = instruction;
            }
            // Otherwise, evict the oldest item in data cache if full
            else if (dataCache.Count == SIZE_DC)
            {
                dataCache.Remove(dataCache.Keys.First());
                dataCache.Add(instruction.target, instruction);
            }
            else
            {
                dataCache.Add(instruction.target, instruction);
            }
            normalPC++;
            numberOfStores++;
        }
        // Load instruction
        else if (instruction.instructionType == Constants.LOAD)
        {
            // Check if data is already in data cache
            if (dataCache.ContainsKey(instruction.target))
            {
                data.Enqueue(dataCache[instruction.target]);
            }
            else
            {
                data.Enqueue(instruction);
            }
            normalPC++;
            numberOfLoads++;
        }
    }

    // Calculate number of ticks
    ticks = data.Count / 2 * latenta;

    // Return results in Tuple
    return Tuple.Create((double)numberOfAritmetical / IRMax, (double)numberOfBranches / IRMax, numberOfStores, numberOfLoads, ticks, numberOfAritmetical + numberOfBranches + numberOfStores + numberOfLoads);
}
