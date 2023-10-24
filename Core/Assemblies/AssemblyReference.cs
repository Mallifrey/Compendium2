﻿using Mono.Cecil;

using System.Reflection;

namespace Compendium.Assemblies
{
    public struct AssemblyReference
    {
        public byte[] Raw;
        public string Name;
        public bool RemovedRefs;

        public Assembly Assembly;
        public AssemblyDefinition Definition;

        public AssemblyDependency[] Dependencies;
    }
}