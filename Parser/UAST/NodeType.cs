﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public enum NodeType
    {
        Undefined,

        ClassDeclaration,
        MethodDeclaration,
        VarInitialization,
        IFStatement,
        VarAssignment
    }
}
