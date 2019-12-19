﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.ML.CodeGenerator.Utilities;

namespace Microsoft.ML.CodeGenerator.CodeGenerator
{
    internal class CSharpSolution : List<IProject>, ISolution
    {
        public string Name { get; set; }

        public void WriteToDisk(string folder)
        {
            foreach ( var project in this)
            {
                project.WriteToDisk(Path.Combine(folder, project.Name));
            }

            // add project to solution
            Utils.CreateSolutionFile(Name, folder);
            var solutionPath = Path.Combine(folder, $"{Name}.sln");
            Utilities.Utils.AddProjectsToSolution(solutionPath, this.Select((project) => project.Name).ToArray());
        }
    }
}
