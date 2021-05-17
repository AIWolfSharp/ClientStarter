﻿//
// PlayerLoader.cs
//
// Copyright 2017 OTSUKI Takashi
// SPDX-License-Identifier: Apache-2.0
//

using AIWolf.Lib;
using System;
using System.IO;
using System.Reflection;

namespace AIWolf.Client
{
    public static class PlayerLoader
    {
        public static IPlayer Load(string className = null, string dllName = null)
        {
            if (String.IsNullOrEmpty(className) || String.IsNullOrEmpty(dllName))
            {
                throw new ArgumentNullException("LoadPlayer: Null class or dll name.");
            }

            Assembly assembly;
            try
            {
                var fullPath = Path.GetFullPath(dllName);
                AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(new AssemblyLoader(Path.GetDirectoryName(fullPath)).LoadFromFolder);
                assembly = Assembly.LoadFile(fullPath);
            }
            catch
            {
                Console.Error.WriteLine($"ClientStarter: Error in loading {dllName}.");
                throw;
            }

            try
            {
                return (IPlayer)Activator.CreateInstance(assembly.GetType(className));

            }
            catch
            {
                Console.Error.WriteLine($"ClientStarter: Error in creating instance of {className}.");
                throw;
            }
        }
    }
}
