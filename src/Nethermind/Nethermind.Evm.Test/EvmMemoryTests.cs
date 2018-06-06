﻿
using NUnit.Framework;

namespace Nethermind.Evm.Test
{
    [TestFixture]
    public class EvmMemoryTests : EvmMemoryTestsBase
    {
        protected override IEvmMemory CreateEvmMemory()
        {
            return new EvmMemory();
        }
    }
}