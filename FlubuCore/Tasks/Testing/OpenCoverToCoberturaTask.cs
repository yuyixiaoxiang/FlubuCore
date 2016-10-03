﻿using FlubuCore.Context;
using FlubuCore.Tasks.Process;

namespace FlubuCore.Tasks.Testing
{
    public class OpenCoverToCoberturaTask : TaskBase
    {
        private readonly string _input;
        private readonly string _output;
        private string _toolPath = "tools/tocobertura/OpenCoverToCoberturaConverter.exe";
        private string _workingFolder = ".";

        public OpenCoverToCoberturaTask(string inputFile, string outputFile)
        {
            _input = inputFile;
            _output = outputFile;
        }

        public override string Description => "Convert open cover to cobertura report";

        public OpenCoverToCoberturaTask WorkingFolder(string path)
        {
            _workingFolder = path;
            return this;
        }

        protected override int DoExecute(ITaskContext context)
        {
            RunProgramTask task = new RunProgramTask(_toolPath);

            task
                .WorkingFolder(_workingFolder)
                .WithArguments($"-input:{_input}", $"-output:{_output}");

            return task.Execute(context);
        }
    }
}
