using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnCSharp.Model
{
    public class CodeTestingService
    {
        public async Task<(bool isCorrect, string output)> TestCodeAsync(string userCode, string expectedOutput)
        {
            try
            {
                var result = await CSharpScript.EvaluateAsync<string>(userCode, ScriptOptions.Default);
                bool isCorrect = result.Trim() == expectedOutput.Trim();
                return (isCorrect, result);
            }
            catch (CompilationErrorException e)
            {
                return (false, string.Join("\n", e.Diagnostics));
            }
        }
    }
}
