using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toolss.Generator
{
    public enum TypeCharacter { 
        Normal,
        Uppercase,
        Lowercase
        
    }

    public enum TypeFormat { 
    
        Json,
        Pipes
    }

    public interface IBuilderGenerator
    {
        public void Reset();

        public void SeContent(List<string> content);

        public void SetPath(string path);

        public void SetFormat(TypeFormat format = TypeFormat.Json);

        public void SetCharacter(TypeCharacter character = TypeCharacter.Normal);
    }
}
