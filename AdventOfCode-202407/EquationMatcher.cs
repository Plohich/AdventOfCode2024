namespace AdventOfCode_202407;

public static class EquationMatcher
{
    private static readonly Stack<(long accumulator, int idx)>  OperationStack = new();
 
    public static long GetMatchOrZero(string equation)
    {
        // 426048: 425 608 69 88 1 282
        OperationStack.Clear(); 
        EquationCheck ec = equation.ConvertToEquationCheck();
        int idx = 1;
        long accum = ec.Addends[0];

        while (idx < ec.Addends.Count)
        {
            long mult = accum * ec.Addends[idx];
            if (mult <= ec.Total)
            {
                OperationStack.Push((accum, idx));
                accum *= ec.Addends[idx]; 
            }

            if (mult > ec.Total)
            {
                accum += ec.Addends[idx];
            }
            
            idx++;
            
            if (idx == ec.Addends.Count)
            {
                if (accum == ec.Total)
                {
                    return accum;
                }

                if (OperationStack.Count == 0)
                {
                    return 0;
                }
                var lastMulOper = OperationStack.Pop();
                accum = lastMulOper.accumulator + ec.Addends[lastMulOper.idx];
                idx = lastMulOper.idx + 1;
            }
        }

        return 0;
    }
    
    public static long FindSolution(string equation)
    {
        EquationCheck ec = equation.ConvertToEquationCheck();
        long target = ec.Total;
        List<long> numbers = ec.Addends;
        
        // Generate all possible combinations of operators
        int operatorCount = numbers.Count - 1;
        int combinations = 1 << operatorCount; // 2^operatorCount possibilities

        for (int i = 0; i < combinations; i++)
        {
            var operators = new char[operatorCount];
            for (int j = 0; j < operatorCount; j++)
            {
                // Use bit manipulation to generate combinations
                operators[j] = ((i & (1 << j)) == 0) ? '+' : '*';
            }

            // Evaluate the expression
            long result = numbers[0];
            var expression = numbers[0].ToString();

            for (int j = 0; j < operatorCount; j++)
            {
                expression += operators[j] + numbers[j + 1].ToString();
                result = operators[j] == '+' ? 
                    result + numbers[j + 1] : 
                    result * numbers[j + 1];
            }

            if (result == target)
            {
                return result;
            }
        }

        return  0;
    }
}