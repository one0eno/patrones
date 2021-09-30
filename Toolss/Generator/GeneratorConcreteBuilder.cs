using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toolss.Generator
{
    public class GeneratorConcreteBuilder:IBuilderGenerator
    {
        private Generator _generator;

        public GeneratorConcreteBuilder() {
            Reset();
        }

        public void Reset() => _generator = new Generator();

        public void SeContent(List<string> content) => _generator.Content = content;

        public void SetPath(string path) => _generator.Path = path;
        
        public void SetFormat(TypeFormat format) => _generator.Format= format;

        public void SetCharacter(TypeCharacter character) => _generator.Character = character;

        public Generator GetGenerator()
        {
            return _generator;
        }
    }
}
