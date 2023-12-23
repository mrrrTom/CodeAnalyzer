using Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAnalyzer.Parser
{
    public interface IParser
    {
        /// <summary>
        /// Gets tree from file
        /// </summary>
        /// <param name="text"></param>
        /// <returns>Unified abstract syntax tree</returns>
        public IUASTNode Parse(FileInfo text);
    }
}
