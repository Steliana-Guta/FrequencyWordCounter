using System;

namespace RedGate
{
    public interface ICharacterReader : IDisposable
    {
        char GetNextChar();
        
    }
}
