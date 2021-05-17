//
// AssemblyLoader.cs
//
// Copyright 2017 OTSUKI Takashi
// SPDX-License-Identifier: Apache-2.0
//

using System.IO;
using System.Reflection;
using System;

namespace AIWolf.Client
{
    class AssemblyLoader
    {
        string folderPath;

        public AssemblyLoader(string folderPath) => this.folderPath = folderPath;

        public Assembly LoadFromFolder(object sender, ResolveEventArgs args)
        {
            string assemblyPath = Path.Combine(folderPath, new AssemblyName(args.Name).Name + ".dll");
            if (!File.Exists(assemblyPath)) return null;
            return Assembly.LoadFrom(assemblyPath);
        }
    }
}
