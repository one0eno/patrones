using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toolss.Generator
{
    public class GeneratorDirector
    {
        private IBuilderGenerator _builderGenerator;

        public GeneratorDirector(IBuilderGenerator builderGenerator)
        {
            SetBuilder(builderGenerator);
        }

        public void SetBuilder(IBuilderGenerator builderGenerator) => _builderGenerator = builderGenerator;


        public void CreateSimpleJsonGenerator(List<string> content, string path)
        {
            _builderGenerator.Reset();
            _builderGenerator.SeContent(content);
            _builderGenerator.SetPath(path);
            _builderGenerator.SetFormat(TypeFormat.Json);
        }

        public void CreateSimplePipeGenerator(List<string> content, string path)
        {

            _builderGenerator.Reset();
            _builderGenerator.SetPath(path);
            _builderGenerator.SeContent(content);
            _builderGenerator.SetFormat(TypeFormat.Pipes);
            _builderGenerator.SetCharacter(TypeCharacter.Uppercase);
        }
    }
}
